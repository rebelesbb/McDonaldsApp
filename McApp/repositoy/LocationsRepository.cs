using System.Data;
using Microsoft.Data.SqlClient;

namespace McApp.repositoy;

public class LocationsRepository
{
    private readonly String _connectionString;
    public LocationsRepository(String connectionString)
    {
        this._connectionString = connectionString;
    }

    public void LoadAllLocations(DataSet dataSet)
    {
        using (SqlConnection connection = new SqlConnection(this._connectionString))
        {
            String query = "SELECT * FROM Locatii";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dataSet, "Locatii");
        }
    }
}