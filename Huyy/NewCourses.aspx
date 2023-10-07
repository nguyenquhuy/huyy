<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewCourses.aspx.cs" Inherits="Huyy.NewCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="add-form">
            <h1>Thêm khóa học</h1>
            <form method = "post">
                    <p>Tên khóa học: </p>
                    <input type="text" class="form-control" id="name" name ="name" required>
                    <p>Mô tả: </p>
                    <input type="text" class="form-control" id="description" name ="description" required>
                    <p>Link khóa học:  </p>
                    <input type="text" class="form-control" id="source" name ="source" required>
                    <p>Thể loại:  </p>
                    <input type="text" class="form-control" id="slug" name ="slug" required>
                    <input type="submit" name="add" id="add" class="btn-add" value="Add new courses"/> 
            </form>
        </div>
    
</asp:Content>
