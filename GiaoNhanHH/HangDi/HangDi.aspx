<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="HangDi.aspx.cs" Inherits="HangHoa_HangDi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/HideMenu.css" rel="stylesheet" />
    <link href="../CSS/HangHoa.css" rel="stylesheet" />
    <script src="../Js/Common.js"></script>
    <link href="../CSS/Resposive.css" rel="stylesheet" />
    <link href="../CSS/DropDownList.css" rel="stylesheet" />
    <link href="../CSS/GridView.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="divLeft">
        <asp:Repeater ID="rpt_Quyen" runat="server">
            <HeaderTemplate>
                <table style="width:100%; border-spacing:0px; border:0px; height:87vh" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td style="padding:0px 0px 0px 0px; text-align:center; height:36px">
                            <img id="imgMenu" src="../Image/border4.png" onclick="openNavmenu()" width="56" height="56" title="Hiện menu"/>
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td <%#string.Format(@"style=""background-image:url({0}); background-repeat:repeat-y; background-position:center"" title=""{1}"" id=""td{2}""",Eval("TenTrang").ToString()==ViewState["TenTrang"].ToString()?"../Image/border3.png":"../Image/border5.png", Eval("TenTrang").ToString()==ViewState["TenTrang"].ToString()?Eval("TenQuyen").ToString():"", Eval("TenTrang")) %> > &nbsp; </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <tr><td style="background-image:url(../Image/border5.png); background-repeat:repeat-y; background-position:center" >&nbsp;</td></tr>
                <tr><td style="background-image:url(../Image/border5.png); background-repeat:repeat-y; background-position:center" >&nbsp;</td></tr>
                <tr><td style="background-image:url(../Image/border5.png); background-repeat:repeat-y; background-position:center" >&nbsp;</td></tr>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div class="divIFrame">
        <iframe id="container" name="container" src='<%= ViewState["TenTrang"].ToString() %>' onload="resize(this);"></iframe>
    </div>
    <div  class="sidenavmenu" id="mySidenavmenu" style="border-right:0px solid rgba(255, 255, 255, 0);">
        <img src="../Image/close.png" title="Ẩn menu" onclick="closeNav()" width="20" height="20" />
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
    <div class="title"></div>
</asp:Content>

