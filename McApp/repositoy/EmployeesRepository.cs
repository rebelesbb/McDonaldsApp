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
    SqlConnection connection;
    private string _connectionString;
    private SqlDataAdapter dataAdapter;

    public EmployeesRepository(string connectionString)
    {
        _connectionString = connectionString;
        try
        {
            this.connection = new SqlConnection(_connectionString);
            InitializeDataAdapter();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
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
    public void LoadAllEmployees(DataSet dataSet)
    {
        dataAdapter.Fill(dataSet, "Angajati");
    }

    public void Save(DataSet dataSet, string lastname, string firstname, int locationId, string phoneNumber,
        string position, int salary, DateTime hireDate)
    {

        DataTable employeesTable = dataSet.Tables["Angajati"];
        DataRow newRow = employeesTable.NewRow();
        newRow["nume"] = lastname;
        newRow["prenume"] = firstname;
        newRow["cod_locatie"] = locationId;
        newRow["numar_telefon"] = phoneNumber;
        newRow["functie"] = position;
        newRow["salariu"] = salary;
        newRow["data_angajare"] = hireDate.Date;
        employeesTable.Rows.Add(newRow);

        dataAdapter.Update(dataSet, "Angajati");
        newRow["cod_angajat"] = GetIdentity();
    }

    public void Delete(DataSet dataSet, int employeeId)
    {
        DataTable employeesTable = dataSet.Tables["Angajati"];
        DataRow[] rows = employeesTable.Select($"cod_angajat = {employeeId}");
        if (rows.Length > 0)
        {
            rows[0].Delete();  
            dataAdapter.Update(dataSet, "Angajati"); 
        }
    }

    public void Update(DataSet dataSet, int employeeId, string lastname, string firstname, int locationId, string phoneNumber,
        string position, int salary, DateTime hireDate)
    {
        DataTable employeesTable = dataSet.Tables["Angajati"];

        // Find the row to update
        DataRow[] rows = employeesTable.Select($"cod_angajat = {employeeId}");
        if (rows.Length > 0)
        {
            DataRow row = rows[0];
            row["cod_angajat"] = employeeId;
            row["nume"] = lastname;
            row["prenume"] = firstname;
            row["cod_locatie"] = locationId;
            row["numar_telefon"] = phoneNumber;
            row["functie"] = position;
            row["salariu"] = salary;
            row["data_angajare"] = hireDate;

            dataAdapter.Update(dataSet, "Angajati"); // Apply changes to database
        }
    }

}
