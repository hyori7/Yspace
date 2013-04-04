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
    public partial class WebForm16 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string searchedItem = Request.QueryString["searchBox"];
            int artID = System.Convert.ToInt32(Request.QueryString["articleID"]);

            string MyConString = ConfigurationSettings.AppSettings["connectionString"];

            OdbcConnection connection = new OdbcConnection(MyConString);
            // build our query statement

            string sqlText = "select * FROM articles";
            OdbcCommand command = new OdbcCommand(sqlText, connection);





            // open the database and get a datareader
            connection.Open();
            OdbcDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

            if (dr.Read()) //yup we found our article
            {
                Response.ContentType = dr["title"].ToString();
                Response.ContentType = dr["content"].ToString();
                Response.ContentType = dr["AuthorAndDate"].ToString();

            }

            connection.Close();

            string selectSQL = "SELECT * FROM articles WHERE (content) LIKE '%" + searchedItem + "%' OR (authorAndDate) LIKE '%" + searchedItem + "%' OR (title) LIKE '%" + searchedItem + "%' ORDER BY title ASC";
            OdbcCommand cmd1 = new OdbcCommand(selectSQL, connection);
            OdbcDataAdapter adapter = new OdbcDataAdapter(cmd1);
            
            DataSet ds = new DataSet();

            adapter.Fill(ds);

            DataList10.DataSource = ds;
            DataList10.DataBind();

                         
           

        }
    }
}
