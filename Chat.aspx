<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="FinalProjectPetey.Chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        My chat<br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Height="259px" Width="718px"></asp:ListBox>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Width="368px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
    </form>
</body>
</html>
