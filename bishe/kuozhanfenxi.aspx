<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kuozhanfenxi.aspx.cs" Inherits="bishe.kuozhanfenxi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>扩展分析</title>
    <style>
        .Label1 {
            Font-Size: XX-Large;
            Font-weight: Bold;
        }
        .Button {
            Height: 45px;
            Width : 120px;
            Font-Size: X-Large;
            Font-weight: Bold;
        }
    </style>
</head>
<body>
        <form id="form_Kuozhanfenxi" runat="server">
    <div style="text-align:center;background:url(222.jpg) no-repeat;height:650px;width:1120px;">
        <asp:Label ID="Label_Xuanze" runat="server" Text="请 选 择" CssClass="Label1"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button_Paihangbang" runat="server" Text="排行榜" CssClass="Button" OnClick="Button_Paihangbang_Click" />
        <br />
        <br />
        <br />
        <asp:Button ID="Button_Qushifenxi" runat="server" Text="趋势分析" CssClass="Button" OnClick="Button_Qushifenxi_Click" />
        <br />
        <br />
        <br />
        <asp:Button ID="Button_Fanhui" runat="server" Text="返回" CssClass="Button" OnClick="Button_Fanhui_Click" />
    </div>
    </form>
</body>
</html>
