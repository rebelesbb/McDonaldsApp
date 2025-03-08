using McApp.domain;
using McApp.domain.validators;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McApp.repositoy;

public class EmployeesRepository
{
    private readonly EmployeeValidator validator;
    private readonly SqlConnection connection;
    private SqlDataAdapter dataAdapter;
    private readonly DataSet dataSet;

    public EmployeesRepository(string connectionString, DataSet dataSet)
    {
        validator = new EmployeeValidator();
        try
        {
            this.connection = new SqlConnection(connectionString);
            InitializeDataAdapter();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        this.dataSet = dataSet;
    }

   
    private void InitializeDataAdapter()
    {

        string query = "SELECT * FROM Angajati";
        dataAdapter = new SqlDataAdapter(query, connection);

        // Insert
        string insertQuery = "INSERT INTO Angajati (nume, prenume, cod_locatie, numar_telefon, functie, salariu, data_angajare) " +
                                "VALUES (@nume, @prenume, @cod_locatie, @numar_telefon, @functie, @salariu, @data_angajare)";

        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
        insertCommand.Parameters.Add("@nume", SqlDbType.NVarChar, 50, "nume");
        insertCommand.Parameters.Add("@prenume", SqlDbType.NVarChar, 50, "prenume");
        insertCommand.Parameters.Add("@cod_locatie", SqlDbType.Int, 0, "cod_locatie");
        insertCommand.Parameters.Add("@numar_telefon", SqlDbType.NVarChar, 20, "numar_telefon");
        insertCommand.Parameters.Add("@functie", SqlDbType.NVarChar, 50, "functie");
        insertCommand.Parameters.Add("@salariu", SqlDbType.Int, 0, "salariu");
        insertCommand.Parameters.Add("@data_angajare", SqlDbType.DateTime, 0, "data_angajare");

        dataAdapter.InsertCommand = insertCommand;

        // Delete
        string deleteQuery = "DELETE FROM Angajati WHERE cod_angajat = @cod_angajat";

        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
        deleteCommand.Parameters.Add("@cod_angajat", SqlDbType.Int, 0, "cod_angajat");

        this.dataAdapter.DeleteCommand = deleteCommand;

        //Update
        string updateQuery = "UPDATE Angajati SET nume = @nume, prenume = @prenume, cod_locatie = @cod_locatie, " +
                         "numar_telefon = @numar_telefon, functie = @functie, salariu = @salariu, data_angajare = @data_angajare " +
                         "WHERE cod_angajat = @cod_angajat";

        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
        updateCommand.Parameters.Add("@nume", SqlDbType.NVarChar, 50, "nume");
        updateCommand.Parameters.Add("@prenume", SqlDbType.NVarChar, 50, "prenume");
        updateCommand.Parameters.Add("@cod_locatie", SqlDbType.Int, 0, "cod_locatie");
        updateCommand.Parameters.Add("@numar_telefon", SqlDbType.NVarChar, 20, "numar_telefon");
        updateCommand.Parameters.Add("@functie", SqlDbType.NVarChar, 50, "functie");
        updateCommand.Parameters.Add("@salariu", SqlDbType.Int, 0, "salariu");
        updateCommand.Parameters.Add("@data_angajare", SqlDbType.DateTime, 0, "data_angajare");
        updateCommand.Parameters.Add("@cod_angajat", SqlDbType.Int, 0, "cod_angajat");

        dataAdapter.UpdateCommand = updateCommand;

    }


    public int GetIdentity()
    {
        int identityValue = 0;
        string query = $"SELECT IDENT_CURRENT('Angajati')";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            this.connection.Open();
            object result = command.ExecuteScalar();
            if (result != DBNull.Value)
            {
                identityValue = Convert.ToInt32(result);
            }
            this.connection.Close();
        }
        

        return identityValue;
    }
    public void LoadAllEmployees()
    {
        dataAdapter.Fill(this.dataSet, "Angajati");
    }

    public void Save(Employee employee)
    {
        validator.ValidateEmployee(employee);

        DataTable? employeesTable = this.dataSet.Tables["Angajati"];
        if (employeesTable != null)
        {
            DataRow newRow = employeesTable.NewRow();
            newRow["nume"] = employee.Lastname;
            newRow["prenume"] = employee.Firstname;
            newRow["cod_locatie"] = employee.LocationId;
            newRow["numar_telefon"] = employee.PhoneNumber;
            newRow["functie"] = employee.Position;
            newRow["salariu"] = employee.Salary;
            newRow["data_angajare"] = employee.HireDate.Date;
            employeesTable.Rows.Add(newRow);

            dataAdapter.Update(this.dataSet, "Angajati");
            newRow["cod_angajat"] = GetIdentity();
        }
    }

    public void Delete(int employeeId)
    {
        DataTable? employeesTable = this.dataSet.Tables["Angajati"];
        if (employeesTable != null)
        {
            DataRow[] rows = employeesTable.Select($"cod_angajat = {employeeId}");
            if (rows.Length > 0)
            {
                rows[0].Delete();
                dataAdapter.Update(this.dataSet, "Angajati");
            }
        }
    }

    public void Update(Employee employee)
    {
        validator.ValidateEmployee(employee);

        DataTable? employeesTable = this.dataSet.Tables["Angajati"];

        // Find the row to update
        if (employeesTable != null)
        {
            DataRow[] rows = employeesTable.Select($"cod_angajat = {employee.Id}");
            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                row["nume"] = employee.Lastname;
                row["prenume"] = employee.Firstname;
                row["cod_locatie"] = employee.LocationId;
                row["numar_telefon"] = employee.PhoneNumber;
                row["functie"] = employee.Position;
                row["salariu"] = employee.Salary;
                row["data_angajare"] = employee.HireDate.Date;

                dataAdapter.Update(this.dataSet, "Angajati");
            }
        }
    }

}
