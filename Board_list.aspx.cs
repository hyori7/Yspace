using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//네임스페이스 추가
using System.Web.SessionState;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Data.Odbc;

namespace yspace
{

    public partial class WebForm18 : System.Web.UI.Page
    {

        public string flash;
        int total;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindData();
                load_list();

            }
        }


        void BindData()
        {
            try
            {
                string workerName = Session["USER_ID"].ToString();

                string connection = ConfigurationSettings.AppSettings["ConnectionString"];
                OdbcConnection dbCon = new OdbcConnection(connection);

                dbCon.Open();
                string sql = "select count(*) from Board";
                OdbcCommand cmd = new OdbcCommand(sql, dbCon);
                cmd.CommandText = "select * from Board order by headnum DESC, depth ASC";
                OdbcDataAdapter dbAdap = new OdbcDataAdapter(cmd);
                DataSet ds = new DataSet();
                dbAdap.Fill(ds);

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch
            {
            }
        }

        public void load_list()
        {
            try
            {
                string workerName = "admin"; //Session["USER_ID"].ToString();

                string connection = ConfigurationSettings.AppSettings["ConnectionString"];
                OdbcConnection dbCon = new OdbcConnection(connection);

                dbCon.Open();
                string sql = "select count(*) from Board";
                OdbcCommand cmd = new OdbcCommand(sql, dbCon);

                total = int.Parse(cmd.ExecuteScalar().ToString());

                cmd.CommandText = "select * from Board order by headnum DESC, depth ASC";
                OdbcDataAdapter dbAdap = new OdbcDataAdapter(cmd);
                DataSet ds = new DataSet();
                dbAdap.Fill(ds);
                dbAdap.Update(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                dbCon.Close();
            }
            catch { }


        }

        public string title(string subject, string depth)
        {
            //리플일경우 리플이미지 달리고 등등.. 하는 구문
            int d = int.Parse(depth) + 1;
            string blank = "&nbsp;<img src=\"images/old_head.gif\" border=0>&nbsp;&nbsp;";
            if (depth != "0")
            {
                blank = "";
                for (int i = 1; i < d; i++)
                {
                    blank = blank + "&nbsp;&nbsp;&nbsp;";
                }
                blank = blank + "<img src=\"images/reply_head.gif\" border=0>&nbsp;&nbsp;";
            }
            if (subject.Length > 20)
            {
                subject = subject.Remove(20, subject.Length - 20);
                subject = subject + "...";
            }
            return blank + subject;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            //search 
            try
            {

                string connection = ConfigurationSettings.AppSettings["ConnectionString"];
                OdbcConnection dbCon = new OdbcConnection(connection);

                dbCon.Open();
                string sql = "select count(*) from Board";
                OdbcCommand cmd = new OdbcCommand(sql, dbCon);


                total = int.Parse(cmd.ExecuteScalar().ToString());

                //search func
                if (chkName.Checked == true)
                {
                    //sql = "select name from bygem_board_"+boardname+ " Like '%" +txtSearch.Text + "%'";
                    sql = " name like '%" + txtSearch.Text + "%'";
                }
                if (chkSubject.Checked == true)
                {
                    sql = " subject like '%" + txtSearch.Text + "%'";
                }
                if (chkMemo.Checked == true)
                {
                    sql = " memo like '%" + txtSearch.Text + "%'";
                }

                //cmd.CommandText =  sql+ " order by headnum DESC,depth";
                cmd.CommandText = "select * from Board where" + sql + "order by seq DESC,depth";

                //"select * from bygem_board_free where name like '%ca%' order by headnum DESC,depth";
                //"select * from bygem_board_"+boardname+" where" +sql+ "order by headnum DESC,depth";
                OdbcDataAdapter dbAdap = new OdbcDataAdapter(cmd);
                DataSet ds = new DataSet();
                dbAdap.Fill(ds);

                dbAdap.Update(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                dbCon.Close();
            }
            catch
            {
                string script;
                script = "<script>alert('search failed.')</script>";
                this.RegisterStartupScript("error", script);

            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            BindData();
        }
    }

}