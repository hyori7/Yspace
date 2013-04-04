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

namespace yspace.board
{
    public partial class Board_Delete : System.Web.UI.Page
    {
       public int seq = 0;
       public string user = "admin";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //삭제하기 
            seq = int.Parse(Request.QueryString["seq"].ToString());
            string connection = ConfigurationSettings.AppSettings["ConnectionString"];
            OdbcConnection dbCon = new OdbcConnection(connection);


            dbCon.Open();
            string sql = "delete from Board where seq='" + seq + "' and password='" + Session["USER_PWD"].ToString() + "' or seq= '" + seq + "' and manager= '" + Session["USER_NAME"].ToString() + "'";

            OdbcCommand cmd = new OdbcCommand(sql, dbCon);
            cmd.ExecuteNonQuery();
            dbCon.Close();
            Response.Redirect("Board_list.aspx");
          
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Board_list.aspx");
        }
    }
}
