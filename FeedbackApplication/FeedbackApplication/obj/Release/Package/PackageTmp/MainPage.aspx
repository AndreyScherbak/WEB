<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="FeedbackApplication.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="~/Styles/Site.css" rel="stylesheet" runat="server" />
    <title>Main page</title>
</head>
<body>
    <h1>Your opinion is important for us</h1>
    <br />
    <form id="form1" runat="server">
        <asp:Label Text="The site has been stopped. Refresh it." runat="server" Visible="false"  ForeColor="Red" ID="lblWarning" />
        <asp:Button Text="Refresh" runat="server" OnClick="btnRefresh_Click" ID="btnRefresh"  Visible="false"/>
        <br />
            <asp:Label Text="To send your feedback follow the link"  runat="server" />
            <asp:HyperLink NavigateUrl="FeedbackPage.aspx" runat="server" Text="Feedback"/> 
        <br />
        <br />
        <asp:Label Text="If you have already left feedback, complete the session"  runat="server" />
        <asp:Button ID="btnEndSession" runat="server" OnClick="btnEndSession_Click"  Text="End Session"/>
        <br/>
        <br/>
        <asp:Label Text="If you want to stop the application, click on the button." runat="server" />
        <asp:Button ID="btnStopSite" runat="server" OnClick="btnStopSite_Click"  Text="Stop the site"/>
     </form>
</body>
</html>
