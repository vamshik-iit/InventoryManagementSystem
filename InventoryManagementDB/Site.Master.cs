using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace InventoryManagementDB
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBClass db = new DBClass();

          
        }

        protected void Userlogout_Click(object sender, EventArgs e)
        {
            try
            {
                Session["UserID"] = null;
                Session["Name"] = null;
                Response.Redirect("Login.aspx");
            }
            catch { 

            }
        }
    }
}