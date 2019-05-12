<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bufengengxin.aspx.cs" Inherits="bishe.bufengengxin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>部分更新</title>
    <style>
        .Label1 {
            Font-Size: XX-Large;
            Font-weight: Bold;
        }
        .Label2 {
            Font-Size: X-Large;
            Font-weight: Bold;
        }
        .Textbox {
            Height: 30px;
            Width : 200px;
            Font-Size: Large;
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
    <form id="form_Bufengengxin" runat="server" >
        <div style="text-align:center;background:url(222.jpg) no-repeat;height:650px;width:1120px;">
            <asp:Label ID="Label_Xuanzeshijianduan" runat="server" Text="请选择时间段" CssClass="Label1"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />                
            <asp:Label ID="Label_Kaishishijian" runat="server" Text="开始时间" CssClass="Label2"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox_Kaishishijian" runat="server" OnTextChanged="TextBox_Kaishishijian_TextChanged" CssClass="Textbox"></asp:TextBox>                   
            &nbsp;<asp:Button ID="Button_Kaishishijian" runat="server" OnClick="Button_Kaishishijian_Click" Text="开始时间" style="display:none"/>&nbsp;&nbsp;
&nbsp;<div id="Div_Calendar_Kaishishijian" style="left: 500px; width: 189px; position: absolute; top: 115px;
        height: 191px; background-color: white" visible="false" runat="server">                          
            <asp:Calendar ID="Calendar_Kaishishijian" runat="server" BackColor="White" BorderColor="#3366CC"
            BorderWidth="1px" CellPadding="1" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399"
            Height="200px" OnSelectionChanged="Calendar_Kaishishijian_SelectionChanged" Width="220px">
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <WeekendDayStyle BackColor="#CCCCFF" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
            Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            </asp:Calendar>
        </div>
            <asp:Label ID="Label_Jieshushijian" runat="server" Text="结束时间" CssClass="Label2"></asp:Label>
            <asp:TextBox ID="TextBox_Jieshushijian" runat="server" OnTextChanged="TextBox_Jieshushijian_TextChanged" CssClass="Textbox"></asp:TextBox>
            &nbsp;<asp:Button ID="Button_Jieshushijian" runat="server" OnClick="Button_Jieshushijian_Click" Text="结束时间" style="display:none"/>
        <div id="Div_Calendar_Jieshushijian" style=" left: 900px;width: 189px; position: absolute; top: 115px;
        height: 191px; background-color: white" visible="false" runat="server">              
            <asp:Calendar ID="Calendar_Jieshushijian" runat="server" BackColor="White" BorderColor="#3366CC"
            BorderWidth="1px" CellPadding="1" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399"
            Height="200px" OnSelectionChanged="Calendar_Jieshushijian_SelectionChanged" Width="220px">
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <WeekendDayStyle BackColor="#CCCCFF" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
            Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            </asp:Calendar>
        </div>                        
        <br />
        <br />
        <br />
        <br />
        <br />  
            <asp:Button ID="Button_Queding" runat="server" Text="确定" CssClass="Button" OnClick="Button_Queding_Click" />
        &nbsp;&nbsp;
            <asp:Button ID="Button_Fanhui" runat="server"  Text="返回" CssClass="Button" OnClick="Button_Fanhui_Click" />
        </div>            
    </form>
</body>
</html>
