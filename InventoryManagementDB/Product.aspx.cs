using Org.BouncyCastle.Ocsp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace InventoryManagementDB
{
    public partial class Product : System.Web.UI.Page
    {
        DBClass DB = new DBClass();
        string Query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    Query = "select * from ProductCategory";
                    DataTable dataTable = new DataTable();
                    dataTable = DB.FetchData(Query);
                    CategoryID.Items.Clear();
                    CategoryID.Items.Insert(0, "--select--");
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            CategoryID.Items.Insert(i + 1, dataTable.Rows[i]["CategoryID"].ToString() + "-" + dataTable.Rows[i]["CategoryName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                PID.Enabled = true;
                fetchdiv.Visible = true;
                PName.Text = "";
                SKU.Text = "";
                Quantity.Text = "";
                Price.Text = "";
                Location.Text = "";
                CategoryID.SelectedIndex = 0;
            }
            else
            {
                PID.Enabled=false;
                fetchdiv.Visible = false;
                PName.Text = "";
                SKU.Text = "";
                Quantity.Text = "";
                Price.Text = "";
                Location.Text = "";
                CategoryID.SelectedIndex = 0;
            }
        }

        protected void AddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                int prodid = DB.GetMaxIDCount("Product", "PID");
                string[] cissplit = CategoryID.SelectedValue.Split('-');
                if (prodid > 0)
                {
                    Query = "INSERT INTO Product (PID, PName, SKU, Quantity, Price, Location, CategoryID) " +
                            "VALUES (" + prodid + ", '" + PName.Text + "', '" + SKU.Text + "', " + Quantity.Text + ", " + Price.Text + ", '" + Location.Text + "', " + cissplit[0] + ")";
                    if (DB.InsertData(Query))
                    {
                        PName.Text = "";
                        SKU.Text = "";
                        Quantity.Text = "";
                        Price.Text = "";
                        Location.Text = "";
                        CategoryID.SelectedIndex = 0;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wowwww! Success')", true);
                    }
                    else
                    {

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Oopssss! Failed')", true);
                    }
                }


            }
            catch (Exception ex) { }
        }

        protected void UpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string[] cissplit = CategoryID.SelectedValue.Split('-');


                Query = "UPDATE Product SET PName = '" + PName.Text + "', SKU = '" + SKU.Text + "'," +
                    "Quantity = " + Quantity.Text + ", Price = " + Price.Text + "," +
                    "Location = '" + Location.Text + "', CategoryID = " + cissplit[0] + " " +
                    "WHERE PID =" + PID.Text + "";

                if (DB.InsertData(Query))
                {
                    PName.Text = "";
                    SKU.Text = "";
                    Quantity.Text = "";
                    Price.Text = "";
                    Location.Text = "";
                    CategoryID.SelectedIndex = 0;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wowwww! Success')", true);
                }
                else
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Oopssss! Failed')", true);
                }

            }
            catch (Exception ex) { 
            
            }
        }

        protected void DeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Query = "delete from Product where PID = " + PID.Text + "";
                if (DB.InsertData(Query))
                {
                    PName.Text = "";
                    SKU.Text = "";
                    Quantity.Text = "";
                    Price.Text = "";
                    Location.Text = "";
                    CategoryID.SelectedIndex = 0;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wowwww! Success')", true);
                }
                else
                {
                 
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Oopssss! Failed/ No or dependent Records')", true);
                }
            }
            catch (Exception ex) { 
            
            }
        }

        protected void FetchProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Query = "select * from Product where PID = " + PID.Text;
                DataTable dataTable = new DataTable();
                dataTable = DB.FetchData(Query);


                if(dataTable.Rows.Count > 0)
                {
                    PName.Text = dataTable.Rows[0]["PName"].ToString();
                    SKU.Text = dataTable.Rows[0]["SKU"].ToString();
                    Quantity.Text = dataTable.Rows[0]["Quantity"].ToString();
                    Price.Text = dataTable.Rows[0]["Price"].ToString();
                    Location.Text = dataTable.Rows[0]["Location"].ToString();


                    Query = "select * from ProductCategory where CategoryID = " + dataTable.Rows[0]["CategoryID"].ToString();
                    DataTable dataTable2 = new DataTable();
                    dataTable2 = DB.FetchData(Query);

                    CategoryID.SelectedValue = dataTable.Rows[0]["CategoryID"].ToString() + "-" + dataTable2.Rows[0]["CategoryName"].ToString();
             

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Records Found')", true);
                }

            }
            catch (Exception ex){ }
        }
    }
}