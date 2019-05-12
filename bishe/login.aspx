<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="bishe.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录</title>
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
    <form id="form_Login" runat="server">
    <div style="text-align:center;background:url(222.jpg) no-repeat;height:650px;width:1120px;" >
        <asp:Label ID="Label_Denglu" runat="server" Text="管 理 员 登 录" CssClass="Label1"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label_User" runat="server" Text="用户名:" CssClass="Label2"></asp:Label>&nbsp;
        <asp:TextBox ID="TextBox_User" runat="server" OnTextChanged="TextBox_User_TextChanged" AutoCompleteType="Disabled" CssClass="Textbox" EnableViewState="False" ></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="Label_Pwd" runat="server" Text="密&nbsp码:" CssClass="Label2"></asp:Label>&nbsp;
        <asp:TextBox ID="TextBox_Pwd" runat="server" OnTextChanged="TextBox_Pwd_TextChanged" AutoCompleteType="Disabled" TextMode="Password" CssClass="Textbox" EnableViewState="False"  ></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button_Queding" runat="server"  Text="确定"  CssClass="Button" OnClick="Button_Queding_Click"/>
    </div>
    </form>
</body>
</html>

