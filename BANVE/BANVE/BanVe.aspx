<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/Style.master" AutoEventWireup="true" CodeFile="BanVe.aspx.cs" Inherits="CSKH_TaoMoiCSKH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/BanVe.css" rel="stylesheet" />
    <link href="../CSS/Responsive.css" rel="stylesheet" />
    <link href="../CSS/HideMenu.css" rel="stylesheet" />
    <script src="../Js/Common.js"></script>
    <script src="../Js/jquery-3.1.1.js"></script>
        <meta name="viewport" content="width=device-width, maximum-scale=1, minimum-scale=1" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="divLeft">
        <asp:Repeater ID="rpt_Quyen" runat="server">
            <HeaderTemplate>
                <table style="width:80%; border-spacing:0px; border:0px; height:87vh" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td style="padding:0px 0px 0px 0px; text-align:center; height:36px">
                            <img id="imgMenu" src="../image/border4.PNG" width="45" height="40" onclick="openNavmenu()" title="Hiện menu"/>
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td <%#string.Format(@"style=""background-image:url({0}); background-repeat:repeat-y; background-position:center"" title=""{1}"" id=""td{2}""",Eval("TenTrang").ToString()==ViewState["TenTrang"].ToString()?"../Image/border3.png":"../Image/border5.png", Eval("TenTrang").ToString()==ViewState["TenTrang"].ToString()?Eval("TenQuyen").ToString():"", Eval("TenTrang")) %> > &nbsp; </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <tr><td style="background-image:url(../image/border5.png); background-repeat:repeat-y; background-position:center" >&nbsp;</td></tr>
                <tr><td style="background-image:url(../image/border5.png); background-repeat:repeat-y; background-position:center" >&nbsp;</td></tr>
                <tr><td style="background-image:url(../image/border5.png); background-repeat:repeat-y; background-position:center" >&nbsp;</td></tr>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div class="divIFrame">
        <iframe style="width:99%; height:100%" id="container" name="container" src='<%# ViewState["TenTrang"].ToString() %>' ></iframe>
    </div>
    <div  class="sidenavmenu" id="mySidenavmenu" >
        <img src="../image/close.png" title="Ẩn menu" onclick="closeNav()" width="20" height="20" />
        <asp:Repeater ID="rptTrang" runat="server">
            <HeaderTemplate>
                <ul class="ul">
            </HeaderTemplate>
            <ItemTemplate>
                <li><div id='<%#Eval("TenTrang") %>' <%#string.Format(@"class=""divMenuCon{0}""", ViewState["TenTrang"].ToString().Equals(Eval("TenTrang"))?" menuselected":"") %> <%#string.Format(@"onclick=""DoiMenuTrai('{0}','{1}')"" ",Eval("TenTrang"), Eval("TenQuyen")) %>
                   <%#string.Format(@"style=""background-image:url({0})""", Eval("icon")) %>>
                    <%#Eval("TenQuyen") %>
                    <%--<a href='<%#Eval("TenTrang") %>' class='<%#ViewState["TenTrang"].ToString().Equals(Eval("TenTrang"))?"mainmenuselected":"link" %>'><%#Eval("TenQuyen") %>
                    </a>--%>
                    </div>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </asp:Content>