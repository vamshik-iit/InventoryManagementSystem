using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementDB
{
    public partial class Login : System.Web.UI.Page
    {
        DBClass DBClass = new DBClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void LibraryLoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string user = UserName.Text;
                string password = Password.Text;
                DataTable LoginTable = new DataTable();

                string query = "";
                query = "select * from Customer where EmailAddress='" + user + "' and Password='" + password + "'";
                LoginTable = DBClass.FetchData(query);
                if (LoginTable.Rows.Count > 0)
                {
                    Session["UserID"] = LoginTable.Rows[0]["CID"].ToString();
                    Session["Name"] = LoginTable.Rows[0]["CName"].ToString();
                    if(LoginTable.Rows[0]["IsAdmin"].ToString() == "1")
                    {
                        Session["Role"] = "Admin";
                    }
                    else
                    {
                        Session["Role"] = "User";
                    }
                    Session["Email"] = LoginTable.Rows[0]["EmailAddress"].ToString();
                    Session["Cart"] = "";
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Login')", true);

                }

            }
            catch (Exception ex)
            {

            }
        }



    }
}