<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pingfenbangdan.aspx.cs" Inherits="bishe.pingfenbangdan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>评分排行</title>
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
    </style>
</head>
<body>  
    <form id="form_Paihangbang" runat="server">
        <div style="text-align:center;background:url(222.jpg) no-repeat;height:650px;width:1120px;">   
             <br />
            <asp:Button ID="Button_Fanhui" runat="server" Text="返回" CssClass="Button" OnClick="Button_Fanhui_Click" />
        <br />
        <br />
            <asp:GridView ID="GridView_pingfenbangdan" runat="server" OnSelectedIndexChanged="GridView_pingfenbangdan_SelectedIndexChanged" Font-Italic="False" Font-Overline="False"  HorizontalAlign="Center" CssClass="GridView" Width="800px" EmptyDataText="未查询到数据">
            </asp:GridView>


        </div>

    </form>
</body>
</html>
