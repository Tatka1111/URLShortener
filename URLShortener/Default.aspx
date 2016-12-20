<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="URLShortener.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div aria-expanded="undefined" style="border-width: medium; height: auto; padding-left: 10px; z-index: auto; padding-top: 5px; text-align: center;">
    
        URL Shortener Service<br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Width="400px" Wrap="False"></asp:TextBox>
    
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get shortened URL" Width="200px" Height="30px" />
    
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Statistics" Width="200px" Height="30px" OnClick="Button2_Click" />
    
    </div>
    </form>
</body>
</html>
