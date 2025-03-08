using System.Data;
using Microsoft.Data.SqlClient;

namespace McApp.repositoy;

public class LocationsRepository
{
    private readonly String connectionString;
    private readonly DataSet dataSet;
    public LocationsRepository(String connectionString, DataSet dataSet)
    {
        this.connectionString = connectionString;
        this.dataSet = dataSet;
    }

    public void LoadAllLocations()
    {
        using (SqlConnection connection = new SqlConnection(this.connectionString))
        {
            String query = "SELECT * FROM Locatii";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(this.dataSet, "Locatii");
        }
    }
}