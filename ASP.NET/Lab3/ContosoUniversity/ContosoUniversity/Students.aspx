<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="ContosoUniversity.Students" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Student List</h2>
    <asp:EntityDataSource ID="StudentsEntityDataSource" runat="server" ConnectionString="name=SchoolEntities" DefaultContainerName="SchoolEntities" EnableDelete="True" EnableFlattening="False" EnableUpdate="True" EntitySetName="People" Include="StudentGrades" Where="it.EnrollmentDate is not null" OrderBy="t.LastName"></asp:EntityDataSource>
    
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="PersonID" DataSourceID="StudentsEntityDataSource">
        
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:TemplateField HeaderText="FirstMidName" SortExpression="FirstMidName">
               
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FirstMidName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstMidName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="EnrollmentDate" SortExpression="EnrollmentDate">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("EnrollmentDate") %>'></asp:TextBox>
                </EditItemTemplate>
                 <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("StudentGrades.Count") %>'></asp:Label>
                </ItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("EnrollmentDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle Font-Size="Small" />
    </asp:GridView>
    <h2>Find Students by Name</h2>
Enter any part of the name
<asp:TextBox ID="SearchTextBox" runat="server" AutoPostBack="true"></asp:TextBox>
<asp:Button ID="SearchButton" runat="server" Text="Search" />
<br />
<br />
<asp:EntityDataSource ID="SearchEntityDataSource" runat="server"
    ConnectionString="name=SchoolEntities" DefaultContainerName="SchoolEntities" EnableFlattening="False"
    EntitySetName="People"
    Where="it.EnrollmentDate is not null and (it.FirstMidName Like '%' + @StudentName + '%' or it.LastName Like '%' + @StudentName + '%')" >
<WhereParameters>
<asp:ControlParameter ControlID="SearchTextBox" Name="StudentName" PropertyName="Text"
    Type="String" DefaultValue="%"/>
</WhereParameters>
</asp:EntityDataSource>
<asp:GridView ID="SearchGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="PersonID"
    DataSourceID="SearchEntityDataSource" AllowPaging="true">
<Columns>
    <asp:TemplateField HeaderText="Name" SortExpression="LastName, FirstMidName">
    <ItemTemplate>
        <asp:Label ID="LastNameFoundLabel" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>,
        <asp:Label ID="FirstNameFoundLabel" runat="server" Text='<%# Eval("FirstMidName") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Enrollment Date" SortExpression="EnrollmentDate">
    <ItemTemplate>
        <asp:Label ID="EnrollmentDateFoundLabel" runat="server" Text='<%# Eval("EnrollmentDate", "{0:d}") %>'></asp:Label>

    </ItemTemplate>
    </asp:TemplateField>
</Columns>
</asp:GridView>
    

</asp:Content>
