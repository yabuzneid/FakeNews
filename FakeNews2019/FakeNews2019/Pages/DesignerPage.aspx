<%@ Page Title="" Language="C#" MasterPageFile="~/FakeNewsDashBoard.Master" AutoEventWireup="true" CodeBehind="DesignerPage.aspx.cs" Inherits="FakeNews2019.DesignerPage" %>

<%@ Register Assembly="DevExpress.Dashboard.v18.2.Web.WebForms, Version=18.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxDashboard ID="ASPxDashboard1" runat="server" Width="100%" Height="100%" DashboardStorageFolder="~/App_Data/Dashboards"></dx:ASPxDashboard>
</asp:Content>
