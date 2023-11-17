<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="InventoryManagementDB.ViewProducts"  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="w3-container w3-light-grey w3-padding-32 w3-padding-large" id="contact">
    <div class="w3-content" style="max-width:600px">
      <h4 class="w3-center"><b>View Products</b></h4>

        <table>
            <tr>
                <th>
                    <label style="padding-left:10px">Product Name</label>
                </th>
              

                 <th>
                      <div style="padding-left:10px">
                        <asp:TextBox runat="server" ID="PName" cssclass="w3-input w3-border"></asp:TextBox>
                    </div>
                </th>

               


            </tr>

        </table>

        <div style="padding-left:25%;padding-top:15px">
            
     <asp:Button Text="Search" runat="server" CssClass="w3-button w3-block w3-black w3-margin-bottom" ID="Searchbtn" OnClick="Searchbtn_Click" />
      
        </div>



            
       
        <br />
        <br />
       



             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="false"
    OnPageIndexChanging="OnPaging" PageSize="10" >
    <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="PID" HeaderText="PID"/>
        <asp:BoundField ItemStyle-Width="150px" DataField="PName" HeaderText="PName" />
   <asp:BoundField ItemStyle-Width="150px" DataField="SKU" HeaderText="SKU"/>
        <asp:BoundField ItemStyle-Width="150px" DataField="Quantity" HeaderText="Quantity" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Price" HeaderText="Price"/>
        <asp:BoundField ItemStyle-Width="150px" DataField="Location" HeaderText="Location" />
        
            <asp:TemplateField HeaderText="Select Quantity">
            <ItemTemplate>
                <asp:DropDownList ID="ddlQuantity" runat="server">
                     <asp:ListItem Text="0" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" OnClick="AddToCart_Click" CommandName="AddToCart" />
            </ItemTemplate>
        </asp:TemplateField>
          
    </Columns>
</asp:GridView>
   



    </div>
  </div>




</asp:Content>
