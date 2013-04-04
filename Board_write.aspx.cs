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
    public partial class Board_Write : System.Web.UI.Page
    {
        public string flash;
        int total;
        int seq;
        // string mode;
        string mode = "new";

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
            
            if (!IsPostBack)
            {

                try
                {
                    mode = Request.QueryString["mode"].ToString();
                    seq = int.Parse(Request.QueryString["seq"].ToString());
                    txtSubject.Text = seq.ToString();

                    if (mode == "edit")
                    {
                        string connection = ConfigurationSettings.AppSettings["ConnectionString"];
                        OdbcConnection dbCon = new OdbcConnection(connection);

                        dbCon.Open();
                        string sql = "select * from Board where seq='" + seq + "'";
                        OdbcCommand cmd = new OdbcCommand(sql, dbCon);
                        OdbcDataReader reader = cmd.ExecuteReader();

                        reader.Read();
                        // txtSubject.Text = "modeget";
                        txtSubject.Text = reader["subject"].ToString();
                        memo_txt.Text = reader["memo"].ToString();

                        reader.Close();

                        dbCon.Close();
                    }
                }
                catch
                {

                }
            }
        }
        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            write_event();
        }

        public void write_event()
        {
            try
            {
                mode = Request.QueryString["mode"].ToString();
            }
            catch { }

            if (mode == "new")
            {
                string connection = ConfigurationSettings.AppSettings["ConnectionString"];
                OdbcConnection dbCon = new OdbcConnection(connection);

                dbCon.Open();
                string sql = "select max(headnum) from Board";
                OdbcCommand cmd = new OdbcCommand(sql, dbCon);

                int headnum = 1;
                if (cmd.ExecuteScalar().ToString() != "")
                {
                    headnum = int.Parse(cmd.ExecuteScalar().ToString()) + 1;
                }
                cmd.CommandText = "insert into Board (headnum, depth, memo, password, name, subject, hit) values (?, ?, ?, ?, ?, ?, ?)";

                //cmd.Parameters.Add(new OdbcParameter("headnum", OdbcType.Int, 4, "headnum")).Value = headnum;
                //cmd.Parameters.Add(new OdbcParameter("depth", OdbcType.Int, 4, "depth")).Value = 0;
                //cmd.Parameters.Add(new OdbcParameter("memo", OdbcType.Text, 0, "memo")).Value = memo_txt.Text;
                //cmd.Parameters.Add(new OdbcParameter("password", OdbcType.VarChar, 20, "password")).Value = Session["USER_PWD"].ToString();
                //cmd.Parameters.Add(new OdbcParameter("name", OdbcType.VarChar, 50, "name")).Value = Session["USER_ID"].ToString();
                //cmd.Parameters.Add(new OdbcParameter("subject", OdbcType.VarChar, 255, "subject")).Value = txtSubject.Text;
                //cmd.Parameters.Add(new OdbcParameter("hit", OdbcType.Int, 4, "hit")).Value = 0;

                cmd.Parameters.Add("@headnum", OdbcType.Int, 4);
                cmd.Parameters.Add("@depth", OdbcType.Int, 4);
                cmd.Parameters.Add("@memo", OdbcType.Text);
                cmd.Parameters.Add("@password", OdbcType.VarChar, 20);
                cmd.Parameters.Add("@name", OdbcType.VarChar, 50);
                cmd.Parameters.Add("@subject", OdbcType.VarChar, 255);
                cmd.Parameters.Add("@hit", OdbcType.Int, 4);


                cmd.Parameters["@headnum"].Value = headnum;
                cmd.Parameters["@depth"].Value = 0;
                cmd.Parameters["@memo"].Value = memo_txt.Text;
                cmd.Parameters["@password"].Value = Session["USER_PWD"].ToString();
                cmd.Parameters["@name"].Value = Session["USER_ID"].ToString();
                cmd.Parameters["@subject"].Value = txtSubject.Text;
                cmd.Parameters["@hit"].Value = 0;


                cmd.ExecuteNonQuery();
                dbCon.Close();
                Response.Redirect("Board_list.aspx");
            }
            if (mode == "edit")
            {
                seq = int.Parse(Request.QueryString["seq"].ToString());


                string connection = ConfigurationSettings.AppSettings["ConnectionString"];
                OdbcConnection dbCon = new OdbcConnection(connection);

                dbCon.Open();
                string sql = "update Board set memo=@memo, subject=@subject where seq='" + seq + "' and name='" + Session["USER_ID"].ToString() + "'";
                OdbcCommand cmd = new OdbcCommand(sql, dbCon);

                cmd.Parameters.Add("@memo", OdbcType.Text);
                cmd.Parameters.Add("@subject", OdbcType.VarChar, 255);


                cmd.Parameters["@memo"].Value = memo_txt.Text;
                cmd.Parameters["@subject"].Value = txtSubject.Text;

                cmd.ExecuteNonQuery();
                dbCon.Close();

                Response.Redirect("Board_list.aspx");
            }

            if (mode == "reply")
            {
                seq = int.Parse(Request.QueryString["seq"].ToString());


                string connection = ConfigurationSettings.AppSettings["ConnectionString"];
                OdbcConnection dbCon = new OdbcConnection(connection);

                dbCon.Open();
                string sql = "select headnum, depth from Board where seq='" + seq + "'";
                OdbcCommand cmd = new OdbcCommand(sql, dbCon);
                OdbcDataReader reader = cmd.ExecuteReader();
                reader.Read();

                int headnum = int.Parse(reader["headnum"].ToString());
                int depth = int.Parse(reader["depth"].ToString()) + 1;
                reader.Close();
                cmd.CommandText = "insert into Board (headnum, depth, memo, password, name, subject, hit) values (?, ?, ?, ?, ?, ?, ?)";

                //cmd.Parameters.Add(new OdbcParameter("headnum", OdbcType.Int, 4, "headnum")).Value = headnum;
                //cmd.Parameters.Add(new OdbcParameter("depth", OdbcType.Int, 4, "depth")).Value = 0;
                //cmd.Parameters.Add(new OdbcParameter("memo", OdbcType.Text, 0, "memo")).Value = memo_txt.Text;
                //cmd.Parameters.Add(new OdbcParameter("password", OdbcType.VarChar, 20, "password")).Value = Session["USER_PWD"].ToString();
                //cmd.Parameters.Add(new OdbcParameter("name", OdbcType.VarChar, 20, "name")).Value = Session["USER_ID"].ToString();
                //cmd.Parameters.Add(new OdbcParameter("subject", OdbcType.VarChar, 255, "subject")).Value = txtSubject.Text;
                //cmd.Parameters.Add(new OdbcParameter("hit", OdbcType.Int, 4, "hit")).Value = 0;

                cmd.Parameters.Add("@headnum", OdbcType.Int, 4);
                cmd.Parameters.Add("@depth", OdbcType.Int, 4);
                cmd.Parameters.Add("@memo", OdbcType.Text);
                cmd.Parameters.Add("@password", OdbcType.VarChar, 20);
                cmd.Parameters.Add("@name", OdbcType.VarChar, 20);
                cmd.Parameters.Add("@subject", OdbcType.VarChar, 255);
                cmd.Parameters.Add("@hit", OdbcType.Int, 4);
                //cmd.Parameters.Add("@file_name1", System.Data.SqlDbType.VarChar, 255);
                //cmd.Parameters.Add("@file_size1", System.Data.SqlDbType.VarChar, 255);

                cmd.Parameters["@headnum"].Value = headnum;
                cmd.Parameters["@depth"].Value = depth;
                cmd.Parameters["@memo"].Value = memo_txt.Text;
                cmd.Parameters["@password"].Value = Session["USER_PWD"].ToString();
                cmd.Parameters["@name"].Value = Session["USER_ID"].ToString();
                cmd.Parameters["@subject"].Value = txtSubject.Text;
                //cmd.Parameters["@use_html"].Value = "1";
                cmd.Parameters["@hit"].Value = 0;

                cmd.ExecuteNonQuery();
                dbCon.Close();

                Response.Redirect("Board_list.aspx");
            }

        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Board_list.aspx");
        }
    }
}
