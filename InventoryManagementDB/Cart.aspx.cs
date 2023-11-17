using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementDB
{
    public partial class Cart : System.Web.UI.Page
    {
        DBClass DB = new DBClass();
        string Query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["UserID"] == null)
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

                Query = "SELECT C.CID, C.CName AS CustomerName, C.Address AS CustomerAddress, C.EmailAddress,  P.PID, P.PName AS ProductName, P.SKU, CA.Quantity as CartQuantity,(CA.Quantity * P.Price) as 'SubTotal', " +
                    "P.Quantity AS ProductQuantity, P.Price, P.Location,   PC.CategoryID, PC.CategoryName " +
                    "FROM Cart AS CA JOIN Product AS P ON CA.PID = P.PID JOIN Customer AS C ON CA.CID = C.CID " +
                    "LEFT JOIN ProductCategory AS PC ON P.CategoryID = PC.CategoryID where C.CID = " + Session["UserID"].ToString() + " ";

                DataTable dataTable = new DataTable();
                dataTable = DB.FetchData(Query);
          
                if (dataTable.Rows.Count > 0)
                {
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }

                Query = " SELECT sum(CA.Quantity * P.Price) as 'OrderTotal' FROM Cart AS CA JOIN Product AS P ON CA.PID = P.PID " +
                    " JOIN Customer AS C ON CA.CID = C.CID LEFT JOIN ProductCategory AS PC ON P.CategoryID = PC.CategoryID  " +
                    "where C.CID = " + Session["UserID"].ToString() + " ";
                dataTable = DB.FetchData(Query);
                if (dataTable.Rows.Count > 0)
                {
                    Label1.Text = dataTable.Rows[0]["OrderTotal"].ToString();
                }

                Query = "SELECT s.ShipmentID,s.ShipmentDate,s.OrderID,s.TrackingInfo FROM shipment s left join orderr o on o.OrderID=s.OrderID where CID=" + Session["UserID"].ToString() + "";
                dataTable = DB.FetchData(Query);
                if (dataTable.Rows.Count > 0)
                {
                    GridView2.DataSource = dataTable;
                    GridView2.DataBind();
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
           

            if (Int32.Parse(pid) > 0)
            {
                Query = "delete from Cart where PID = " + pid + " and CID = " + Session["UserID"].ToString() + "";
                if (DB.InsertData(Query))
                {
                    Loaddata();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted from cart')", true);
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
            try
            {
                GridView2.PageIndex = e.NewPageIndex;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void ConfirmPurchase_Click(object sender, EventArgs e)
        {
            try
            {
                int maxorderid = DB.GetMaxIDCount("orderr", "OrderID");
                Query = "insert into orderr values(" + maxorderid + ", " + Session["UserID"].ToString() + ",CURRENT_TIMESTAMP, " + Label1.Text + " )";
                if (DB.InsertData(Query))
                {

                    Query = "SELECT C.CID,  P.PID,   CA.Quantity as CartQuantity,(CA.Quantity * P.Price) as 'SubTotal', " +
                   "P.Quantity AS ProductQuantity, P.Price   " +
                   "FROM Cart AS CA JOIN Product AS P ON CA.PID = P.PID JOIN Customer AS C ON CA.CID = C.CID " +
                   "LEFT JOIN ProductCategory AS PC ON P.CategoryID = PC.CategoryID where C.CID = " + Session["UserID"].ToString() + " ";

                    DataTable dataTable = new DataTable();
                    dataTable = DB.FetchData(Query);
                    if (dataTable.Rows.Count > 0)
                    {
                        for(int i=0;i < dataTable.Rows.Count; i++)
                        {
                            int maxorderid2 = DB.GetMaxIDCount("orderproduct", "OrderProductID");
                            Query = "insert into orderproduct " +
                                "values(" + maxorderid2 + ", " + maxorderid + ", " + dataTable.Rows[i]["PID"].ToString() + " ," + dataTable.Rows[i]["CartQuantity"].ToString() + " , " + dataTable.Rows[i]["SubTotal"].ToString() + " )";
                            DB.InsertData(Query);
                            int maxshipid = DB.GetMaxIDCount("Shipment", "ShipmentID");
                            Random random = new Random();
                            int min = 1000000; 
                            int max = 9999999; 
                            int randomNumber = random.Next(min, max + 1); 


                            Query = "insert into Shipment values(" + maxshipid + ", CURRENT_TIMESTAMP, " + maxorderid + ", '" + randomNumber + "' )";


                            DB.InsertData(Query);

                            int maxinvoiceid = DB.GetMaxIDCount("Invoice", "InvoiceID");
                            Query = "insert into Invoice values(" + maxinvoiceid + "," + maxorderid + ",CURRENT_TIMESTAMP, " + Session["UserID"].ToString() + ", '" + Payment.SelectedValue.ToString() + "' )";


                            if (DB.InsertData(Query))
                            {
                                Query = "delete from Cart where CID = " + Session["UserID"].ToString() + "";
                                DB.InsertData(Query);
                                Loaddata();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Success!!!! Order Placed')", true);
                            }


                        }


                    }




                       
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to update cart')", true);
                }

            }
            catch(Exception ex)
            {

            }
        }

        protected void EmptyCart_Click(object sender, EventArgs e)
        {
            
           
                Query = "delete from Cart where CID = " + Session["UserID"].ToString() + "";
                if (DB.InsertData(Query))
                {
                    Loaddata();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted from cart')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to update cart')", true);
                }


           
        }
    }
}