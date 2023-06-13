<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    <link href="CSS/Radio.css" rel="stylesheet" />
    <link href="CSS/HangHoa.css" rel="stylesheet" />
    <link href="CSS/Boder.css" rel="stylesheet" />
    <link href="CSS/GridView.css" rel="stylesheet" />
    <link href="CSS/CheckBox.css" rel="stylesheet" />
    <link href="CSS/DropDownList.css" rel="stylesheet" />
    <link href="CSS/HoverTable.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 100%;">
            <tr class="th">
                <th> Chọn </th>
                <th> STT </th>
                <th> Giờ nhận </th>
                <th> Mã hàng </th>
                <th> Người gửi </th>
                <th> SĐT </th>
                <th> Người nhận </th>
                <th> SĐT  </th>
                <th> SL </th>
                <th> Hàng </th>
            </tr>
            <tr class="td">
                <td><asp:CheckBox id="s" runat="server" Text=" "/></td>
                <td colspan="9" > Văn phòng TP. HCM của hàng Thiên Phú</td>
            </tr>
            <tr>
                <td ><asp:RadioButton runat="server" Text="Chưa cước" ID="abc" GroupName="cuoc" /><asp:RadioButton ID="RadioButton1" Style="margin-left:10px" runat="server" Text="Cước rồi" GroupName="cuoc" Checked="True" /></td>
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="abx" /></td>
               </tr>
        </table>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Item 1</asp:ListItem>
            <asp:ListItem>Item 2</asp:ListItem>
            <asp:ListItem>Item 3</asp:ListItem>
            <asp:ListItem>Item 4</asp:ListItem>
            <asp:ListItem>Item 5</asp:ListItem>
        </asp:DropDownList>
        
    </form>
</body>
</html>
