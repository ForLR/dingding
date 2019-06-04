<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xuanze.aspx.cs" Inherits="bishe.xuanze" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>选择</title>
    <style>
        .Label1 {
            Font-Size: XX-Large;
            Font-weight: Bold;
        }
        .Button {
            Font-Size: X-Large;
            Font-weight: Bold;
        }
         body {
            background: url(/b.jpg)
        }
    </style>
</head>
<body style=" background-repeat:no-repeat ; background-size:100% 100%; background-attachment: fixed;">
    <form id="form_Xuanze" runat="server">
    <div style="text-align:center;height:650px;width:1120px;">
        <asp:Label ID="Label_Xuanze" runat="server" Text="请 选 择" CssClass="Label1"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button_Shujugengxin" runat="server" Text="数据更新"  CssClass="Button" OnClick="Button_Shujugengxin_Click" />
        <br />
        <br />
        <br />
        <asp:Button ID="Button_Changguitongji" runat="server" Text="常规统计"  CssClass="Button" OnClick="Button_Changguitongji_Click"/>
        <br />
        <br />
        <br />
        <asp:Button ID="Button_Kuozhanfenxi" runat="server" Text="扩展分析" CssClass="Button" OnClick="Button_Kuozhanfenxi_Click"/>
        <br />
        <br />
        <br />
        <asp:Button ID="Button_Chouchaqingkuang" runat="server" Text="抽查情况" CssClass="Button" OnClick="Button_Chouchaqingkuang_Click"/>
        <br />
        <br />
        <br />
         <asp:Button ID="Button_bangdan" runat="server" Text="评分榜单" CssClass="Button" OnClick="Button_bangdan_Click"/>
       
         <br />
        <br />
        <br />
         <asp:Button ID="Button_tongzhi" runat="server" Text="考勤通知" CssClass="Button" OnClick="Button_tongzhi_Click"/>
       
         <br />
        <br />
        <br />
         <asp:Button ID="Button_user" runat="server" Text="用户管理" CssClass="Button" OnClick="Button_user_Click"/>
       
         <br />
        <br />
        <br />
        <asp:Button ID="Button_Zhuxiao" runat="server" Text="注销" CssClass="Button" OnClick="Button_Zhuxiao_Click"/>
    </div>
    </form>
</body>
</html>
