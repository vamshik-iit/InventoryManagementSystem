<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="InventoryManagementDB.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    
    <div class="w3-container w3-light-grey w3-padding-32 w3-padding-large" id="contact">
    <div class="w3-content" style="max-width:700px">
      <h4 class="w3-center"><b>Products</b></h4>

         <div>  
            <asp:RadioButton ID="RadioButton1" runat="server" Text="View/Modify" value="view" GroupName="vma" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack=True />  
            <asp:RadioButton ID="RadioButton2" runat="server" Text="Add" value="add" GroupName="vma" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack=True />  
        </div>  

        <table>
            <tr>
                <th>
                    <label style="padding-left:10px">Product ID</label>
                </th>
                 <th>
                      <div style="padding-left:10px">
                        <asp:TextBox runat="server" ID="PID" cssclass="w3-input w3-border" Enabled="false"></asp:TextBox>
                    </div>
                </th>
                <th>
                    <div style="padding-left:2%;padding-top:15px; width:100%" visible="false" id="fetchdiv" runat="server" >
            
     <asp:Button Text="Fetch" runat="server" CssClass="w3-button w3-black w3-block  w3-margin-bottom" ID="FetchProduct" OnClick="FetchProduct_Click"  />
      
        </div>

                </th>
            </tr>

            <tr>
                <th>
                    <label style="padding-left:10px">Product Name</label>
                </th>
                 <th>
                      <div style="padding-left:10px">
                        <asp:TextBox runat="server" ID="PName" cssclass="w3-input w3-border" Enabled="true"></asp:TextBox>
                    </div>
                </th>
            </tr>


            <tr>
                <th>
                    <label style="padding-left:10px">SKU</label>
                </th>
                 <th>
                      <div style="padding-left:10px">
                        <asp:TextBox runat="server" ID="SKU" cssclass="w3-input w3-border" Enabled="true"></asp:TextBox>
                    </div>
                </th>
            </tr>


            <tr>
                <th>
                    <label style="padding-left:10px">Quantity</label>
                </th>
                 <th>
                      <div style="padding-left:10px">
                        <asp:TextBox runat="server" ID="Quantity" cssclass="w3-input w3-border" Enabled="true"></asp:TextBox>
                    </div>
                </th>
            </tr>


            <tr>
                <th>
                    <label style="padding-left:10px">Price</label>
                </th>
                 <th>
                      <div style="padding-left:10px">
                        <asp:TextBox runat="server" ID="Price" cssclass="w3-input w3-border" Enabled="true"></asp:TextBox>
                    </div>
                </th>
            </tr>

            <tr>
                <th>
                    <label style="padding-left:10px">Location</label>
                </th>
                 <th>
                      <div style="padding-left:10px">
                        <asp:TextBox runat="server" ID="Location" cssclass="w3-input w3-border" Enabled="true"></asp:TextBox>
                    </div>
                </th>
            </tr>



            <tr>
                <th>
                    <label style="padding-left:10px">CategoryID</label>
                </th>
                 <th>
                      <div style="padding-left:10px">
                        <asp:dropdownlist runat="server" ID="CategoryID" cssclass="w3-input w3-border" Enabled="true"></asp:dropdownlist>
                    </div>
                </th>
            </tr>



        </table>

        <div style="padding-left:25%;padding-top:15px">
            
     <asp:Button Text="Add New Product" runat="server" CssClass="w3-button w3-block  w3-margin-bottom" ID="AddProduct" OnClick="AddProduct_Click" ForeColor="White" BackColor="LightGreen" />
      
        </div>



              <div style="padding-left:25%;padding-top:15px">
            
     <asp:Button Text="Update Product" runat="server" CssClass="w3-button w3-block w3-black w3-margin-bottom" ID="UpdateProduct" OnClick="UpdateProduct_Click"/>
      
        </div>
        
              <div style="padding-left:25%;padding-top:15px">
            
     <asp:Button Text="Delete Product" runat="server" CssClass="w3-button w3-block  w3-margin-bottom" ID="DeleteProduct" OnClick="DeleteProduct_Click" ForeColor="White" BackColor="PaleVioletRed" />
      
        </div>

       
        <br />
        <br />
       







    </div>
  </div>





</asp:Content>
