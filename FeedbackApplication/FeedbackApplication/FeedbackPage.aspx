<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedbackPage.aspx.cs" Inherits="FeedbackApplication.FeedbackPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="~/Styles/Site.css" rel="stylesheet" runat="server" />
    <title>Feedback</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>        
            <asp:TextBox ID="txtBoxFeedback" TextMode="multiline" runat="server"/>
            <br />
            <asp:Button ID="btnSendFeedback" Text="Send feedback" runat="server" OnClick="btnSendFeedback_Click"/>
            <br />
            <br />
            <br />
            <asp:HyperLink NavigateUrl="MainPage.aspx" runat="server"  Text="Back to main"/>
        </div>
    </form>
</body>
</html>
