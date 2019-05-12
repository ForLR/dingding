<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRemark.aspx.cs" Inherits="bishe.AddRemark" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .Textbox {}
        .Button {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            &nbsp;</p>
        <div style="text-align: center; height: 650px; width: 1120px;">
           
          
            &nbsp;
           <asp:TextBox ID="TextBox_User" runat="server" OnTextChanged="TextBox_User_TextChanged" AutoCompleteType="Disabled" CssClass="Textbox" EnableViewState="False" Height="207px" Width="448px" ></asp:TextBox>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Button_Queding" runat="server" CssClass="Button" OnClick="Button_Queding_Click" Text="确定" Height="51px" Width="123px" />
        </div>
    </form>
</body>
</html>
