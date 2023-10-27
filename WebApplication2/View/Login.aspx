<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             
            <h1> User Login</h1>
            <div class="form-floating">
                                
                                <label for="name">Username: </label>
                <asp:TextBox runat="server" CssClass="form-control" ID="username" type="text" placeholder="Enter your username..." data-sb-validations="required"></asp:TextBox>
                                <div class="invalid-feedback" </div>
                            </div>
                            <div class="form-floating">
                               
                                <label for="email">Password: </label>
                                 <asp:TextBox runat="server" CssClass="form-control" ID="password" type="text" placeholder="Enter your password..." data-sb-validations="required,email"></asp:TextBox>
                                <div class="invalid-feedback" </div>
                                <div class="invalid-feedback" </div>
                           
                            
        
        </div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
    </form>
    
</body>
</html>
