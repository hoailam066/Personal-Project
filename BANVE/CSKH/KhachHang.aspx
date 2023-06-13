<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KhachHang.aspx.cs" Inherits="CSKH_KhachHang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/BanVe.css" rel="stylesheet" />
    <link href="../CSS/HideMenu.css" rel="stylesheet" />
    <link href="../CSS/Gridview.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, maximum-scale=1, minimum-scale=1" />
    <link href="../CSS/KhacHang.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="divLon box">
            <table style="width: 100%">
                <tr>
                    <td class="title">THÔNG TIN CHUNG </td>
                </tr>
            </table>
            <div class="divDong">
                <asp:Label ID="lbltieuDe" runat="server" CssClass="font" Text="Nhập thông tin khách hàng"></asp:Label>
            </div>
            <div class="divDong">
                <div class="divCon1">
                    <div class="divDong">
                        <div class="divLabel">
                            <asp:Label runat="server" ID="lblTen" Text="Tên:"></asp:Label>
                        </div>
                        <div class="divControl">
                            <asp:TextBox runat="server" ID="txtTen" Width="100%" CssClass="textboxthuong"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="divCon1">
                    <div class="divDong">
                        <div class="divLabel">
                            <asp:Label runat="server" ID="lblSDT" Text="SĐT:"></asp:Label>
                        </div>
                        <div class="divControl">
                            <asp:TextBox runat="server" ID="txtSDT" Width="100%" CssClass="textboxthuong"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="divCon2">
                    <div class="divDong">
                        <div class="divLabelDiaChi">
                            <asp:Label runat="server" ID="lblDiaChi" Text="Địa chỉ:"></asp:Label>
                        </div>
                        <div class="divcontrolDiaChi">
                            <asp:TextBox runat="server" ID="txtDiaChi" Width="100%" CssClass="textboxthuong"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="divDong">
                <div class="divCon1">
                    <div class="divDong">
                        <div class="divLabel">
                            <asp:Label runat="server" ID="lblChucVu" Text="Chức vụ:"></asp:Label>
                        </div>
                        <div class="divControl">
                            <asp:TextBox runat="server" ID="txtChucVu" Width="100%" CssClass="textboxthuong"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="divCon1">
                    <div class="divDong">
                        <div class="divLabel">
                            <asp:Label runat="server" ID="lblNgay" Text="Ngày:"></asp:Label>
                        </div>
                        <div class="divControl">
                            <asp:TextBox runat="server" ID="txtNgay" Width="100%" CssClass="textboxthuong"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="divCon1">
                    <div class="divDong">
                        <div class="divLabel">
                            <asp:Label runat="server" ID="lblLoaiKH" Text="Loại KH:"></asp:Label>
                        </div>
                        <div class="divControl">
                            <asp:TextBox runat="server" ID="txtLoaiKH" Width="100%" CssClass="textboxthuong"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="divCon1">
                    <div class="divDong">
                        <div class="divlabelNhomKH">
                            <asp:Label runat="server" ID="lblNhomKH" Text="Nhóm KH:"></asp:Label>
                        </div>
                        <div class="divtxtNhomKH">
                            <asp:TextBox runat="server" ID="txtNhomKH" Width="100%" CssClass="textboxthuong"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="divDong" style="text-align: center;margin-bottom:10px;">
                <asp:Button runat="server" ID="btnThem" Text="Thêm" CssClass="button mauBTThem " />
            </div>
        </div>

        <div class="divLon box">
            <table style="width: 100%">
                <tr>
                    <td class="title">DANH SÁCH KHÁCH HÀNG</td>
                </tr>
            </table>
            <div class="divDong" style="margin-bottom:10px;">
                <div class="divbutton1" style="text-align: center">
                    <asp:Button runat="server" CssClass="button mauBTCSKH" Text="Cá nhân" ID="btnCaNhan" /></div>
                <div class="divbutton2" style="text-align: center">
                    <asp:Button runat="server" CssClass="button maubt" Text="Nhóm" ID="btnNhom" /></div>
            </div>

            <div class="divLon">
                <asp:Repeater runat="server" ID="rptCSKH">
                    <HeaderTemplate>
                        <table id="tbl" style="width: 99%; margin-left: 0.5%" cellspacing="0" cellpadding="0">
                            <tr class="th">
                                <td class="brl brb brt" style="font-weight: bold;width:5%">STT</td>
                                <td class="brl brb brt" style="font-weight: bold;width:7%">Ngày</td>
                                <td class="brl brb brt" style="font-weight: bold;width:15%">Tên khách hàng</td>
                                <td class="brl brb brt" style="font-weight: bold;width:10%">SĐT</td>
                                <td class="brl brb brt" style="font-weight: bold;width:10%">PV Hàng</td>
                                <td class="brl brb brt" style="font-weight: bold;width:7%">PV Vé</td>
                                <td class="brl brb brt" style="font-weight: bold;width:9%">Chức vụ</td>
                                <td class="brl brb brt brr" style="font-weight: bold;width:7%">Loại KH</td>
                                <td class="brl brb brt brr" style="font-weight: bold;width:20%">Địa chỉ </td>
                                <td class="brl brb brt brr" style="font-weight: bold;width:10%">Thao tác</td>
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
