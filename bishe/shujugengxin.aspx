<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shujugengxin.aspx.cs" Inherits="bishe.shujugengxin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>数据更新</title>
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
    <form id="form_Shujigengxin" runat="server">
    <div style="text-align:center;height:650px;width:1120px;">  
        <asp:Label ID="Label_Xuanzefangshi" runat="server"  Text="请选择更新方式" CssClass="Label1"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button_Quanbugengxin" runat="server" CssClass="Button"  OnClick="Button_Quanbugengxin_Click" Text="打卡结果更新" Width="360px"  />
        <br />
        <br />
      
        <asp:Button ID="Button_Bufengengxin" runat="server" CssClass="Button" OnClick="Button_Bufengengxin_Click" Text="部分打卡结果更新" Width="360px" />   
         <br />
        <br /> 
        <asp:Button ID="Button_xiangqinggengxin" runat="server" CssClass="Button" OnClick="Button_xiangqinggengxin_Click" Text="打卡详情全部更新" Width="360px" />   
        <br />
         <br />
       <asp:Button ID="Button_qingjia" runat="server" CssClass="Button" OnClick="Button_qingjia_Click" Text="请假数据更新" Width="360px" />  
        <br />
        <br />
        <asp:Button ID="Button_Fanhui" runat="server" CssClass="Button"  OnClick="Button_Fanhui_Click" Text="返回"  />
    </div>
    </form>
</body>
</html>
