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


public partial class News : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //   string ImageId = System.Convert.ToString(Request.QueryString["name"]);


        int articleID = System.Convert.ToInt32(Request.QueryString["textid"]);



        string MyConString = ConfigurationSettings.AppSettings["connectionString"];

        OdbcConnection connection = new OdbcConnection(MyConString);

        string sqlNews1 = "select * FROM latestnews";
        OdbcCommand commandNews1 = new OdbcCommand(sqlNews1, connection);
        connection.Open();
        OdbcDataReader dr = commandNews1.ExecuteReader(CommandBehavior.CloseConnection);

        if (dr.Read())
        {
            Response.ContentType = dr["date"].ToString();
            Response.ContentType = dr["title"].ToString();
            Response.ContentType = dr["content"].ToString();

        }
        connection.Close();

        string selectNews = "SELECT date, title, content FROM latestnews ORDER BY date DESC";
        OdbcCommand command = new OdbcCommand(selectNews, connection);
        OdbcDataAdapter adapter = new OdbcDataAdapter(command);
        DataSet ds = new DataSet();

        adapter.Fill(ds);

        DataList1.DataSource = ds;
        DataList1.DataBind();


    }

}



