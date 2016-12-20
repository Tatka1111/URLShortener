<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="URLShortener.Statistics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div aria-expanded="undefined" style="border-width: medium; height: auto; padding-left: 10px; z-index: auto; padding-top: 10px;">
    
        
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" RowStyle-BackColor="#A1DCF2"
    HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand">
    <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="URL" HeaderText="URL" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="150px" DataField="ShortURL" HeaderText="Short URL">
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="150px" DataField="CreatedOn" HeaderText="CreatedOn" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="150px" DataField="Clicks" HeaderText="Clicks" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:ButtonField ButtonType="Button" runat="server" CommandName="DeleteURL" Text="Delete" />
    </Columns>

<HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>

<RowStyle BackColor="#A1DCF2"></RowStyle>
</asp:GridView>

    
        <br />
        <asp:Button ID="Button1" runat="server" Text="Back to the main page" Height="33px" OnClick="Button1_Click" />
    
    </div>
    </form>
</body>
</html>
