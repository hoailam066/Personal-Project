<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TTGiaoNhan.aspx.cs" Inherits="CSKH_TTGiaoNhan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/BanVe.css" rel="stylesheet" />
    <link href="../CSS/Gridview.css" rel="stylesheet" />
    <link href="../CSS/TTGiaoNhan.css" rel="stylesheet" />
     <meta name="viewport" content="width=device-width, maximum-scale=1, minimum-scale=1" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="divLon">
        <table style="width:100%">
            <tr> <td class="title">Thông tin giao nhận</td></tr>
        </table>
     <div class="divDong divmargintop" style="text-align:center; "><asp:Label runat="server" CssClass="font" Text="Công ty TNHH Dịch vụ Vận Tải ABC" ID="lblTieuDe"></asp:Label>
     </div>
        <div class="divDong" style="text-align:center;" > <asp:TextBox runat="server" CssClass="textboxtimkiem" ID="txtTimKiem"  placeholder="Mã hàng  |  Số điện thoại" ></asp:TextBox></div>

           <div class="divLon">
                <asp:Repeater runat="server" ID="rptCSKH">
                    <HeaderTemplate>
                        <table id="tbl" style="width: 99%; margin-left: 0.5%" cellspacing="0" cellpadding="0">
                            <tr class="th">
                                <td class="brl brb brt" style="font-weight: bold;width:5%">STT</td>
                                <td class="brl brb brt" style="font-weight: bold;width:7%">Ngày</td>
                                <td class="brl brb brt" style="font-weight: bold;width:15%">Người gửi</td>
                                <td class="brl brb brt" style="font-weight: bold;width:10%">SĐT</td>
                                <td class="brl brb brt" style="font-weight: bold;width:15%">Người nhận</td>
                                <td class="brl brb brt" style="font-weight: bold;width:10%">SĐT</td>
                                <td class="brl brb brt" style="font-weight: bold;width:15%">Tuyến</td>
                                <td class="brl brb brt brr" style="font-weight: bold;width:13%">Tình trạng</td>
                                <td class="brl brb brt brr" style="font-weight: bold;width:10%">Chi tiết </td>
                            </tr>
                    </HeaderTemplate>
                    
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

    </div>
    </form>
</body>
</html>
