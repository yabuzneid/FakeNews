<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeBehind="MYBookPage.aspx.cs" Inherits="FakeNews2019.Pages.MYBookImages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
            <dx:ASPxImageSlider ID="ImageSlider" runat="server" Width="100%" Height="400px" ImageSourceFolder="~/Content/Images/mybook">
            <SettingsImageArea ImageSizeMode="FitProportional" NavigationButtonVisibility="Always" EnableLoopNavigation="true" />
            <SettingsNavigationBar Mode="Dots" />
            <SettingsSlideShow AutoPlay="true" PlayPauseButtonVisibility="OnMouseOver" />
        </dx:ASPxImageSlider>
</asp:Content>
