<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chouchaqingkuang.aspx.cs" Inherits="bishe.chouchaqingkuang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>抽查情况</title>
    <style>
        .Label1 {
            Font-Size: XX-Large;
            Font-weight: Bold;
        }
        .Button {
            Height: 45px;
            Width : 170px;
            Font-Size: X-Large;
            Font-weight: Bold;
        }
    </style>
</head>
<body>
        <form id="form_Changguitongji" runat="server">
        <div style="text-align:center;background:url(222.jpg) no-repeat;height:650px;width:1120px;">    
            <asp:Label ID="Label_Xuanzetongjifangshi" runat="server" Text="请选择统计方式" CssClass="Label1"></asp:Label>    
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Button_Shijianchoucha" runat="server" Text="按时间统计" CssClass="Button"  OnClick="Button_Shijianchoucha_Click" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button_Xuehaochoucha" runat="server" Text="按学号统计" CssClass="Button" OnClick="Button_Xuehaochoucha_Click" />    
            <br />
            <br />
            <br />
            <asp:Button ID="Button_Chouchaqushi" runat="server" Text="抽查趋势" CssClass="Button" OnClick="Button_Chouchaqushi_Click" />    
            <br />
            <br />
            <br />
            <asp:Button ID="Button_Fanhui" runat="server"  Text="返回" CssClass="Button" OnClick="Button_Fanhui_Click" />
            <br />
        </div>
    </form>
</body>
</html>
