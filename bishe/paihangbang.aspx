<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paihangbang.aspx.cs" Inherits="bishe.paihangbang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>排行榜</title>
    <style>
        .Label1 {
            Font-Size: XX-Large;
            Font-weight: Bold;
        }
        .Button {
            Height: 45px;
            Width : 150px;
            Font-Size: X-Large;
            Font-weight: Bold;
        }
        .GridView {
            Line-Height:30px;
            Font-Family: 宋体;
            Font-Size: Large;
            Font-weight: Bold;
            table-layout:fixed;
        }
         body {
            background: url(/b.jpg)
        }
    </style>
</head>
<body style=" background-repeat:no-repeat ; background-size:100% 100%; background-attachment: fixed;">  
    <form id="form_Paihangbang" runat="server">
        <div style="text-align:center;height:650px;width:1120px;">   
            <asp:Label ID="Label_Xuanze" runat="server" Text="请 选 择" CssClass="Label1"></asp:Label>
        <br />
        <br />
        <br />
            <asp:Button ID="Button_Youxiuchuqinbang" runat="server" Text="优秀出勤榜" CssClass="Button" OnClick="Button_Youxiuchuqinbang_Click" />
        <br />
        <br />
        <br />
            <asp:Button ID="Button_Qinfenbang" runat="server" Text="勤奋榜" CssClass="Button" OnClick="Button_Qinfenbang_Click" />
        <br />
        <br />
        <br />
            <asp:Button ID="Button_Chidaobang" runat="server" Text="迟到榜" CssClass="Button" OnClick="Button_Chidaobang_Click" />
        <br />
        <br />
        <br />
            <asp:Button ID="Button_Kuanggongbang" runat="server" Text="旷工榜" CssClass="Button" OnClick="Button_Kuanggongbang_Click" />
        <br />
        <br />
        <br />
            <asp:Button ID="Button_Fanhui" runat="server" Text="返回" CssClass="Button" OnClick="Button_Fanhui_Click" />
        <br />
        <br />
        <br />
            <asp:Button ID="Button_Shujudaochu" runat="server" Text="数据导出" CssClass="Button" OnClick="Button_Shujudaochu_Click"/>
        <br />
        <br />
        <br />
        <br />
        <br />
            <asp:GridView ID="GridView_Paihangbang" runat="server" OnSelectedIndexChanged="GridView_Paihangbang_SelectedIndexChanged" Font-Italic="False" Font-Overline="False"  HorizontalAlign="Center" CssClass="GridView" Width="800px" EmptyDataText="未查询到数据">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
