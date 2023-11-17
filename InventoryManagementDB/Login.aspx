<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InventoryManagementDB.Login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Login - Inventory Management System</title>

      <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="fonts/icomoon/style.css">
    <link rel="stylesheet" href="css/owl.carousel.min.css">
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css">
</head>
<body>
    <div class="content">
    <div class="container">
      <div class="row">
        <div class="col-md-6">
          <img src="images/undraw_remotely_2j6y.svg" alt="Image" class="img-fluid">
        </div>
        <div class="col-md-6 contents">
          <div class="row justify-content-center">
            <div class="col-md-8">
              <div class="mb-4">
              <h3>Inventory Management System</h3>
              <p class="mb-4">Sign in</p>
            </div>
            <form action="#" method="post" runat="server">
              <div class="form-group first">
                <label for="username">Username</label>
                
                <asp:TextBox runat="server" ID="UserName" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group last mb-4">
                <label for="password">Password</label>
                
                <asp:textbox runat="server" ID="Password" CssClass="form-control" type="password"></asp:textbox>
              </div>


              

              <asp:Button Text="Log In" runat="server" CssClass="btn btn-block btn-primary" ID="LibraryLoginBtn" OnClick="LibraryLoginBtn_Click" />
              <br />
 <div class="first">
            <span class="ml-auto"><a href="Register.aspx" class="forgot-pass">Not a Member? - Register</a></span>
              </div>

            </form>
            </div>
          </div>
          
        </div>
        
      </div>
    </div>
  </div>

  
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>


</body>
</html>
