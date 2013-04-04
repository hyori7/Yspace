using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Odbc;


public partial class Control : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (HttpContext.Current.Session["USER_ROLE"] != null)
        {
            string s = HttpContext.Current.Session["USER_ROLE"].ToString();
            if (s != "Admin")
            {
                Response.Redirect("~/default.aspx");
            }
        }
        else
        {
            Response.Redirect("~/default.aspx");
        }

        int ImageId = System.Convert.ToInt32(Request.QueryString["id"]);

        string MyConString = ConfigurationSettings.AppSettings["connectionString"];

        OdbcConnection connection = new OdbcConnection(MyConString);


        string sqlText = "select data, type, description FROM image WHERE approval = 0 AND id = " + ImageId;
        OdbcCommand command = new OdbcCommand(sqlText, connection);
        string sqlDelete = "DELETE FROM image WHERE approval = 9";
        OdbcCommand cmd2 = new OdbcCommand(sqlDelete, connection);
        connection.Open();
        cmd2.ExecuteNonQuery();
        OdbcDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);
        


        if (dr.Read())
        {

            Response.ContentType = dr["type"].ToString();
            Response.BinaryWrite((byte[])dr["data"]);


        }
        connection.Close();


        //category 1
        string selectSQL = "SELECT id, name, description FROM image WHERE approval = 0";
        OdbcCommand cmd1 = new OdbcCommand(selectSQL, connection);
        OdbcDataAdapter adapter = new OdbcDataAdapter(cmd1);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        DataList1.DataSource = ds;
        DataList1.DataBind();

        
        
        
        
        

      

   }





   // protected void submit_Click(object sender, EventArgs e)
    //{
    //    if (Page.IsValid) //save the image
    //    {
           
    //        string approval = approvalDrop.SelectedValue;
           

    //        int RowsAffected = SaveToDB(approval);
    //        if (RowsAffected > 0)
    //        {
            
    //            Response.Redirect("~/Admin/Control.aspx");
    //        }
    //        else
    //        {
    //            Response.Write("<BR>An error occurred");
    //        }
            
    //    }
    //}

    //private int SaveToDB(string approval)
    //{
    //    int ImageId = System.Convert.ToInt32(Request.QueryString["id"]);
    //    //use the web.config to store the connection string
    //    string MyConString = "SERVER=127.0.0.1;" +
    //         "DATABASE=yspace2;" +
    //         "UID=root;" +
    //         "PASSWORD=123;";
    //    OdbcConnection connection = new OdbcConnection(MyConString);

    //    OdbcCommand command = new OdbcCommand("UPDATE image SET approval = @approval WHERE id="+ ImageId, connection);

    //    OdbcParameter param0 = new OdbcParameter("@approval", OdbcType.VarChar, 10);
    //    param0.Value = approval;
    //    command.Parameters.Add(param0);

      
    //    connection.Open();
    //    int numRowsAffected = command.ExecuteNonQuery();
    //    connection.Close();

    //    return numRowsAffected;


    //}

}
