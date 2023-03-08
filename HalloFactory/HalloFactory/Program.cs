using System.Data.Common;

Console.WriteLine("Hello, World!");

var sqlServerConString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=true";

//DbProviderFactory factory = Microsoft.Data.SqlClient.SqlClientFactory.Instance;
DbProviderFactory factory = MySql.Data.MySqlClient.MySqlClientFactory.Instance;

var con = factory.CreateConnection();
con.ConnectionString = sqlServerConString;
con.Open();

var cmd = factory.CreateCommand();
cmd.Connection= con;
cmd.CommandText = "SELECT COUNT(*) FROM sys.all_objects";

var count = cmd.ExecuteScalar();

Console.WriteLine($"{count} Einträge in all_objects");


