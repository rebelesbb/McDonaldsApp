using System.Data;
using McApp.repositoy;
using McApp.service;

namespace McApp.ui;

public partial class MainWindow : Form
{
    private const string ConnectionString = @"Server=DESKTOP-MUSTQB5\SQLEXPRESS;Database=McDonaldsDB;Integrated Security=True;TrustServerCertificate=True;";
    private readonly McService service;
    private readonly DataSet dataSet;

    public MainWindow()
    {
        dataSet = new DataSet();
        service = new McService(new LocationsRepository(ConnectionString, dataSet),
            new EmployeesRepository(ConnectionString, dataSet));
        InitializeComponent();
        InitView();
    }

    private void InitView()
    {
        service.LoadAllLocations();
        service.LoadAllEmployees();

        // Adding foreign key relation
        DataColumn? locationsPK = dataSet.Tables["Locatii"].Columns["cod_locatie"];
        DataColumn? employeesFK = dataSet.Tables["Angajati"].Columns["cod_locatie"];

        if (locationsPK != null && employeesFK != null)
        {
            DataRelation locationsEmployeesRelation = new("fk_locations_employees",
                locationsPK, employeesFK);

            dataSet.Relations.Add(locationsEmployeesRelation);

            //Binding data sources to data grid views
            BindingSource locationsBindingSource = new()
            {
                DataSource = dataSet.Tables["Locatii"]
            };

            BindingSource employeesBindingSource = new BindingSource
            {
                DataSource = locationsBindingSource,
                DataMember = "fk_locations_employees"
            };


            locationsDataGridView.DataSource = locationsBindingSource;
            employeesDataGridView.DataSource = employeesBindingSource;
        }

    }

    private void AddBttn_Click(object sender, EventArgs e)
    {
        if (locationsDataGridView.SelectedRows.Count > 0)
        {
            DataGridViewRow selectedRow = locationsDataGridView.SelectedRows[0];
            int locationId = int.Parse(selectedRow.Cells[0].Value.ToString());

            AddWindow addWindow = new AddWindow();
            addWindow.SetService(this.service, locationId);
            addWindow.Show();
        }
    }

    private void DeleteBttn_Click(object sender, EventArgs e)
    {
        if (locationsDataGridView.SelectedRows.Count > 0 && employeesDataGridView.SelectedRows.Count > 0)
        {
            DataGridViewRow selectedRow = employeesDataGridView.SelectedRows[0];
            int emplooyeeId = int.Parse(selectedRow.Cells[0].Value.ToString());
            try
            {
                service.DeleteEmployee(emplooyeeId);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
   
        }
    }

    private void UpdateBttn_Click(object sender, EventArgs e)
    {
        if (locationsDataGridView.SelectedRows.Count > 0 && employeesDataGridView.SelectedRows.Count > 0)
        {
            DataGridViewRow selectedRow = employeesDataGridView.SelectedRows[0];
            int emplooyeeId = int.Parse(selectedRow.Cells["cod_angajat"].Value.ToString());

            UpdateWindow updateWindow = new UpdateWindow();
            updateWindow.SetService(service, selectedRow, 
                int.Parse(locationsDataGridView.SelectedRows[0].Cells["cod_locatie"].Value.ToString()));
            updateWindow.Show();
        }
        else
        {
            MessageBox.Show("Selectati un rand din tabelul locatii si unul din tabelul angajati!");
        }
    }

}