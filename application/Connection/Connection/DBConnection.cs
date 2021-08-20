using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Connection.Connection
{

    public class DBConnection
    {

        #region private variables

        private SqlConnection boConnection;

        private string dataSource
        {
            get { return ConfigurationManager.AppSettings.Get("DataSource"); }
        }

        private string userID
        {
            get { return ConfigurationManager.AppSettings.Get("UserID"); }
        }

        private string Password
        {
            get { return ConfigurationManager.AppSettings.Get("Password"); }
        }
        
        public string getConnectionString
        {
            get { return string.Format("Data Source='{0}';User ID='{1}';Password='{2}';Initial Catalog=SGO;Persist Security Info=True;", dataSource, userID, Password); }
        }

        #endregion

        #region instance member

        public SqlConnection Connect()
        {
            try
            {
                if (boConnection == null || boConnection.ConnectionString.Equals("", StringComparison.OrdinalIgnoreCase))
                {
                    boConnection = new SqlConnection(getConnectionString);
                    boConnection.Open();
                }
                else
                {
                    boConnection = new SqlConnection(getConnectionString);
                    if (boConnection.State.ToString() == "Closed")
                    {
                        boConnection.Open();
                    }
                }
            }
            catch
            { throw; }
            return boConnection;
        }

        public void Disconnect()
        {
            if (boConnection.State.ToString() == "Open")
            {
                boConnection.Close();
            }
        }

        #endregion

    }

}
