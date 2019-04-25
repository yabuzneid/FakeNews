<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeBehind="InitativesPage.aspx.cs" Inherits="FakeNews2019.Pages.InitativesPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
 
        <dx:ASPxImageSlider ID="ImageSlider" runat="server" Width="100%" Height="400px" ImageSourceFolder="~/Content/Images/Initiatives">
            <SettingsImageArea ImageSizeMode="FitProportional" NavigationButtonVisibility="Always" EnableLoopNavigation="true" />
            <SettingsNavigationBar Mode="Dots" />
            <SettingsSlideShow AutoPlay="true" PlayPauseButtonVisibility="OnMouseOver" />
        </dx:ASPxImageSlider>


</asp:Content>
