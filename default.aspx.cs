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



public partial class Homepage : System.Web.UI.Page
    {
 
        protected void Page_Load(object sender, EventArgs e)
        {


            int ImageId = System.Convert.ToInt32(Request.QueryString["id"]);

            string MyConString = ConfigurationSettings.AppSettings["connectionString"];

            OdbcConnection connection = new OdbcConnection(MyConString);


            string sqlText = "select data, type, description FROM image WHERE id = " + ImageId;
            string countQuery = "update image set count = (count +1) where id = " + ImageId;
            OdbcCommand command = new OdbcCommand(sqlText, connection);
            OdbcCommand countCommand = new OdbcCommand(countQuery, connection);
            connection.Open();
            countCommand.ExecuteNonQuery();
            OdbcDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);


            if (dr.Read())
            {

                Response.ContentType = dr["type"].ToString();
                Response.BinaryWrite((byte[])dr["data"]);
          


            }
            connection.Close();

            //home notice
            string sqlNews = "select title, content, date FROM news WHERE id = 0";
            OdbcCommand commandNews = new OdbcCommand(sqlNews, connection);
            connection.Open();
            OdbcDataReader dr2 = commandNews.ExecuteReader(CommandBehavior.CloseConnection);

            if (dr2.Read())
            {
                
                    Day.Text = dr2["date"].ToString();
                    noticeTitle.Text = dr2["title"].ToString();
                    noticeContent.Text = dr2["content"].ToString();//.Replace(Environment.NewLine, "<BR/>");
    
            }
            connection.Close();

            //home news
            string sqlNews1 = "select title, content, date FROM latestnews ORDER BY date DESC LIMIT 0,1";
            OdbcCommand commandNews1 = new OdbcCommand(sqlNews1, connection);
            connection.Open();
            OdbcDataReader dr3 = commandNews1.ExecuteReader(CommandBehavior.CloseConnection);

            if (dr3.Read())
            {

                Day2.Text = dr3["date"].ToString();
                newsTitle.Text = dr3["title"].ToString();
                newsContent.Text = dr3["content"].ToString();//.Replace(Environment.NewLine, "<BR/>");

            }
            connection.Close();

            //home archive
           
            string sqlNews2 = "select title, content, date FROM news WHERE id = 1";
            OdbcCommand commandNews2 = new OdbcCommand(sqlNews2, connection);
            connection.Open();
            OdbcDataReader dr4 = commandNews2.ExecuteReader(CommandBehavior.CloseConnection);

            if (dr4.Read())
            {
               
                Day3.Text = dr4["date"].ToString();
                archiveTitle.Text = dr4["title"].ToString();
                archiveContent.Text = dr4["content"].ToString();//.Replace(Environment.NewLine, "<BR/>");
               

            }
            connection.Close();
          
            //image
            string selectSQL = "SELECT id, name, description FROM image WHERE approval = 1  ORDER BY date DESC LIMIT 0,6";
            OdbcCommand cmd1 = new OdbcCommand(selectSQL, connection);
            OdbcDataAdapter adapter = new OdbcDataAdapter(cmd1);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            DataList1.DataSource = ds;
            DataList1.DataBind();

            string selectNews = "SELECT * FROM news WHERE id = 0";
            OdbcCommand cmd2 = new OdbcCommand(selectNews, connection);
           

        }
    }


