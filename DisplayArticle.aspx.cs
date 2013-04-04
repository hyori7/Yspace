using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.Odbc;

namespace yspace
{
    public partial class WebForm17 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cate = Request.QueryString["category"];
            int artID = System.Convert.ToInt32(Request.QueryString["articleID"]);

            string MyConString = ConfigurationSettings.AppSettings["connectionString"];

            OdbcConnection connection = new OdbcConnection(MyConString);
            // build our query statement

            string sqlText = "select * FROM articles";
            OdbcCommand command = new OdbcCommand(sqlText, connection);





            // open the database and get a datareader
            connection.Open();
            OdbcDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            
            connection.Close();

            string selectSQL = "SELECT * FROM articles WHERE category = '" + cate + "' ORDER BY title ASC";
            OdbcCommand cmd1 = new OdbcCommand(selectSQL, connection);
            OdbcDataAdapter adapter = new OdbcDataAdapter(cmd1);
            DataSet ds = new DataSet();

            adapter.Fill(ds);

            DataList10.DataSource = ds;
            DataList10.DataBind();


        }
    }
}
