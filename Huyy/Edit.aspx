<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Huyy.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="add_container">
        <form method="post" class="form-container" runat="server">
            <div class="form-group">
                <label for="name">Tên khóa học</label>
                <asp:TextBox ID="name" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="description">Mô tả</label>
                <asp:TextBox ID="description" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="source">Source (Use URL)</label>
                <asp:TextBox ID="source" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="slug">slug</label>
                <asp:TextBox ID="slug" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
            </div>

            <asp:Button ID="UpdateButton" runat="server" Text="Update" CssClass="btn-add" OnClick="UpdateButton_Click" />
        </form>
    </div>
</asp:Content>
