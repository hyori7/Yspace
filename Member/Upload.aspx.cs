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


public partial class Member_Upload : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (HttpContext.Current.Session["USER_ROLE"] != null)
        {
            string s = HttpContext.Current.Session["USER_ROLE"].ToString();
            if (s != "Member" && s != "Supporter" && s != "Admin")
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

        string photo = "photo";
        string sqlText = "select name, id FROM category WHERE type = '" + photo +"'";
        OdbcCommand command = new OdbcCommand(sqlText, connection);
        connection.Open();
       
        OdbcDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);


        if (dr.Read())
        {

            Response.ContentType = dr["name"].ToString();


        }
        
        connection.Close();


       
    }

    public void UploadBtn_Click(object sender, System.EventArgs e)
    {
       
        if (Page.IsValid) //save the image
        {
            Stream imgStream = UploadFile.PostedFile.InputStream;
            int imgLen = UploadFile.PostedFile.ContentLength;
            string imgContentType = UploadFile.PostedFile.ContentType;
            string imgName = txtImgName.Value;
            string category = categoryDrop.SelectedValue;
            string description = descriptionBox.Text;
            string approval = "0";
            
            //System.Drawing.Image imgInput = System.Drawing.Image.FromStream(imgStream);
            //ImageFormat fmtImageFormat = imgInput.RawFormat; 
            

         

            
            if ("".Equals(txtImgName.Value))
            {
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('./upload.aspx');", true);
                cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Please enter a name for this image');", true);
                return;
            }
            if ("".Equals(UploadFile.Value))
            {
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('./upload.aspx');", true);
                cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Please upload an image here');", true);
                return;
            }
            if (UploadFile.Value.IndexOf(".jpg") > 0 || UploadFile.Value.IndexOf(".JPG") > 0 || UploadFile.Value.IndexOf(".JPEG") > 0 || UploadFile.Value.IndexOf(".jpeg") > 0)
            {
                byte[] imgBinaryData = new byte[imgLen];
                int n = imgStream.Read(imgBinaryData, 0, imgLen);
                System.Drawing.Image image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(imgBinaryData));
                int width = image.Width;
                int heigth = image.Height;
                int newWidth;
                int newHeigth;

                if (width >= heigth)
                {
                    if (width > 640)
                    {
                        newWidth = Convert.ToInt32(640);
                    }
                    else
                    {
                        newWidth = width;
                    }

                    if (heigth > 480)
                    {
                        newHeigth = Convert.ToInt32(480);
                    }
                    else
                    {
                        newHeigth = heigth;
                    }

                }

                else
                {
                    if (width > 480)
                    {
                        newWidth = Convert.ToInt32(480);
                    }
                    else
                    {
                        newWidth = width;
                    }

                    if (heigth > 640)
                    {
                        newHeigth = Convert.ToInt32(640);
                    }
                    else
                    {
                        newHeigth = heigth;
                    }
                }


                //System.Drawing.Image bitmap = new System.Drawing.Bitmap(newWidth, newHeigth);
                Bitmap bitmap = new Bitmap(image, newWidth, newHeigth);
                MemoryStream ms = new MemoryStream();
                ImageFormat formatOfImage = System.Drawing.Imaging.ImageFormat.Jpeg;

                bitmap.Save(ms, formatOfImage);
                byte[] imgBinaryData1 = ms.ToArray();
                image.Dispose();
                bitmap.Dispose();

                int RowsAffected = SaveToDB(imgName, imgBinaryData1, imgContentType, category, description, approval);
                if (RowsAffected > 0)
                {
                    //Response.Write("<BR>The Image was saved");
                    // Response.Redirect("~/Display.aspx");
                    ClientScriptManager cs = Page.ClientScript;
                    cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('../display.aspx');", true);
                    cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Photo has been uploaded');", true);
                }
                else
                {
                    ClientScriptManager cs = Page.ClientScript;
                    cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('../display.aspx');", true);
                    cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Invalid Input');", true);
                }
            }
            else
            {
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('./upload.aspx');", true);
                cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Image has to be in JPEG .jpg or .JPG format');", true);
            }
            

        }
    }


    private int SaveToDB(string imgName, byte[] imgbin, string imgcontenttype, string category, string description, string approval)
    {
        //use the web.config to store the connection string
        string MyConString = ConfigurationSettings.AppSettings["connectionString"];
        OdbcConnection connection = new OdbcConnection(MyConString);

       
        OdbcCommand command = new OdbcCommand("INSERT INTO image (name,data,type, category, description, approval) VALUES ( ?, ? , ?, ?, ?, ?)", connection);

        command.Parameters.Add(new OdbcParameter("name", OdbcType.VarChar, 50, "name")).Value = imgName;
        command.Parameters.Add(new OdbcParameter("data", OdbcType.Image, 0, "data")).Value = imgbin;
        command.Parameters.Add(new OdbcParameter("type", OdbcType.VarChar, 50, "type")).Value = imgcontenttype;
        command.Parameters.Add(new OdbcParameter("category", OdbcType.VarChar, 100, "category")).Value = category;
        command.Parameters.Add(new OdbcParameter("description", OdbcType.Text, 0, "description")).Value = description;
        command.Parameters.Add(new OdbcParameter("approval", OdbcType.VarChar, 5, "approval")).Value = approval;

        connection.Open();
        int numRowsAffected = command.ExecuteNonQuery();
        connection.Close();

        return numRowsAffected;


    }
}
