<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chouchaqushi.aspx.cs" Inherits="bishe.chouchaqushi" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>抽查趋势</title>
    <style>
        .Button {
            Height: 30px;
            Width : 100px;
            Font-Size: Large;
            Font-weight: Bold;
        }
          body {
            background: url(/b.jpg)
        }
    </style>
</head>
<body style=" background-repeat:no-repeat ; background-size:100% 100%; background-attachment: fixed;">
    <form id="form_Chouchaqingkuang" runat="server">
    <div style="text-align:center">   
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Chart ID="Chart_Faqichoucha" runat="server" Width="800px" Height="500px" BackColor="255, 255, 204" BorderWidth="2px" BorderColor="#CC9900"  OnLoad="Chart_Faqichoucha_Load" >
            <series>
                <asp:Series Name="Series_Faqichoucha" Font="Microsoft Sans Serif, 12pt" LabelForeColor="Green" IsValueShownAsLabel="true">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea_Faqichoucha" >
                </asp:ChartArea>
            </chartareas>
            <Titles>
                <asp:Title Name="Title_Faqichoucha" Text="老师发起抽查的次数"  Font="黑体,20pt" >
                </asp:Title>
            </Titles>
        </asp:Chart>  
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />  
        <br />
        <br /> 
        <asp:Chart ID="Chart_Weichoucha" runat="server" Width="800px" Height="500px" BackColor="255, 255, 204" BorderWidth="2px" BorderColor="#CC9900"  OnLoad="Chart_Weichoucha_Load" >
            <series>
                <asp:Series Name="Series_Weichoucha" Font="Microsoft Sans Serif, 12pt" LabelForeColor="Green" IsValueShownAsLabel="true">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea_Weichoucha" >
                </asp:ChartArea>
            </chartareas>
            <Titles>
                <asp:Title Name="Title_Weichoucha" Text="同学们抽查未打卡的次数"  Font="黑体,20pt" >
                </asp:Title>
            </Titles>
        </asp:Chart> 
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button_Fanhui" runat="server" Text="返 回"  OnClick="Button_Fanhui_Click" Font-Bold="True" Font-Size="X-Large" Height="45px" Width="125px"/>
        </div>
    </form>
</body>
</html>