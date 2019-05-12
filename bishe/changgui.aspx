<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changgui.aspx.cs" Inherits="bishe.shijiantongji" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>常规统计</title>
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
    <form id="form_Shijiantongji" runat="server">
        <div style="text-align:center;background:url(222.jpg) no-repeat;height:650px;width:1120px;"> 
            <asp:Label ID="Label_Xuanzeshijianduan" runat="server" Text="请选择条件" CssClass="Label1"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />  
            <asp:Label ID="Label_Kaishishijian" runat="server" Text="开始时间" CssClass="Label2"></asp:Label>&nbsp;              
            <asp:TextBox ID="TextBox_Kaishishijian" runat="server" OnTextChanged="TextBox_Kaishishijian_TextChanged" CssClass="Textbox"></asp:TextBox>&nbsp;
            <asp:Button ID="Button_Kaishishijian" runat="server" OnClick="Button_Kaishishijian_Click" Text="开始时间" style="display:none"/>
        &nbsp;&nbsp; 
        <div id="Div_Calendar_Kaishishijian" style="left: 500px; width: 189px; position: absolute; top: 115px;
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
            <asp:Label ID="Label_Jieshushijian" runat="server" Text="结束时间" CssClass="Label2"></asp:Label>&nbsp;          
            <asp:TextBox ID="TextBox_Jieshushijian" runat="server" OnTextChanged="TextBox_Jieshushijian_TextChanged" CssClass="Textbox"></asp:TextBox>&nbsp;
            <asp:Button ID="Button_Jieshushijian" runat="server" OnClick="Button_Jieshushijian_Click" Text="结束时间" style="display:none"/>
        <div id="Div_Calendar_Jieshushijian" style="left: 900px; width: 189px; position: absolute; top: 115px;
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
            <asp:Label ID="Label1" runat="server" Text="学号" CssClass="Label2"></asp:Label>
            <asp:TextBox ID="TextBox_Xuehao" runat="server" OnTextChanged="TextBox_Xuehao_TextChanged" CssClass="Textbox"></asp:TextBox>
             &nbsp;&nbsp; &nbsp;&nbsp;
             <asp:Label ID="Label2" runat="server" Text="班级" CssClass="Label2"></asp:Label>
            <asp:TextBox ID="TextBox_banji" runat="server" CssClass="Textbox"></asp:TextBox>
        <br />
        <br />
            <asp:Button ID="Button_Zhengchangchuqin" runat="server" Text="正常出勤" CssClass="Button" OnClick="Button_Zhengchangchuqin_Click" />
            &nbsp;&nbsp;<asp:Button ID="Button_Chidao" runat="server"  Text="迟到" CssClass="Button" OnClick="Button_Chidao_Click" />
            &nbsp;&nbsp;<asp:Button ID="Button_Zaotui" runat="server"  Text="早退" CssClass="Button" OnClick="Button_Zaotui_Click" />
            &nbsp;&nbsp;<asp:Button ID="Button_Qingjia" runat="server" Text="请假" CssClass="Button" OnClick="Button_Qingjia_Click" />
            &nbsp;&nbsp;<asp:Button ID="Button_Queka" runat="server" Text="缺卡" CssClass="Button" OnClick="Button_Queka_Click" />
            &nbsp;&nbsp;<asp:Button ID="Button_Kuanggong" runat="server"  Text="旷工" CssClass="Button" OnClick="Button_Kuanggong_Click" />
        <br />
        <br />
        <br />
            <asp:Button ID="Button_Fanhui" runat="server" Text="返回" CssClass="Button" OnClick="Button_Fanhui_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button_Shujudaochu" runat="server" Text="数据导出" CssClass="Button" OnClick="Button_Shujudaochu_Click"/>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
              <asp:Label ID="tongji" runat="server" Text="统计" CssClass="Label2"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView_Shijiantongji" runat="server"  OnSelectedIndexChanged="GridView_Shijiantongji_SelectedIndexChanged"  Font-Italic="False" Font-Overline="False"  HorizontalAlign="Center" CssClass="GridView" Width="1100px" EmptyDataText="未查询到数据">
            </asp:GridView>
        </div>
    </form>
</body>
</html>