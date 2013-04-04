using System;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.Odbc;
using System.Web.Security;


public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "True";

        }

        protected void submit(object sender, EventArgs e)
        {
          
            if (Page.IsValid) //save the image
            {

                string userName = userId.Text;
                string passWord = password.Value;
                string eMail = email.Value;
                string support = supporter.Value;
             

                if (supporter.Checked)
                {
                    support = "Supporter";
                }
                else 
                {
                    support = "Member"; 
                }

                validation();
                if (Label1.Text == "True")
                {
                    int RowsAffected = SaveToDB(userName, passWord, eMail, support);

                    if (RowsAffected > 0)
                    {
                        ClientScriptManager cs = Page.ClientScript;
                        cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('./default.aspx');", true);
                        cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Registration Successful');", true);
                    }
                }
                else
                {
                }
              




            }
        }
        private int SaveToDB(string userName, string passWord, string eMail, string support)
        {
            
            //use the web.config to store the connection string
            string MyConString = ConfigurationSettings.AppSettings["connectionString"];
            OdbcConnection connection = new OdbcConnection(MyConString);



            OdbcCommand command = new OdbcCommand("INSERT INTO profile (MEMBER_NAME, MEMBER_PWD, EMAIL , MEMBER_ROLE) VALUES ( ?, ?, ?, ?)", connection);

            command.Parameters.Add(new OdbcParameter("username", OdbcType.VarChar, 50, "MEMBER_NAME")).Value = userName;
            command.Parameters.Add(new OdbcParameter("password", OdbcType.VarChar, 50, "MEMBER_PWD")).Value = passWord;
            command.Parameters.Add(new OdbcParameter("email", OdbcType.VarChar, 50, "EMAIL")).Value = eMail;
            command.Parameters.Add(new OdbcParameter("support", OdbcType.VarChar, 50, "MEMBER_ROLE")).Value = support;

           
            //OdbcParameter param0 = new OdbcParameter("username", OdbcType.VarChar, 30);
            //param0.Value = userName;
            //command.Parameters.Add(param0);
            

            //OdbcParameter param1 = new OdbcParameter("password", OdbcType.VarChar, 30);
            //param1.Value = passWord;
            //command.Parameters.Add(param1);

            //OdbcParameter param2 = new OdbcParameter("email", OdbcType.VarChar, 30);
            //param2.Value = eMail;
            //command.Parameters.Add(param2);

            //OdbcParameter param3 = new OdbcParameter("support", OdbcType.VarChar, 10);
            //param3.Value = support;
            //command.Parameters.Add(param3);

            connection.Open();
            int numRowsAffected = command.ExecuteNonQuery();
            connection.Close();

            return numRowsAffected;


        }

        protected void checkName_Click(object sender, EventArgs e)
        {

            validation();

        }

        private void validation()
        {
            string MyConString = ConfigurationSettings.AppSettings["connectionString"];
            OdbcConnection connection = new OdbcConnection(MyConString);



            OdbcCommand command = new OdbcCommand("SELECT seq FROM profile WHERE (MEMBER_NAME=?)", connection);
            command.Parameters.Add(new OdbcParameter("userName", OdbcType.VarChar, 50, "MEMBER_NAME")).Value = userId.Text;

            connection.Open();

            if (command.ExecuteScalar() != null)
            {
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('./RegisterUser.aspx');", true);
                cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('This username has been taken');", true);
                command.ExecuteNonQuery();
                connection.Close();
                Label1.Text = "False";


            }
           


            
            
            
        }
 
}

