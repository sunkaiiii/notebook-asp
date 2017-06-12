<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="notebook.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 304px;
        }
        .auto-style3 {
            text-align: left;
        }
        .auto-style4 {
            height: 159px;
            text-align: center;
        }
        .auto-style5 {
            width: 100%;
            height: 1154px;
        }
        .auto-style6 {
            text-align: left;
            height: 85px;
        }
        .auto-style7 {
            height: 159px;
            text-align: center;
            width: 10px;
        }
        .auto-style8 {
            margin-top: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style5">
                <tr>
                    <td class="auto-style2" rowspan="3">我的笔记：<br />
                        <asp:DataList ID="DataList1" runat="server" DataKeyField="id" DataSourceID="SqlDataSource1">
                            <ItemTemplate>
                                <br />
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text='<%# Eval("notetitle") %>'></asp:LinkButton>
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:notebookConnectionString %>" SelectCommand="SELECT * FROM [usernote] WHERE ([username] = @username)">
                            <SelectParameters>
                                <asp:SessionParameter Name="username" SessionField="username" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td class="auto-style6" colspan="2">
                        <asp:TextBox ID="txtTitle" runat="server" BorderStyle="Outset" Enabled="False" Font-Size="X-Large" Height="48px" Width="976px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtContent" runat="server" Enabled="False" Height="906px" TextMode="MultiLine" Width="1368px"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:Image ID="Image1" runat="server" Height="158px" Width="155px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="2">
                        <asp:Button ID="Button1" runat="server" Height="34px" OnClick="Button1_Click" Text="修改" Width="84px" />
&nbsp;
                        <asp:Button ID="Button2" runat="server" CssClass="auto-style8" Height="34px" OnClick="Button2_Click" Text="取消" Visible="False" Width="84px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
