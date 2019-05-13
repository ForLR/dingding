<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xuehaochoucha.aspx.cs" Inherits="bishe.xuehaochoucha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>按学号统计抽查</title>
    <style>
        .Label1 {
            Font-Size: XX-Large;
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
         body {
            background: url(/b.jpg)
        }
    </style>
</head>
<body style=" background-repeat:no-repeat ; background-size:100% 100%; background-attachment: fixed;">
    <form id="form_Xuehaotongji" runat="server">
        <div style="text-align:center;height:650px;width:1120px;">         
            <asp:Label ID="Label_Xuehao" runat="server" Text="请 输 入 学 号" CssClass="Label1"></asp:Label>    
        <br />
        <br />
        <br />
        <br />
        <br />
           <asp:TextBox ID="TextBox_Xuehao" runat="server"  OnTextChanged="TextBox_Xuehao_TextChanged" CssClass="Textbox"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <br />
            <asp:Button ID="Button_Chouchajieguo" runat="server" Text="抽查结果" CssClass="Button" OnClick="Button_Chouchajieguo_Click"/>
            &nbsp;&nbsp;
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
            <br />
            <br />
            <br />
            <br />
        <br />
        <br />
        <br />
            <asp:GridView ID="GridView_Xuehaochoucha" runat="server"  OnSelectedIndexChanged="GridView_Xuehaochoucha_SelectedIndexChanged" OnRowCommand="GridView_Xuehaochoucha_RowCommand"  Font-Italic="False" Font-Overline="False"  HorizontalAlign="Center" CssClass="GridView" Width="1100px" EmptyDataText="未查询到数据">
              <Columns>
                            <asp:ButtonField HeaderText="添加" Text="备注" CommandName="Remark"></asp:ButtonField>

                    </Columns> 
            </asp:GridView>
        </div>
    </form>
</body>
</html>