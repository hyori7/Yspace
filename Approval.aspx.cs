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

public partial class Approval : System.Web.UI.Page
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

        if (!IsPostBack)
        {
            int ImageId = System.Convert.ToInt32(Request.QueryString["photoID"]);

            string MyConString = ConfigurationSettings.AppSettings["connectionString"];

            OdbcConnection connection = new OdbcConnection(MyConString);


            try
            {
                connection.Open();
                string approve = "SELECT * FROM image WHERE id='" + ImageId + "'";
                OdbcCommand command = new OdbcCommand(approve, connection);
                OdbcDataReader reader = command.ExecuteReader();
                reader.Read();
                imageID.Text = reader["id"].ToString();
                categoryDrop.SelectedValue = reader["category"].ToString();
                nameTxt.Text = reader["name"].ToString();
                descriptionTxt.Text = reader["description"].ToString().Replace(Environment.NewLine, "<BR/>");
                reader.Close();
                connection.Close();
            }
            catch { }
        }

    }
    protected void update_Click(object sender, EventArgs e)
    {

        
            string name = nameTxt.Text;
            string approval = DropDownList1.SelectedValue;
            string category = categoryDrop.SelectedValue;
            string description = descriptionTxt.Text;

            int RowsAffected = SaveToDB(name, description, approval, category);
            if (RowsAffected > 0)
            {

                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('./Control.aspx');", true);
                cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Update Successful');", true); ;
            }
            else
            {
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('./Control.aspx');", true);
                cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Invalid Input');", true); ;
            }

        
    }

    private int SaveToDB(string name, string description, string approval, string category)
    {
        int ImageId = System.Convert.ToInt32(Request.QueryString["photoID"]);
        //use the web.config to store the connection string
        string MyConString = ConfigurationSettings.AppSettings["connectionString"];
        OdbcConnection connection = new OdbcConnection(MyConString);
       
        string updateImage = "UPDATE image SET name=?, description=?, approval=?, category=? WHERE id='" + ImageId + "'";
        OdbcCommand commandImage = new OdbcCommand(updateImage, connection);

        commandImage.Parameters.Add(new OdbcParameter("name", OdbcType.VarChar, 30, "name")).Value = name;
        commandImage.Parameters.Add(new OdbcParameter("description", OdbcType.Text, 0, "description")).Value = description;
        commandImage.Parameters.Add(new OdbcParameter("approval", OdbcType.VarChar, 30, "approval")).Value = approval;
        commandImage.Parameters.Add(new OdbcParameter("category", OdbcType.VarChar, 100, "category")).Value = category;

        connection.Open();
        int numRowsAffected = commandImage.ExecuteNonQuery();
        connection.Close();

        return numRowsAffected;


    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Control.aspx");
    }
}
