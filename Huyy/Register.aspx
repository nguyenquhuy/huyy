<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Huyy.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            <div class="input-box">
                <input type="password" id="re-password" name="re-password" placeholder="Retype your password" required>
            </div>
            <input type="submit" name="dangky" id="dangky" class="btn" value="Register"/>
            
        </form>
    </div>
</div>
</asp:Content>
