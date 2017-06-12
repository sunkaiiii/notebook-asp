<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Regist.aspx.cs" Inherits="notebook.Regist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            用户名：&nbsp; 
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="用户名不能为空" ValidateEmptyText="True">*</asp:CustomValidator>
        </p>
        <p>
            密码：&nbsp;&nbsp; <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="密码不能为空" ValidateEmptyText="True">*</asp:CustomValidator>
        </p>
        <p>
            确认密码：<asp:TextBox ID="txtPassword2" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;<asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="txtName" ErrorMessage="确认密码不能为空" ValidateEmptyText="True">*</asp:CustomValidator>
&nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtPassword2" ErrorMessage="密码输入不一致"> </asp:CompareValidator>
        </p>
        <p>
            <asp:Button ID="btnRegist" runat="server" Text="注册" OnClick="btnRegist_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBack" runat="server" Text="取消" OnClick="btnBack_Click" />
        </p>
    </form>
</body>
</html>
