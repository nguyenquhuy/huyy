<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewCourses.aspx.cs" Inherits="Huyy.NewCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="add_container">
        <form method = "post" class="form-container">
        <div class="form-group">
            <label for="name">Tên khóa học</label>
            <input type="text" class="form-control" id="name" name ="name" required>
        </div>
        <div class="form-group">
            <label for="description">Mô tả</label>
            <input type="text" class="form-control" id="description" name ="description" required>
        </div>
        <div class="form-group">
            <label for="name">ID</label>
            <input type="text" class="form-control" id="id" name ="id" required>
        </div>
        <div class="form-group">          
            <label for="name">Source (Use URL)</label>
            <input type="text" class="form-control" id="source" name ="source" required>
        </div>
        <div class="form-group">
            <label for="name">slug</label>
            <input type="text" class="form-control" id="slug" name ="slug" required>
        </div>

        <input type="submit" name="add" id="add" class="btn-add" value="Add new courses"/>        
    </form>
    </div>
    
</asp:Content>
