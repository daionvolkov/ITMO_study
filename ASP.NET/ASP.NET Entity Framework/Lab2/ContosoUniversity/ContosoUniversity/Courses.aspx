<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="ContosoUniversity.Courses" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Courses by Department</h2>
    
    <asp:EntityDataSource ID="DepartmentsEntityDataSource" 
        runat="server" 
        ConnectionString="name=SchoolEntities" 
        DefaultContainerName="SchoolEntities" EnableFlattening="False" EntitySetName="Departments" Select="it.[DepartmentID], it.[Name]">
    </asp:EntityDataSource>
    <h3>Select a department:</h3>
    <asp:DropDownList ID="DepartmentsDropDownList" runat="server" 
        DataSourceID="DepartmentsEntityDataSource" DataTextField="Name" DataValueField="DepartmentID">
    </asp:DropDownList>
    
</asp:Content>
