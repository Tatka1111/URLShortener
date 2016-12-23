using MySql.Data.MySqlClient;
using System;
using System.Web.UI.WebControls;

namespace URLShortener
{
    public partial class Statistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.SetData();
            }

            
            

        }

        void SetData()
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(ShortlinkSQLWorker.connectionString);
                mySqlConnection.Open();
                MySqlCommand selectCommand = new MySqlCommand("SELECT URL,ShortURL,CreatedOn,Clicks FROM URL_Data;", mySqlConnection);
          
                GridView1.DataSource = selectCommand.ExecuteReader();
                GridView1.DataBind();
                mySqlConnection.Close();



            }
            catch (Exception sqlException)
            {
                Response.Write(sqlException.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(Global.BaseURL);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowNum = 0;
            Int32.TryParse((string) e.CommandArgument, out RowNum);

            string URL = GridView1.Rows[RowNum].Cells[1].Text;
            ShortlinkSQLWorker.Delete(URL);
            SetData();

        }
    }
}