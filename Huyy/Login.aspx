<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Huyy.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div class="login_container">
    <div class="wrapper">
        <form method="post">
            <h3 style="color:white;">
                <asp:Label ID="label1" runat="server"></asp:Label>
            </h3>
            <h1>Login</h1>
            <div class="input-box">
                <input type="text" id="username" name="username" placeholder="Username" required>
            </div>
            <div class="input-box">
                <input type="password" id="password" name="password" placeholder="Password" required>
            </div>
            <div class="remember-forgot">
                <label><input type="checkbox"> Remember me</label>
                <a href="">Forgot Password</a>
            </div>
            <input type="submit" name="dangnhap" id="dangnhap" class="btn" value="Login"/>
            <div class="register-link">
                <p>Don't have an account? <a href="Index.aspx">Register</a></p>
            </div>
        </form>
    </div>
</div>

</asp:Content>
