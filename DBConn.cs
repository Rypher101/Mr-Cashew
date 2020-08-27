using System.Diagnostics;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Mr_Cashew
{
    internal class DBConn
    {
        public static readonly DBConn _obj = new DBConn();
        private readonly MySqlConnection Connection;
        private readonly string conString = @"Server=localhost;Port=3308;Database=mrcashew;Uid=root;Password=;";

        public DBConn()
        {
            Connection = new MySqlConnection(conString);
            try
            {
                Connection.Open();
                Debug.WriteLine("Connection opened.");
            }
            catch
            {
                MessageBox.Show("Couldn't open the connection", "DB Connection Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }

        ~DBConn()
        {
            Connection.Dispose();
        }

        public MySqlConnection GetConnection()
        {
            return Connection;
        }
    }
}