<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="bishe.UserManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>更新部门用户</title>
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
            body {
            background: url(/b.jpg)
        }
    </style>
</head>
<body style=" background-repeat:no-repeat ; background-size:100% 100%; background-attachment: fixed;">  
        <div style="text-align:center;height:650px;width:1120px;"> 

           
    <form id="form1" runat="server">
         <div style="text-align:center;height:650px;width:1120px;"> 
        <asp:GridView ID="GridView1" runat="server" Height="384px" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand" Width="884px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
             <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:ButtonField HeaderText="设置" Text="选择" CommandName="SELECT"></asp:ButtonField>
            
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
             <div style="display:none">
                  <asp:Label ID="NameValue" runat="server" Text="Label" ></asp:Label>
                 <asp:Label ID="Idvalue" runat="server" Text="Label"></asp:Label>
             </div>
            
           
        <br />
        <br />
            <asp:Button ID="Button_Fanhui" runat="server" Text="返回" CssClass="Button" OnClick="Button_Fanhui_Click"/>
            &nbsp;&nbsp;
              <asp:Button ID="Button_student" runat="server" Text="学生" CssClass="Button" OnClick="Button_student_Click"/>
            &nbsp;&nbsp;
              <asp:Button ID="Button_teacher" runat="server" Text="教师" CssClass="Button" OnClick="Button_teacher_Click"/>
            
            </div>
    </form>

 </div>
           
</body>
</html>
