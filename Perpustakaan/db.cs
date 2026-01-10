using MySqlConnector;

public static class Db
{
    private const string CS =
        "Server=localhost;Database=perpustakaan;User ID=root;Password=;SslMode=None;";

    public static MySqlConnection Conn() => new MySqlConnection(CS);
}