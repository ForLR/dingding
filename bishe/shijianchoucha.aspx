<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shijianchoucha.aspx.cs" Inherits="bishe.shijianchoucha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>按时间统计抽查</title>
    <style>
        .Label {
            Font-Size: XX-Large;
            Font-weight: Bold;
        }
        .Button {
            Height: 45px;
            Width : 120px;
            Font-Size: X-Large;
            Font-weight: Bold;
        }     
        .GridView1 {
            Line-Height:30px;
            Font-Family: 宋体;
            Font-Size: Large;
            Font-weight: Bold;
            table-layout:fixed;
        }
        .GridView2 {
            Line-Height:30px;
            Font-Family: 宋体;
            Font-Size: Large;
            Font-weight: Bold;
            table-layout:fixed;
        }
    </style>
</head>
<body>  



    <form id="form1" runat="server">
        <div style="text-align:center;background:url(222.jpg) no-repeat;height:650px;width:1120px;"> 
            <asp:Label ID="Label_Xuanzeshijian" runat="server" Text="请选择抽查时间" CssClass="Label"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
            

            <asp:GridView ID="GridView_Shijianchoucha" runat="server"  OnSelectedIndexChanged="GridView_Shijianchoucha_SelectedIndexChanged"  Font-Italic="False" Font-Overline="False" HorizontalAlign="Center" CssClass="GridView1" Width="1100px" OnRowCommand="GridView_Shijianchoucha_OnRowCommand" EmptyDataText="未查询到数据" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" >               
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:ButtonField HeaderText="点击查询" Text="查询" CommandName="SELECT"></asp:ButtonField>

                </Columns>               
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle CssClass="GridView1" BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        <br />
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
            <asp:GridView ID="GridView_Shijianjieguo" runat="server"  OnSelectedIndexChanged="GridView_Shijianjieguo_SelectedIndexChanged"  OnRowCommand="GridView_Shijianjieguo_RowCommand" Font-Italic="False" Font-Overline="False"  HorizontalAlign="Center" CssClass="GridView2" Width="1100px" EmptyDataText="未查询到数据">
                     <Columns>
                            <asp:ButtonField HeaderText="添加" Text="备注" CommandName="Remark"></asp:ButtonField>

                    </Columns> 
            </asp:GridView>
        </div>
    </form>
</body>
</html>
