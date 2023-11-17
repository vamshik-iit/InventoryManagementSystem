using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementDB
{
    public partial class Contact : Page
    {
        DBClass DB = new DBClass();
        string Query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Loaddata();


            }
            catch(Exception ex)
            {

            }
        }

        protected void Loaddata()
        {
            try
            {

                Query = "select * from ProductCategory";
                DataTable dataTable = new DataTable();
                dataTable = DB.FetchData(Query);
                if (dataTable.Rows.Count > 0)
                {
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void AddCategeory_Click(object sender, EventArgs e)
        {
            try
            {
                int maxval = DB.GetMaxIDCount("ProductCategory", "CategoryID");
                if(maxval > 0)
                {
                    Query = "insert into ProductCategory values(" + maxval + ",'" + CName.Text + "')";
                }
               

                if (DB.InsertData(Query))
                {
                    Loaddata();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wowwww! Success')", true);
                }
                else
                {
                    Loaddata();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Oopssss! Failed')", true);
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void DelCategeory_Click(object sender, EventArgs e)
        {
            try
            {
                Query = "delete from ProductCategory where CategoryName = '" + CName.Text + "'";
                if (DB.InsertData(Query))
                {
                    Loaddata();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wowwww! Success')", true);
                }
                else
                {
                    Loaddata();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Oopssss! Failed/ No Records')", true);
                }
            }
            catch (Exception ex)
            {

            }
        }



        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

            }

        }



    }
}