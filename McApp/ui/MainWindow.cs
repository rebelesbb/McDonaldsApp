using System.Data;
using McApp.repositoy;
using McApp.service;

namespace McApp.ui;

public partial class MainWindow : Form
{
    private const string ConnectionString = @"Server=DESKTOP-MUSTQB5\SQLEXPRESS;Database=McDonaldsDB;Integrated Security=True;TrustServerCertificate=True;";
    private McService service;
    private DataSet _dataSet;
    private BindingSource employeesBindingSource;

    public MainWindow()
    {
        InitializeComponent();
        InitView();
    }

    private void InitView()
    {
        service = new McService(new LocationsRepository(ConnectionString),
            new EmployeesRepository(ConnectionString));
        _dataSet = new DataSet();

        service.LoadAllLocations(_dataSet);
        service.LoadAllEmployees(_dataSet);

        // Adding foreign key relation
        DataColumn locationsPK = _dataSet.Tables["Locatii"].Columns["cod_locatie"];
        DataColumn employeesFK = _dataSet.Tables["Angajati"].Columns["cod_locatie"];

        DataRelation locationsEmployeesRelation = new DataRelation("fk_locations_employees",
            locationsPK, employeesFK);

        _dataSet.Relations.Add(locationsEmployeesRelation);

        //Binding data sources to data grid views
        BindingSource locationsBindingSource = new BindingSource();
        locationsBindingSource.DataSource = _dataSet.Tables["Locatii"];

        this.employeesBindingSource = new BindingSource();
        employeesBindingSource.DataSource = locationsBindingSource;
        employeesBindingSource.DataMember = "fk_locations_employees";


        locationsDataGridView.DataSource = locationsBindingSource;
        employeesDataGridView.DataSource = employeesBindingSource;

    }

    private void AddBttn_Click(object sender, EventArgs e)
    {
        if (locationsDataGridView.SelectedRows.Count > 0)
        {
            DataGridViewRow selectedRow = locationsDataGridView.SelectedRows[0];
            int locationId = int.Parse(selectedRow.Cells[0].Value.ToString());

            AddWindow addWindow = new AddWindow();
            addWindow.SetService(this.service, this._dataSet, locationId);
            addWindow.Show();
            //employeesBindingSource.ResetBindings(false);
        }
    }

    private void DeleteBttn_Click(object sender, EventArgs e)
    {
        if (locationsDataGridView.SelectedRows.Count > 0 && employeesDataGridView.SelectedRows.Count > 0)
        {
            DataGridViewRow selectedRow = employeesDataGridView.SelectedRows[0];
            int emplooyeeId = int.Parse(selectedRow.Cells[0].Value.ToString());

            service.DeleteEmployee(this._dataSet, emplooyeeId);
            //employeesBindingSource.ResetBindings(false);
        }
    }

    private void UpdateBttn_Click(object sender, EventArgs e)
    {
        if (locationsDataGridView.SelectedRows.Count > 0 && employeesDataGridView.SelectedRows.Count > 0)
        {
            DataGridViewRow selectedRow = employeesDataGridView.SelectedRows[0];
            int emplooyeeId = int.Parse(selectedRow.Cells[0].Value.ToString());

            UpdateWindow updateWindow = new UpdateWindow();
            updateWindow.SetService(service, _dataSet, emplooyeeId);
            updateWindow.Show();
            //employeesBindingSource.ResetBindings(false);
        }
    }
}