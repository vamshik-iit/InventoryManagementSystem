using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace InventoryManagementDB
{
    public partial class Register : System.Web.UI.Page
    {
        DBClass DBClass = new DBClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void LibraryRegisterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "";

                int newcstid = DBClass.GetMaxIDCount("Customer", "CID");

                query = "insert into Customer values(" + newcstid + ",'" + FirstName.Text + "','" + CAddress.Text + "','" + Email.Text + "','" + Password.Text + "','0')";




                if (DBClass.InsertData(query))
                {
                    FirstName.Text = "";
                    CAddress.Text = "";
                    Email.Text = "";
     
                    Password.Text = "";
      
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Registered, Please Login')", true);

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed, Please try again or contact admin')", true);

                }



            }
            catch (Exception ex)
            {

            }
        }




    }
}