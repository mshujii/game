<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="Game.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BAPE Registration Form</title>
    <link href="login-asset/style.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <img src="login-asset/img/logo.png" class="logo"/>
        <div class="wrapper">
        <div class="container">
            <div class="registration form">
                <header>Registration Form</header>
                <div class="field">
                    <input type="email" id="email" runat="server" placeholder="Enter your email"/>
                </div>
                <div class="field">
                    <input type="password" id="password" runat="server" placeholder="Enter your password"/>
                </div>
                <div class="field">
                    <input type="password" id="cPassword" runat="server" placeholder="Confirm password"/>
                </div>
                <div class="singupBtn">                  
                    <asp:Button ID="singupBtn" runat="server" Text="Sign Up" OnClick="singupBtn_Click" />
                </div>
               
                    <p>Already have an Account?
                        <a href="LoginForm.aspx"> Login</a>
                    </p>
                </div>
            </div>
        </div>
    </form>
