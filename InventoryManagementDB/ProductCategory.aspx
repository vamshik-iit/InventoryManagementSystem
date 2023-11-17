<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductCategory.aspx.cs" Inherits="InventoryManagementDB.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="w3-container w3-light-grey w3-padding-32 w3-padding-large" id="contact">
    <div class="w3-content" style="max-width:600px">
      <h4 class="w3-center"><b>Product Categeory</b></h4>

        <table>
            <tr>
                <th>
                    <label style="padding-left:10px">CategoryName</label>
                </th>
              

                 <th>
                      <div style="padding-left:10px">
                        <asp:TextBox runat="server" ID="CName" cssclass="w3-input w3-border"></asp:TextBox>
                    </div>
                </th>

               


            </tr>

        </table>

        <div style="padding-left:25%;padding-top:15px">
            
     <asp:Button Text="Add New Categeory" runat="server" CssClass="w3-button w3-block w3-black w3-margin-bottom" ID="AddCategeory" OnClick="AddCategeory_Click"/>
      
        </div>



              <div style="padding-left:25%;padding-top:15px">
            
     <asp:Button Text="Delete Categeory" runat="server" CssClass="w3-button w3-block w3-black w3-margin-bottom" ID="DelCategeory" OnClick="DelCategeory_Click"/>
      
        </div>
       
        <br />
        <br />
       



             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="false"
    OnPageIndexChanging="OnPaging" PageSize="10" >
    <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="CategoryID" HeaderText="CategoryID"/>
        <asp:BoundField ItemStyle-Width="150px" DataField="CategoryName" HeaderText="CategoryName" />
   
        

          
    </Columns>
</asp:GridView>
   



    </div>
  </div>



</asp:Content>
