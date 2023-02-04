<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="ContosoUniversity.Students" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Student List<asp:EntityDataSource ID="StudentsEntityDataSource" runat="server" ConnectionString="name=SchoolEntities" DefaultContainerName="SchoolEntities" EnableDelete="True" EnableFlattening="False" EnableUpdate="True" EntitySetName="People" Include="StudentGrades"></asp:EntityDataSource>
    
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

    </h2>

</asp:Content>
