<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addNote.aspx.cs" Inherits="notebook.addNote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        标题:
        <asp:TextBox Text='<%# Bind("notetitle") %>' runat="server" id="txtTitle" Height="18px" Width="446px" />
        <br />正文:
        <asp:TextBox Text='<%# Bind("notecontent") %>' runat="server" id="txtContent" Height="349px" TextMode="MultiLine" Width="571px" />
        <br />noteimage: <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加" />
&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返回" />
    </form>
</body>
</html>
