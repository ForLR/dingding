<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qushifenxi.aspx.cs" Inherits="bishe.qushifenxi" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>趋势分析</title>
    <style>
        .Button {
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
    <form id="form_Qushifenxi" runat="server">
    <div style="text-align:center;">   
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Chart ID="Chart_Zhengchangchuqin" runat="server" Width="800px" Height="500px" BackColor="255, 255, 204" BorderWidth="2px" BorderColor="#CC9900"  OnLoad="Chart_Zhengchangchuqin_Load" >
            <series>
                <asp:Series Name="Series_Zhengchangchuqin" Font="Microsoft Sans Serif, 12pt" LabelForeColor="Green" IsValueShownAsLabel="true">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea_Zhengchangchuqin" >
                </asp:ChartArea>
            </chartareas>
            <Titles>
                <asp:Title Name="Title_Zhengchangchuqin" Text="正常出勤"  Font="黑体,20pt" >
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
        <asp:Chart ID="Chart_Chidao" runat="server" Width="800px" Height="500px" BackColor="255, 255, 204" BorderWidth="2px" BorderColor="#CC9900"  OnLoad="Chart_Chidao_Load" >
            <series>
                <asp:Series Name="Series_Chidao" Font="Microsoft Sans Serif, 12pt" LabelForeColor="Green" IsValueShownAsLabel="true">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea_Chidao" >
                </asp:ChartArea>
            </chartareas>
            <Titles>
                <asp:Title Name="Title_Chidao" Text="迟到"  Font="黑体,20pt" >
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
        <asp:Chart ID="Chart_Qingjia" runat="server" Width="800px" Height="500px" BackColor="255, 255, 204" BorderWidth="2px" BorderColor="#CC9900"  OnLoad="Chart_Qingjia_Load" >
            <series>
                <asp:Series Name="Series_Qingjia" Font="Microsoft Sans Serif, 12pt" LabelForeColor="Green" IsValueShownAsLabel="true">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea_Qingjia" >
                </asp:ChartArea>
            </chartareas>
            <Titles>
                <asp:Title Name="Title_Qingjia" Text="请假"  Font="黑体,20pt" >
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
