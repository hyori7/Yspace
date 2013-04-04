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



namespace yspace
{
    public partial class yspace : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            admin.Visible = false;
            if (HttpContext.Current.Session["USER_ROLE"] != null)
            {
                string s = HttpContext.Current.Session["USER_NAME"].ToString();
                userTxt.Text = s;
                string role = HttpContext.Current.Session["USER_ROLE"].ToString();
                if (role == "Admin")
                {
                    admin.Visible = true;
                }
         

            }
            else
            {
                userTxt.Text = "Please Login";
            }

          

        }


        protected void SearchBtn_Clicked(object sender, EventArgs e)
        {
            string search = searchBox.Text.ToString();
            Response.Redirect("search.aspx?searchBox=" + search);


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("./RegisterUser.aspx");
        }
        protected void btnLoginOK_Click(object sender, EventArgs e)
        {
            //string username = txtName.Text;
            // string pwd = txtPwd.Text;
            string connection = ConfigurationSettings.AppSettings["connectionString"];
            OdbcConnection dbCon = new OdbcConnection(connection);
            string sql = "SELECT * FROM profile WHERE MEMBER_NAME = ? AND MEMBER_PWD = ?";
            //string sql = "SELECT * FROM profile WHERE MEMBER_NAME ='" + username + "'AND MEMBER_PWD='" + pwd+"'";
            OdbcCommand dbCmd = new OdbcCommand(sql, dbCon);
            dbCmd.Parameters.Add(new OdbcParameter("userid", OdbcType.VarChar, 50, "MEMBER_NAME")).Value = txtName.Text;
            dbCmd.Parameters.Add(new OdbcParameter("pwd", OdbcType.VarChar, 35, "MEMBER_PWD")).Value = txtPwd.Text;


            dbCon.Open();



            if (dbCmd.ExecuteScalar() == null)
            {

                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('./default.aspx');", true);
                cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Incorrect ID/PW');", true);




            }
            else
            {


                dbCmd.CommandText = "select * from profile where MEMBER_NAME = ?";
                OdbcDataReader reader = dbCmd.ExecuteReader();
                reader.Read();

                //add session
                Session.Add("USER_ID", txtName.Text);
                Session.Add("USER_NAME", reader["MEMBER_NAME"].ToString());
                Session.Add("USER_PWD", reader["MEMBER_PWD"].ToString());
                Session.Add("USER_ROLE", reader["MEMBER_ROLE"].ToString());

                reader.Close();
                dbCon.Close();

                if (HttpContext.Current.Session["USER_ROLE"] != null)
                {
                    string sessionRole = HttpContext.Current.Session["USER_ROLE"].ToString();
                    if (sessionRole == "Admin")
                    {
                        ClientScriptManager cs = Page.ClientScript;
                        cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('./maincontrol.aspx');", true);
                        cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('You have login as Admin');", true);
                        
                    }
                    else
                    {
                        ClientScriptManager cs = Page.ClientScript;
                        cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('./default.aspx');", true);
                        cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('You have login');", true);
                    }
                }




            }


        }

        //if (Session["USER_ID"] != null)
        //{
        //    namelbl2.Text = Session["USER_ID"].ToString() + "Welcom.";

        //    //hide login
        //    LoginForm.Visible = false;

        //    //dis login
        //    loginchk.Visible = true;


        //}



        protected void GotoBoar_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Board_list.aspx");
        }


        protected void Logout(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/default.aspx");
        }

        protected void admin_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/MainControl.aspx");
        }
}
}
