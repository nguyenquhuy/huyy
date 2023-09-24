<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MyCourses.aspx.cs" Inherits="Huyy.MyCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="my_container">
        <div class ="page_title">
            <asp:Label ID="my_label" runat="server"></asp:Label>
        </div>
        
        <table class="table">
            <thead id="tableHead" runat="server">                
            </thead>
            <tbody id="tableBody" runat="server">                
            </tbody>
        </table>
    </div>

</asp:Content>
