<%@ Page Title="" Language="C#" CodeBehind="Default.aspx.cs" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SearchHistory
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">

    <div id = "hourlyReport"><h2>Hourly Report</h2></div>
    <div id = "hourlyChart">
    <img src = "/History/GetChart" /> 
    <%= Html.Encode(ViewData["Hourly"]) %>
                    </div>
    
    <div id = "dailyReport"><h2>Daily Report </h2></div>
    <div id = "dailyChart"><img src = "/History/GetChart" /> <%= Html.Encode(ViewData["Daily"]) %></div>
    
    <div id = "byComputerReport"><h2>By Computer Report</h2></div>
    <div id = "byComputerChart"><img src = "/History/GetChart" /> <%= Html.Encode(ViewData["ByComputer"]) %></div>

    </form>

</asp:Content>
