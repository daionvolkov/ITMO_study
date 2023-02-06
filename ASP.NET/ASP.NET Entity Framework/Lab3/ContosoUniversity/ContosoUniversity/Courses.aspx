<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="ContosoUniversity.Courses" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Courses by Department</h2>
    
    <asp:EntityDataSource ID="DepartmentsEntityDataSource" 
        runat="server" 
        ConnectionString="name=SchoolEntities" 
        DefaultContainerName="SchoolEntities" EnableFlattening="False" EntitySetName="Departments" Select="it.[DepartmentID], it.[Name]">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="CoursesEntityDataSource" runat="server" AutoGenerateWhereClause="True" ConnectionString="name=SchoolEntities" DefaultContainerName="SchoolEntities" EnableFlattening="False" EntitySetName="Courses" EntityTypeFilter="Course" Where="" Select="">
        <WhereParameters>
            <asp:ControlParameter ControlID="DepartmentsDropDownList" Name="DepartmentID" PropertyName="SelectedValue" Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>
    <h3>Select a department:</h3>
        <asp:GridView ID="CoursesGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="CourseID" DataSourceID="CoursesEntityDataSource">
        <Columns>
            <asp:BoundField DataField="CourseID" HeaderText="CourseID" ReadOnly="True" SortExpression="CourseID" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits" />
        </Columns>
        </asp:GridView>
    <h2>Courses by Name</h2>
    <h3>Enter a course name</h3>
        <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="SearchButton" runat="server" Text="Search" />
        <br /><br />
        <asp:EntityDataSource ID="SearchEntityDataSource" runat="server"
        ConnectionString="name=SchoolEntities" DefaultContainerName="SchoolEntities" EnableFlattening="False"
        EntitySetName="Courses"
        Include="Department" >
        </asp:EntityDataSource>
        <asp:QueryExtender ID="SearchQueryExtender" runat="server"
        TargetControlID="SearchEntityDataSource" >
        <asp:SearchExpression SearchType="StartsWith" DataFields="Title">
       
        <asp:ControlParameter ControlID="SearchTextBox" />
        </asp:SearchExpression>
        <asp:OrderByExpression DataField="Department.Name" Direction="Ascending">
        <asp:ThenBy DataField="Title" Direction="Ascending" />
        </asp:OrderByExpression>
        </asp:QueryExtender>
    <asp:GridView ID="SearchGridView" runat="server" AutoGenerateColumns="False"
        DataKeyNames="CourseID" DataSourceID="SearchEntityDataSource" AllowPaging="true">
        <Columns>
        <asp:TemplateField HeaderText="Department">
        <ItemTemplate>
        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Department.Name") %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="CourseID" HeaderText="ID"/>
        <asp:BoundField DataField="Title" HeaderText="Title" />
        <asp:BoundField DataField="Credits" HeaderText="Credits" />
        </Columns>
</asp:GridView>
    <asp:DropDownList ID="DepartmentsDropDownList" runat="server" 
        DataSourceID="DepartmentsEntityDataSource" DataTextField="Name" DataValueField="DepartmentID">
    </asp:DropDownList>
    
</asp:Content>
