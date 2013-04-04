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

public partial class MainControl : System.Web.UI.Page
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


        int articleId = System.Convert.ToInt32(Request.QueryString["id"]);

        string MyConString = ConfigurationSettings.AppSettings["connectionString"];

        OdbcConnection connection = new OdbcConnection(MyConString);


        string sqlText = "select * FROM News WHERE id = " + articleId;
        OdbcCommand command = new OdbcCommand(sqlText, connection);


        //category 1
        string selectSQL = "SELECT id, name, description FROM image WHERE approval = 0 ORDER BY date ASC";
        OdbcCommand cmd1 = new OdbcCommand(selectSQL, connection);
        OdbcDataAdapter adapter = new OdbcDataAdapter(cmd1);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

     //   DataList1.DataSource = ds;
       // DataList1.DataBind();
        
    }





    protected void submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid) //save the image
        {
            string title = titleTxt.Text;
            string content = contentTxt.Text;
            int news = newsDrop.SelectedIndex;

            int RowsAffected = SaveToDB(title, content, news);
            if (RowsAffected > 0)
            {

                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('./maincontrol.aspx');", true);
                cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Update Successful');", true);
            }
            else
            {
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('./maincontrol.aspx');", true);
                cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Invalid Input');", true); ;
            }

        }
    }

    private int SaveToDB(string title, string content, int news)
    {
        int articleId = news;
        //use the web.config to store the connection string
        string MyConString = ConfigurationSettings.AppSettings["connectionString"];
        OdbcConnection connection = new OdbcConnection(MyConString);

        string updateSQL = "UPDATE news SET title=?, content=? WHERE id='" + articleId + "'";
        OdbcCommand command = new OdbcCommand(updateSQL, connection);

        command.Parameters.Add(new OdbcParameter("title", OdbcType.Text, 0, "title")).Value = title;
        command.Parameters.Add(new OdbcParameter("content", OdbcType.Text, 0, "content")).Value = content;

        connection.Open();
        int numRowsAffected = command.ExecuteNonQuery();
        connection.Close();

        return numRowsAffected;


    }


    protected void submit_Click1(object sender, EventArgs e)
    {
        if (Page.IsValid) //save the image
        {
            string title = Text1.Text;
            string content = TextBox1.Text;
           


            int RowsAffected = SaveToDB1(title, content);
            if (RowsAffected > 0)
            {
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('./maincontrol.aspx');", true);
                cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Update Successful');", true);
               
            }
            else
            {
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('./maincontrol.aspx');", true);
                cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Invalid Input');", true); ;
            }

        }
      
    }
    private int SaveToDB1(string title, string content)
    {
        
        //use the web.config to store the connection string
        string MyConString = ConfigurationSettings.AppSettings["connectionString"];
        OdbcConnection connection = new OdbcConnection(MyConString);

        OdbcCommand command = new OdbcCommand("INSERT INTO latestnews (title, content) VALUES (?, ?)", connection);

        command.Parameters.Add(new OdbcParameter("title", OdbcType.Text, 0, "title")).Value = title;
        command.Parameters.Add(new OdbcParameter("content", OdbcType.Text, 0, "content")).Value = content;

        connection.Open();
        int numRowsAffected = command.ExecuteNonQuery();
        connection.Close();

        return numRowsAffected;


    }
}
