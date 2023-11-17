using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementDB
{
    public partial class ViewProducts : System.Web.UI.Page
    {
        DBClass DB = new DBClass();
        string Query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    if(Session["UserID"] == null)
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
                Loaddata();


            }
            catch (Exception ex)
            {

            }
        }

        protected void Loaddata()
        {
            try
            {

                Query = "select * from Product";
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

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            Button btnAddToCart = (Button)sender;
            GridViewRow row = (GridViewRow)btnAddToCart.NamingContainer;

            string pid = row.Cells[0].Text; 
            DropDownList ddlQuantity = (DropDownList)row.FindControl("ddlQuantity");
            string selectedQuantity = ddlQuantity.SelectedValue;

            if(Int32.Parse(selectedQuantity) > 0)
            {
                Query = "insert into Cart values(" + Session["UserID"].ToString() + "," + pid + "," + selectedQuantity + ")";
                if (DB.InsertData(Query))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Added to cart')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to update cart')", true);
                }

                
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

        protected void Searchbtn_Click(object sender, EventArgs e)
        {
            try
            {

                Query = "select * from Product where PName like '%" + PName.Text + "%'";
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
    }
}