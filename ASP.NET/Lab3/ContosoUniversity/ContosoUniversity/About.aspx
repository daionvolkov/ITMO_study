<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ContosoUniversity.About" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h2>Student Body Statistics</h2>
    <asp:EntityDataSource ID="StudentStatisticsEntityDataSource" runat="server"
        ConnectionString="name=SchoolEntities" DefaultContainerName="SchoolEntities"
        EnableFlattening="False" EntitySetName="People" GroupBy="it.EnrollmentDate"
        OrderBy="it.EnrollmentDate"
        Select="it.EnrollmentDate, Count(it.EnrollmentDate) AS NumberOfStudents"
        Where="it.EnrollmentDate is not null">
    </asp:EntityDataSource>
    <asp:GridView ID="StudentStatisticsGridView" runat="server" AutoGenerateColumns="False"
        DataSourceID="StudentStatisticsEntityDataSource">
        <Columns>
            <asp:BoundField DataField="EnrollmentDate" DataFormatString="{0:d}"
            HeaderText="Date of Enrollment"
            ReadOnly="True" SortExpression="EnrollmentDate" />
            <asp:BoundField DataField="NumberOfStudents" HeaderText="Students"
            ReadOnly="True" SortExpression="NumberOfStudents" />
        </Columns>
    </asp:GridView>
</asp:Content>