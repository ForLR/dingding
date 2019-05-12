<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Daohang.aspx.cs" Inherits="bishe.Daohang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>钉钉考勤管理系统</title>
</head>  
<body>  
    <form id="form_Daohang" runat="server" >
        <div id="Daohang" style="border-right-style:solid; border-right-color:Silver; top:40px;  width: 240px; height:560px;position:fixed; text-align:center">
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" StartingNodeUrl="~/login.aspx" />
            <asp:TreeView ID="TreeView1" runat="server" Target="mainFrame" ImageSet="Faq" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" >
            <HoverNodeStyle Font-Underline="True" ForeColor="Purple" />
            <LeafNodeStyle Font-Bold="False" Font-Size="Medium" NodeSpacing="4px" />
            <Nodes>
                <asp:TreeNode Expanded="True" NavigateUrl="~/login.aspx" Target="mainFrame" Text="登录" Value="登录" >
                    <asp:TreeNode Expanded="True" NavigateUrl="~/xuanze.aspx" Text="用户选择" Value="用户选择">
                        <asp:TreeNode Expanded="True" NavigateUrl="~/shujugengxin.aspx" Text="数据更新" Value="数据更新">
                            <asp:TreeNode Expanded="True" NavigateUrl="~/quanbugengxin.aspx" Text="全部更新" Value="全部更新"></asp:TreeNode>
                            <asp:TreeNode Expanded="True" NavigateUrl="~/bufengengxin.aspx" Text="部分更新" Value="部分更新"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Expanded="True" NavigateUrl="~/changguitongji.aspx" Text="常规统计" Value="常规统计">
                            <asp:TreeNode Expanded="True" NavigateUrl="~/shijiantongji.aspx" Text="按时间统计" Value="按时间统计"></asp:TreeNode>
                            <asp:TreeNode Expanded="True" NavigateUrl="~/xuehaotongji.aspx" Text="按学号统计" Value="按学号统计"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Expanded="True" NavigateUrl="~/kuozhanfenxi.aspx" Text="扩展分析" Value="扩展分析">
                            <asp:TreeNode Expanded="True" NavigateUrl="~/paihangbang.aspx" Text="排行榜" Value="排行榜"></asp:TreeNode>
                            <asp:TreeNode Expanded="True" NavigateUrl="~/qushifenxi.aspx" Text="趋势分析" Value="趋势分析"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Expanded="True" NavigateUrl="~/chouchaqingkuang.aspx" Text="抽查情况" Value="抽查情况">
                            <asp:TreeNode Expanded="True" NavigateUrl="~/shijianchoucha.aspx" Text="按时间统计" Value="按时间统计"></asp:TreeNode>
                            <asp:TreeNode Expanded="True" NavigateUrl="~/xuehaochoucha.aspx" Text="按学号统计" Value="按学号统计"></asp:TreeNode>
                            <asp:TreeNode Expanded="True" NavigateUrl="~/chouchaqushi.aspx" Text="抽查趋势" Value="抽查趋势"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
            <NodeStyle NodeSpacing="0px" Font-Names="Tahoma" Font-Size="8pt" ForeColor="DarkBlue" HorizontalPadding="5px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="True" Font-Size="Large" NodeSpacing="5px" />
            <RootNodeStyle Font-Bold="True" Font-Size="Large" Font-Strikeout="False" NodeSpacing="5px" />
            <SelectedNodeStyle Font-Bold="False" Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px" />
            </asp:TreeView>
        </div>
        <div id="iFrame" class ="iFrame" style="height: 600px; width: 1120px;  left: 240px;  position:absolute" >
            <iframe id="mainFrame" name="mainFrame" runat="server" style="height: 600px; width: 1120px;  left: 240px;"  src="login.aspx" ></iframe> 
         </div>
    </form>
</body>   
</html>  
