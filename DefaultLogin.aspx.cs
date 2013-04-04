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
    public partial class WebForm20 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["USER_ID"] != null)
            //{
            //    namelbl2.Text = Session["USER_ID"].ToString() + "Welcom.";


            //}
           
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("./RegisterUser.aspx");
        }
        protected void btnLoginOK_Click(object sender, EventArgs e)
        {
            string connection = ConfigurationSettings.AppSettings["connectionString"];
            OdbcConnection dbCon = new OdbcConnection(connection);
            string sql = "SELECT seq FROM profile WHERE (MEMBER_NAME = @userid) AND (MEMBER_PWD = @pwd)";
            OdbcCommand dbCmd = new OdbcCommand(sql, dbCon);
            dbCmd.Parameters.Add("@userid", OdbcType.VarChar, 50, "MEMBER_NAME");
            dbCmd.Parameters.Add("@pwd", OdbcType.VarChar, 30, "MEMBER_PWD");

            dbCon.Open();
            dbCmd.Parameters["@userid"].Value = txtName.Text;
            dbCmd.Parameters["@pwd"].Value = txtPwd.Text;


            if (dbCmd.ExecuteScalar() == null)
            {

                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('./DefaultLogin.aspx');", true);
                cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Incorrect ID/PW');", true);


                dbCmd.ExecuteNonQuery();
                dbCon.Close();
            }
            else
            {

                dbCmd.CommandText = "select * from profile where (MEMBER_NAME = @userid)";
                OdbcDataReader reader = dbCmd.ExecuteReader();
                reader.Read();
//add session
                Session.Add("USER_ID", txtName.Text);
                Session.Add("USER_NAME", reader["MEMBER_NAME"].ToString());
                Session.Add("USER_PWD", reader["MEMBER_PWD"].ToString());

                reader.Close();
                dbCmd.ExecuteNonQuery();
                dbCon.Close();

                Response.Redirect("./Board_list.aspx");
                //if (Session["USER_ID"] != null)
                //{
                //    namelbl2.Text = Session["USER_ID"].ToString() + "Welcom.";

                //    //hide login
                //    LoginForm.Visible = false;

                //    //dis login
                //    loginchk.Visible = true;


                //}

            }
        }
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect(Request.RawUrl);
        }
        protected void GotoBoar_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Board_list.aspx");
        }
    }
}
