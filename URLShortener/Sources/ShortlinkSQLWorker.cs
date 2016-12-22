using MySql.Data.MySqlClient;
using System;

namespace URLShortener
{
    public class ShortlinkSQLWorker
    {
        static public string connectionString = "server=localhost;user=root;password=;database=URLShortener;port=3306";

        public static string Initialize()
        {

            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
                mySqlConnection.Open();
                MySqlCommand initCommand = new MySqlCommand("CREATE TABLE IF NOT EXISTS URL_Data (URL TEXT NOT NULL, ShortURL CHAR(60) NOT NULL, CreatedOn CHAR(20) NOT NULL, Clicks INT NOT NULL)",
                    mySqlConnection);
                initCommand.ExecuteNonQuery();
                mySqlConnection.Close();

            } catch (Exception sqlException)
            {
                return sqlException.Message;
            }
            return "";
        }

        public static string InsertShortURL(string LongURL)
        {

            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
                mySqlConnection.Open();

                string ShortURL = "";
                //сделал цикл чтобы не было совпадений по короткому URL
                MySqlDataReader checkingSqlReader;
                do
                {
                    ShortURL = ShortLinkGenerator(LongURL);
                    MySqlCommand checkingShortLink = new MySqlCommand(string.Format("SELECT URL FROM URL_Data WHERE ShortURL = '{0}';",
                    Global.BaseURL+ShortURL),
                    mySqlConnection);

                    checkingSqlReader = checkingShortLink.ExecuteReader();

                } while (checkingSqlReader.Read());
                checkingSqlReader.Close();

                MySqlCommand NewShortLink = new MySqlCommand(string.Format("INSERT INTO URL_Data (URL, ShortURL, CreatedOn, Clicks) VALUES ('{0}','{1}','{2}',{3});",
                    LongURL, Global.BaseURL+ShortURL, DateTime.Now.ToString(), 0),
                    mySqlConnection);
                NewShortLink.ExecuteNonQuery();
                mySqlConnection.Close();

                return ShortURL;

            } catch (Exception sqlException)
            {
                return sqlException.Message;
            }
        }

        public static string SelectURL(string ShortURL)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
                mySqlConnection.Open();

                MySqlCommand NewShortLink = new MySqlCommand(string.Format("SELECT URL FROM URL_Data WHERE ShortURL = '{0}';",
                    Global.BaseURL+ShortURL),
                    mySqlConnection);

                MySqlDataReader SqlReader = NewShortLink.ExecuteReader();
                string URL = "";

                if (SqlReader.Read())
                {
                    URL = (string)SqlReader["URL"];
                    SqlReader.Close();
                    MySqlCommand UpdateCount = new MySqlCommand(string.Format("UPDATE URL_Data SET Clicks=Clicks+1 WHERE ShortURL='{0}' LIMIT 1;",
                        Global.BaseURL+ShortURL), mySqlConnection);
                    UpdateCount.ExecuteNonQuery();
                }
                
                mySqlConnection.Close();
                return URL;

            }
            catch (Exception sqlException)
            {
                return "<ERROR>: " + sqlException.Message;
            }

        }

        public static void Delete(string ShortURL)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
                mySqlConnection.Open();

                MySqlCommand NewShortLink = new MySqlCommand(string.Format("DELETE FROM URL_Data WHERE ShortURL='{0}' LIMIT 1;", ShortURL),
                    mySqlConnection);
                NewShortLink.ExecuteNonQuery();

            } catch (Exception sqlException)
            {

            }
        }

        protected static string ShortLinkGenerator(string URL)
        {
            char[] allowedChars = "abdefhiknrstyzABDEFGHKNQRSTYZ23456789".ToCharArray();
            string Output = "";
            Random random = new Random();

            for (int i = 0; i < 6; i++)
            {

                int randomChar = random.Next(allowedChars.Length - 1);
                Output = Output + allowedChars[randomChar];
            }
            return Output;
        }
    }
}