<%@ Page Title="" Language="C#" CodeBehind="Default.aspx.cs" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SearchHistory
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <form id="form1" runat="server">
 <h2 class="hisotryHeader">Daily Data History</h2>
 </br>
 <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
     DataSourceID="DailyHistoryRecords" ForeColor="#333333" GridLines="None" 
     AllowPaging="True" AutoGenerateColumns="False">
     <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
     <Columns>
         <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True" 
             SortExpression="Date" />
         <asp:BoundField DataField="NoOfSearches" HeaderText="Searches" 
             ReadOnly="True" SortExpression="NoOfSearches" />
     </Columns>
     <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
     <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
     <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
     <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
     <EditRowStyle BackColor="#999999" />
     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
 </asp:GridView>
 <asp:ObjectDataSource ID="DailyHistoryRecords" runat="server" 
     SelectMethod="GetDailyHistory" 
     TypeName="SearchHistory.Models.HistoryService" >
 </asp:ObjectDataSource>


 <h2 class="hisotryHeader">Hourly Data History</h2>
 <asp:GridView ID="GridView2" runat="server" CellPadding="4" 
     DataSourceID="HourlyHistoryRecords" ForeColor="#333333" GridLines="None" 
     AllowPaging="True" AutoGenerateColumns="False">
     <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
     <Columns>
         <asp:BoundField DataField="Hour" HeaderText="Hour" ReadOnly="True" 
             SortExpression="Hour" />
         <asp:BoundField DataField="NoOfSearches" HeaderText="Searches" 
             ReadOnly="True" SortExpression="NoOfSearches" />
     </Columns>
     <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
     <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
     <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
     <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
     <EditRowStyle BackColor="#999999" />
     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
 </asp:GridView>
 <br />
 <asp:ObjectDataSource ID="HourlyHistoryRecords" runat="server" 
     SelectMethod="GetHourlyHistory" 
     TypeName="SearchHistory.Models.HistoryService" >
 </asp:ObjectDataSource>


 <h2 class="hisotryHeader">IP Data History</h2>
 <asp:GridView ID="GridView3" runat="server" CellPadding="4" 
     DataSourceID="IPHistoryRecords" ForeColor="#333333" GridLines="None" 
     AllowPaging="True" AutoGenerateColumns="False">
     <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
     <Columns>
         <asp:BoundField DataField="Ip" HeaderText="Ip" ReadOnly="True" 
             SortExpression="Ip" />
         <asp:BoundField DataField="NoOfSearches" HeaderText="NoOfSearches" 
             ReadOnly="True" SortExpression="NoOfSearches" />
     </Columns>
     <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
     <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
     <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
     <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
     <EditRowStyle BackColor="#999999" />
     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
 </asp:GridView>
 <br />
 <asp:ObjectDataSource ID="IPHistoryRecords" runat="server" 
     SelectMethod="GetIpHistory" 
     TypeName="SearchHistory.Models.HistoryService" >
 </asp:ObjectDataSource>

 </form>
</asp:Content>
