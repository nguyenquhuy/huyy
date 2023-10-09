<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MyCourses.aspx.cs" Inherits="Huyy.MyCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="my_container">
        <div class="header_fixed">
            <div class ="page_title" id="page_title" runat="server">                
            </div>        
            <table class="table">
                <thead id="tableHead" runat="server">                
                </thead>
                <tbody id="tableBody" runat="server">                
                </tbody>
            </table>
        </div>        
    </div>

    <script>
        function confirmDelete(id) {
            if (confirm("Are you sure you want to delete this record?")) {
                // If the user clicks "OK" in the dialog, redirect to the Delete.aspx page with the username as a parameter
                window.location.href = "Delete.aspx?i=" + id;
            }
        }
    </script>


</asp:Content>
