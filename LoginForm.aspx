<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="Game.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BAPE Login Form</title>
    <link href="login-asset/style.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <img src="login-asset/img/logo.png" class="logo"/>
          <div class="container">
                <div class="login form">
                  <header>Login</header>
                    <div class="field">
		                <input type="email" id="email" runat="server" placeholder="Enter your email"/>
                    </div>
                    <div class="field">
		                <input type="password" id="password" runat="server" placeholder="Enter your password"/>
                    </div>
                    <div class="loginBtn">
                        <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click"  /> 
                    </div>
                    
                    <p>Don't have an account?
                        <a href="RegistrationForm.aspx"> Register here</a>
                    </p>
                  
                </div>
           </div>
    </form>
</body>
</html>
