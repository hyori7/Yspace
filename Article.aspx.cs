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
using System.Drawing.Imaging;

public partial class Article : System.Web.UI.Page
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

        string MyConString = ConfigurationSettings.AppSettings["connectionString"];
        OdbcConnection connection = new OdbcConnection(MyConString);
        string list = categoryDrop.SelectedValue;

        if (list == "")
        {
            string main = "main";
            string sqlDefault = "SELECT * FROM category WHERE type ='"+ main +"'";
            OdbcCommand command = new OdbcCommand(sqlDefault, connection);

            OdbcDataAdapter adapter = new OdbcDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            categoryDrop.DataSource = ds;
            categoryDrop.DataValueField = "name";
            categoryDrop.DataTextField = "name";
            categoryDrop.DataBind();
        }

        
        if(list == "SPACES" || list == "STRATEGIES" || list == "USES" || list == "DIVERSITY" || list == "RESEARCH")
        {
            string sqlCat = "SELECT * FROM category WHERE type ='" + list + "'";
            OdbcCommand command = new OdbcCommand(sqlCat, connection);

            OdbcDataAdapter adapter = new OdbcDataAdapter(command);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            categoryDrop.DataSource = ds;
            categoryDrop.DataBind();
            categoryDrop.AutoPostBack = false;
        }

    }





    protected void submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid) //save the image
        {
            string title = titleTxt.Text;
            string content = contentTxt.Text;
            string category = categoryDrop.SelectedValue;
            string author = authorTxt.Text;
            Stream imgStream = UploadFile.PostedFile.InputStream;
            int imgLen = UploadFile.PostedFile.ContentLength;
            string imgContentType = UploadFile.PostedFile.ContentType;
            byte[] imgBinaryData = new byte[imgLen];
            int n = imgStream.Read(imgBinaryData, 0, imgLen);

            
            
            int RowsAffected = SaveToDB(title, content, category, author, imgBinaryData);






            if (RowsAffected > 0)
            {
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('../article.aspx');", true);
                cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Article has been uploaded');", true);
            }
            else
            {
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('../article.aspx');", true);
                cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Invalid Input');", true);
            }


        }
        
    }

    private int SaveToDB(string title, string content, string category, string author, byte[] imgbin)
    {
        //use the web.config to store the connection string
        string MyConString = ConfigurationSettings.AppSettings["connectionString"];
        OdbcConnection connection = new OdbcConnection(MyConString);

        OdbcCommand command = new OdbcCommand("INSERT INTO articles (title, content, category, AuthorAndDate, image) VALUES ( ?, ?, ?, ?, ?)", connection);

        command.Parameters.Add(new OdbcParameter("title", OdbcType.Text, 0, "title")).Value = title;
        command.Parameters.Add(new OdbcParameter("content", OdbcType.Text, 0, "content")).Value = content;
        command.Parameters.Add(new OdbcParameter("category", OdbcType.VarChar, 100, "title")).Value = category;
        command.Parameters.Add(new OdbcParameter("author", OdbcType.Text, 0, "AuthorAndDate")).Value = author;
        command.Parameters.Add(new OdbcParameter("data", OdbcType.Image, 0, "image")).Value = imgbin;

        connection.Open();
        int numRowsAffected = command.ExecuteNonQuery();
        connection.Close();

        return numRowsAffected;


    }

    protected void selectChanged(object sender, EventArgs e)
    {
        //string MyConString = ConfigurationSettings.AppSettings["connectionString"];
        //OdbcConnection connection = new OdbcConnection(MyConString);

        //string list = categoryDrop.SelectedValue;
        //if(list == "photo")
        //{
        //    string sqlCat = "SELECT * FROM category WHERE type =?'" + list + "'";
        //    OdbcCommand command = new OdbcCommand(sqlCat, connection);
            
        //    OdbcDataAdapter adapter = new OdbcDataAdapter(command);
        //    DataTable ds = new DataTable();
        //    adapter.Fill(ds);
        //    categoryDrop.DataSource = ds;
        //    categoryDrop.DataBind();

        //}
    }



}
