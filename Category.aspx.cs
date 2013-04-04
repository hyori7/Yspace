using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.Odbc;

public partial class Category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int ImageId = System.Convert.ToInt32(Request.QueryString["id"]);
        string CatId = System.Convert.ToString(Request.QueryString["cat"]);

        categoryTxt.Text = CatId;
        string MyConString = ConfigurationSettings.AppSettings["connectionString"];

        OdbcConnection connection = new OdbcConnection(MyConString);


        string sqlText = "select id, data, type, description, category FROM image WHERE id = " + ImageId;
        string countQuery = "update image set count = (count +1) where id = " + ImageId;
       
        OdbcCommand command = new OdbcCommand(sqlText, connection);
        OdbcCommand countCommand = new OdbcCommand(countQuery, connection);

        connection.Open();
        OdbcDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);

        if (dr.Read())
        {

            Response.ContentType = dr["type"].ToString();
            Response.BinaryWrite((byte[])dr["data"]);


        }
        connection.Close();

        string selectSQL = "SELECT id, name, description FROM image WHERE approval = 1 AND category='" + CatId +"'";
        OdbcCommand cmd1 = new OdbcCommand(selectSQL, connection);
        OdbcDataAdapter adapter = new OdbcDataAdapter(cmd1);
        DataSet ds = new DataSet();

        adapter.Fill(ds);

        DataList1.DataSource = ds;
        DataList1.DataBind();

    }
    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/display.aspx");
    }
}
