<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="InventoryManagementDB.Cart"  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="w3-container w3-light-grey w3-padding-32 w3-padding-large" id="contact">
    <div class="w3-content" style="max-width:600px">
      <h4 class="w3-center"><b>View Cart</b></h4>

          
       
        <br />
        <br />
       



             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="false"
    OnPageIndexChanging="OnPaging" PageSize="10" >
    <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="PID" HeaderText="PID"/>
        <asp:BoundField ItemStyle-Width="150px" DataField="ProductName" HeaderText="ProductName" />

        <asp:BoundField ItemStyle-Width="150px" DataField="CartQuantity" HeaderText="Quantity" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Price" HeaderText="Price"/>

         <asp:BoundField ItemStyle-Width="150px" DataField="SubTotal" HeaderText="SubTotal"/>
                  <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:Button ID="btnAddToCart" runat="server" Text="Delete from Cart" OnClick="AddToCart_Click" CommandName="AddToCart" />
            </ItemTemplate>
        </asp:TemplateField>
          
    
          
    </Columns>
</asp:GridView>
   


        <br />
        <br />
        <br />

      


        <asp:Label Text="Order Total" runat="server" CssClass="w3-block w3-black w3-margin-bottom" ID="AddCategeory" ForeColor="white" />

             <asp:Label Text="" runat="server" CssClass="w3-block w3-black w3-margin-bottom" ID="Label1" ForeColor="white" />


              <br />
        <br />


         <div style="padding-left:25%;padding-top:15px">

             <div style="padding-left:10px">
                        <asp:dropdownlist runat="server" ID="Payment" cssclass="w3-input w3-border" Enabled="true">
                            <asp:ListItem Text="Cash On Delivery" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Credit Card" Value="2"></asp:ListItem>
                        </asp:dropdownlist>
                    </div>
             </div>

          <div style="padding-left:25%;padding-top:15px">
            
     <asp:Button Text="Confirm Purchase" runat="server" CssClass="w3-button w3-block  w3-margin-bottom" ID="ConfirmPurchase" OnClick="ConfirmPurchase_Click" ForeColor="White" BackColor="LightGreen" />
      
        </div>



              
        
              <div style="padding-left:25%;padding-top:15px">
            
     <asp:Button Text="Empty Cart" runat="server" CssClass="w3-button w3-block  w3-margin-bottom" ID="EmptyCart" OnClick="EmptyCart_Click" ForeColor="White" BackColor="PaleVioletRed" />
      
        </div>

       
        <br />
        <br />

        <h4 class="w3-center"><b>Order History</b></h4>

         <br />
        <br />
       



             <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" AllowPaging="false"
    OnPageIndexChanging="OnPaging" PageSize="10" >
    <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="ShipmentID" HeaderText="ShipmentID"/>
        <asp:BoundField ItemStyle-Width="150px" DataField="ShipmentDate" HeaderText="ShipmentDate" />

        <asp:BoundField ItemStyle-Width="150px" DataField="OrderID" HeaderText="OrderID" />
        <asp:BoundField ItemStyle-Width="150px" DataField="TrackingInfo" HeaderText="TrackingInfo"/>

       
    
          
    </Columns>
</asp:GridView>
   


        <br />
        <br />



    </div>
  </div>




</asp:Content>
