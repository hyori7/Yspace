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

namespace yspace
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

              

                if (Session["USER_ID"] == null)
                {
                    
                    ClientScriptManager cs = Page.ClientScript;
                    cs.RegisterStartupScript(this.GetType(), "windowClose", "window.location.replace('./DefaultLogin.aspx');", true);
                    cs.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Please login first');", true);
                }
             
                

            }
        }
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();

            Response.Redirect(Request.RawUrl);
        }
    }
}