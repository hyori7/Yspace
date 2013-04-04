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
    public partial class Board_view : System.Web.UI.Page
    {
        public int seq = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                seq = int.Parse(Request.QueryString["seq"].ToString());

                string Workername = "admin";//Session["USER_ID"].ToString();

                string connection = ConfigurationSettings.AppSettings["ConnectionString"];
                OdbcConnection dbCon = new OdbcConnection(connection);

                dbCon.Open();
                string sql = "select * from Board where seq='" + seq + "'";
                OdbcCommand cmd = new OdbcCommand(sql, dbCon);
                OdbcDataReader reader = cmd.ExecuteReader();
                reader.Read();
                lblName.Text = reader["name"].ToString();
                lblDate.Text = reader["reg_date"].ToString();
                lblHit.Text = reader["hit"].ToString();






                if (Workername != lblName.Text || Workername != "admin")
                {
                   // delbtn.Visible = false ;
                }
                //hlnkFile.Text = reader["file_name1"].ToString();
                //hlnkFile.NavigateUrl = "data/"+seq+"/"+reader["file_name1"].ToString();
                lblTitle.Text = reader["subject"].ToString();

                lblMemo.Text = reader["memo"].ToString().Replace("\r", "<BR>");



                reader.Close();
                cmd.CommandText = "update Board set hit=hit+1 where seq='" + seq + "'";
                cmd.ExecuteNonQuery();
                dbCon.Close();
            }
            catch { }
        }
    }
}
