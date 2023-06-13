<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThongKeChinhSua.aspx.cs" Inherits="ThongKe_ThongKeHang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/ThongKe.css" rel="stylesheet" />
    <script src="../Js/jquery-3.1.1.js"></script>
    <script src="../Js/Common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divHead" class="divHead">
        <asp:Repeater ID="rptQuyen" runat="server">
            <ItemTemplate>
                <div id='<%#Eval("TenTrang") %>' <%#string.Format(@"class=""divItemMenu{0}""", ViewState["TenTrang"].ToString().Equals(Eval("TenTrang"))?" divItemMenuSelect":"") %> <%#string.Format(@"onclick=""DoiMenuThongKe('{0}','{1}')"" ",Eval("TenTrang"), Eval("TenQuyen")) %>><%#Eval("TenQuyen") %></div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
        <div class="divIFrame">
            <iframe id="container2" name="container2" src='<%= ViewState["TenTrang"].ToString() %>' onload="resize(this);"></iframe>
        </div>
    </form>
</body>
</html>
