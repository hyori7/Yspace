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


public partial class Display : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int ImageId = System.Convert.ToInt32(Request.QueryString["id"]);

        string MyConString = ConfigurationSettings.AppSettings["connectionString"];

        OdbcConnection connection = new OdbcConnection(MyConString);


        string sqlText = "select data, type, description FROM image WHERE approval = 1 AND id = " + ImageId;
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

        string cat1 = "Policing And Security";
        string selectSQL = "SELECT id, name, description FROM image WHERE category = '" + cat1 + "' AND approval = 1 ORDER BY count DESC LIMIT 0,3";
        OdbcCommand cmd1 = new OdbcCommand(selectSQL, connection);
        OdbcDataAdapter adapter = new OdbcDataAdapter(cmd1);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        DataList1.DataSource = ds;
        DataList1.DataBind();


        string cat2 = "Homeless";
        string selectSQL2 = "SELECT id, name, description FROM image WHERE category = '" + cat2 + "' AND approval = 1 ORDER BY count DESC LIMIT 0,3";
        OdbcCommand cmd2 = new OdbcCommand(selectSQL2, connection);
        OdbcDataAdapter adapter2 = new OdbcDataAdapter(cmd2);
        DataSet ds2 = new DataSet();
        adapter2.Fill(ds2);

        DataList2.DataSource = ds2;
        DataList2.DataBind();


        string cat3 = "Speaking Out";
        string selectSQL3 = "SELECT id, name, description FROM image WHERE category = '" + cat3 + "' AND approval = 1 ORDER BY count DESC LIMIT 0,3";
        OdbcCommand cmd3 = new OdbcCommand(selectSQL3, connection);
        OdbcDataAdapter adapter3 = new OdbcDataAdapter(cmd3);
        DataSet ds3 = new DataSet();
        adapter3.Fill(ds3);

        DataList3.DataSource = ds3;
        DataList3.DataBind();


        string cat4 = "Green and Wild Spaces";
        string selectSQL4 = "SELECT id, name, description FROM image WHERE category = '" + cat4 + "' AND approval = 1 ORDER BY count DESC LIMIT 0,3";
        OdbcCommand cmd4 = new OdbcCommand(selectSQL4, connection);
        OdbcDataAdapter adapter4 = new OdbcDataAdapter(cmd4);
        DataSet ds4 = new DataSet();
        adapter4.Fill(ds4);

        DataList4.DataSource = ds4;
        DataList4.DataBind();

        string cat5 = "Hansing Out";
        string selectSQL5 = "SELECT id, name, description FROM image WHERE category = '" + cat5 + "' AND approval = 1 ORDER BY count DESC LIMIT 0,3";
        OdbcCommand cmd5 = new OdbcCommand(selectSQL5, connection);
        OdbcDataAdapter adapter5 = new OdbcDataAdapter(cmd5);
        DataSet ds5 = new DataSet();
        adapter5.Fill(ds5);

        DataList5.DataSource = ds5;
        DataList5.DataBind();

        string cat6 = "Public Art";
        string selectSQL6 = "SELECT id, name, description FROM image WHERE category = '" + cat6 + "' AND approval = 1 ORDER BY count DESC LIMIT 0,3";
        OdbcCommand cmd6 = new OdbcCommand(selectSQL6, connection);
        OdbcDataAdapter adapter6 = new OdbcDataAdapter(cmd6);
        DataSet ds6 = new DataSet();
        adapter6.Fill(ds6);

        DataList6.DataSource = ds6;
        DataList6.DataBind();

        string cat7 = "Signs";
        string selectSQL7 = "SELECT id, name, description FROM image WHERE category = '" + cat7 + "' AND approval = 1 ORDER BY count DESC LIMIT 0,3";
        OdbcCommand cmd7 = new OdbcCommand(selectSQL7, connection);
        OdbcDataAdapter adapter7 = new OdbcDataAdapter(cmd7);
        DataSet ds7 = new DataSet();
        adapter7.Fill(ds7);

        DataList7.DataSource = ds7;
        DataList7.DataBind();

        string cat8 = "Community Access Places";
        string selectSQL8 = "SELECT id, name, description FROM image WHERE category = '" + cat8 + "' AND approval = 1 ORDER BY count DESC LIMIT 0,3";
        OdbcCommand cmd8 = new OdbcCommand(selectSQL8, connection);
        OdbcDataAdapter adapter8 = new OdbcDataAdapter(cmd8);
        DataSet ds8 = new DataSet();
        adapter8.Fill(ds8);

        DataList8.DataSource = ds8;
        DataList8.DataBind();

        string cat9 = "City Spaces";
        string selectSQL9 = "SELECT id, name, description FROM image WHERE category = '" + cat9 + "' AND approval = 1 ORDER BY count DESC LIMIT 0,3";
        OdbcCommand cmd9 = new OdbcCommand(selectSQL9, connection);
        OdbcDataAdapter adapter9 = new OdbcDataAdapter(cmd9);
        DataSet ds9 = new DataSet();
        adapter9.Fill(ds9);

        DataList9.DataSource = ds9;
        DataList9.DataBind();

        string cat10 = "Being Active";
        string selectSQL10 = "SELECT id, name, description FROM image WHERE category = '" + cat10 + "' AND approval = 1 ORDER BY count DESC LIMIT 0,3";
        OdbcCommand cmd10 = new OdbcCommand(selectSQL10, connection);
        OdbcDataAdapter adapter10 = new OdbcDataAdapter(cmd10);
        DataSet ds10 = new DataSet();
        adapter10.Fill(ds10);

        DataList10.DataSource = ds10;
        DataList10.DataBind();

        string cat11 = "Favourite Spaces";
        string selectSQL11 = "SELECT id, name, description FROM image WHERE category = '" + cat11 + "' AND approval = 1 ORDER BY count DESC LIMIT 0,3";
        OdbcCommand cmd11 = new OdbcCommand(selectSQL11, connection);
        OdbcDataAdapter adapter11 = new OdbcDataAdapter(cmd11);
        DataSet ds11 = new DataSet();
        adapter11.Fill(ds11);

        DataList11.DataSource = ds11;
        DataList11.DataBind();

        string cat12 = "Unfavourite Spaces";
        string selectSQL12 = "SELECT id, name, description FROM image WHERE category = '" + cat12 + "' AND approval = 1 ORDER BY count DESC LIMIT 0,3";
        OdbcCommand cmd12 = new OdbcCommand(selectSQL12, connection);
        OdbcDataAdapter adapter12 = new OdbcDataAdapter(cmd12);
        DataSet ds12 = new DataSet();
        adapter12.Fill(ds12);

        DataList12.DataSource = ds12;
        DataList12.DataBind();

    }


  

        protected void police_Click(object sender, EventArgs e)
        {
            string cat = "Policing And Security";
            Response.Redirect("~/Category.aspx?cat=" + cat);

        }

        protected void homeless_Click(object sender, EventArgs e)
        {
            string cat = "Homeless";
            Response.Redirect("~/Category.aspx?cat=" + cat);
        }
        protected void speak_Click(object sender, EventArgs e)
        {
            string cat = "Speak Out";
            Response.Redirect("~/Category.aspx?cat=" + cat);
        }
        protected void green_Click(object sender, EventArgs e)
        {
            string cat = "Green and Wild Spaces";
            Response.Redirect("~/Category.aspx?cat=" + cat);
        }
        protected void hansing_Click(object sender, EventArgs e)
        {
            string cat = "Hansing Out";
            Response.Redirect("~/Category.aspx?cat=" + cat);
        }
        protected void art_Click(object sender, EventArgs e)
        {
            string cat = "Public Art";
            Response.Redirect("~/Category.aspx?cat=" + cat);
        }
        protected void sign_Click(object sender, EventArgs e)
        {
            string cat = "Signs";
            Response.Redirect("~/Category.aspx?cat=" + cat);
        }
        protected void community_Click(object sender, EventArgs e)
        {
            string cat = "Community Access Places";
            Response.Redirect("~/Category.aspx?cat=" + cat);
        }
        protected void city_Click(object sender, EventArgs e)
        {
            string cat = "City Spaces";
            Response.Redirect("~/Category.aspx?cat=" + cat);
        }
        protected void active_Click(object sender, EventArgs e)
        {
            string cat = "Being Active";
            Response.Redirect("~/Category.aspx?cat=" + cat);
        }
        protected void favourite_Click(object sender, EventArgs e)
        {
            string cat = "Favourite Spaces";
            Response.Redirect("~/Category.aspx?cat=" + cat);
        }
        protected void unfavourite_Click(object sender, EventArgs e)
        {
            string cat = "Unfavourite Spaces";
            Response.Redirect("~/Category.aspx?cat=" + cat);
        }
        protected void upload_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Member/Upload.aspx");
        }
}



