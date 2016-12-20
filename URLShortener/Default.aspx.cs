using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace URLShortener
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string SQLInit = ShortlinkSQLWorker.Initialize();
                if (SQLInit!= "")
                {
                    TextBox1.Enabled = false;
                    TextBox1.Text = "ERROR: " + SQLInit;
                }

                if (Global.BaseURL == "")
                {
                    Global.BaseURL = Request.Url.AbsoluteUri.Replace("Default.aspx","");
                }
            }
        }

        protected bool IsURL(string URL)
        {
            bool isRealUrl = URL.IndexOf("://") > -1;
            bool isNotRecursion = URL.IndexOf(Request.Url.AbsoluteUri.Replace("Default.aspx", "")) == -1;
            bool IsDbAccessible = TextBox1.Enabled; 

            return (isRealUrl & isNotRecursion & IsDbAccessible);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string url = TextBox1.Text;

            if (!IsURL(url)) return;

            TextBox1.Text = "Wait...";

            string ShortURL = "";
            if ((ShortURL = ShortlinkSQLWorker.InsertShortURL(url)).Length > 0)
            {
                TextBox1.Text = Global.BaseURL+ShortURL;
            } else
            {
                TextBox1.Text = "Some kind of error occured, probably with MySQL connection";
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Statistics.aspx");
        }
    }
}