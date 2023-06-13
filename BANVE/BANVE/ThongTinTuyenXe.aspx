<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThongTinTuyenXe.aspx.cs" Inherits="BANVE_ThongTinTuyenXe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/ThongTinTuyenXe.css" rel="stylesheet" />
    <link href="../CSS/BanVe.css" rel="stylesheet" />
    <link href="../CSS/DropDownList.css" rel="stylesheet" />
    <link href="../CSS/Radio.css" rel="stylesheet" />
    <link href="../CSS/RaidoBoTron.css" rel="stylesheet" />
    <link href="../CSS/DropList.css" rel="stylesheet" />
    <link href="../CSS/CheckBox.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, maximum-scale=1, minimum-scale=1" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="divLon">
            <div class="divThongTinTuyenXe box">
                <table style="width: 100%">
                    <tr>
                        <td class="title">Thông Tin Tuyến Xe </td>
                    </tr>
                </table>
                <div class="divCon2">
                    <div class="divDong">
                        <div class="divLabelNgay lbl">
                            <asp:Label runat="server" ID="lblNgay" Text="Ngày:"></asp:Label>
                        </div>
                        <div class="divControlNgay">
                            <asp:TextBox runat="server" Width="100%" CssClass="txt" Text="29/08/2017" ID="txtNgay"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="divCon1">
                    <div class="divDong">
                        <div class="divLabelLXe lbl">
                            <asp:Label runat="server" ID="lblTuyenXe" Text="Tuyến xe:"></asp:Label>
                        </div>
                        <div class="divControlLXe dropdownlist">
                            <asp:DropDownList runat="server" CssClass="droplist" ID="drlTuyeXe">
                                <asp:ListItem> TP.HCM - Kiên Giang</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="divCon">
                    <div class="divDong">
                        <div class="divLabelTX lbl">
                            <asp:Label runat="server" ID="lblGioKhoiHanh" Text="Giờ khởi hành:"></asp:Label>
                        </div>
                        <div class="divControlTX dropdownlist">
                            <asp:DropDownList runat="server" CssClass="droplist" ID="drlGioKhoiHanh">
                                <asp:ListItem> -- Tất cả --</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                </div>
                <div class="divCon">
                    <div class="divDong">
                        <div class="divLabelLXe lbl">
                            <asp:Label runat="server" ID="lblLoaiXe" Text="Loại xe:"></asp:Label>
                        </div>
                        <div class="divControlLXe dropdownlist">
                            <asp:DropDownList runat="server" CssClass="droplist drl" ID="drlLoaiXe">
                                <asp:ListItem> -- Tất cả --</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="divDong lbl">
                    <asp:Label runat="server" Text="Xe 47" ID="lblIDXe"></asp:Label>
                </div>
                <div class="divDong">
                    <asp:Button runat="server" ID="btn10Gio" Text="10:00" CssClass="buttonSelect" />
                    <asp:Button runat="server" ID="btn11Gio" Text="11:00" CssClass="buttonthuong" />
                    <asp:Button runat="server" ID="btn12Gio" Text="12:00" CssClass="buttonthuong" />
                    <asp:Button runat="server" ID="btn13Gio" Text="13:00" CssClass="buttonthuong" />
                </div>

                <div class="divDong lbl">
                    <asp:Label runat="server" Text="Xe 25" ID="lblXe25"></asp:Label>
                </div>
                <div class="divDong" style="margin-bottom: 2%">
                    <asp:Button runat="server" ID="btn10" Text="10:00" CssClass="buttonthuong" />
                    <asp:Button runat="server" ID="btn11" Text="11:00" CssClass="buttonthuong" />
                    <asp:Button runat="server" ID="btn12" Text="12:00" CssClass="buttonthuong" />
                    <asp:Button runat="server" ID="bnt13" Text="13:00" CssClass="buttonthuong" />
                </div>
            </div>

            <div class="divThongTinKH">
                <div class="divCha box">
                    <table style="width: 100%">
                        <tr>
                            <td class="title">Thông tin khách hàng</td>
                        </tr>
                    </table>
                    <div class="divDong1">
                        <div class="divLabel ">
                            <asp:Label runat="server" ID="lblXeSo" Text="Xe số:"></asp:Label>
                        </div>
                        <div class="divControl">
                            <asp:TextBox runat="server" ID="txtXeSo" Text="51A 000.01" CssClass="txt" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divDong1 ">
                        <div class="divLabel">
                            <asp:Label runat="server" ID="lblSDT" Text="Số ĐT:"></asp:Label>
                        </div>
                        <div class="divControl">
                            <asp:TextBox runat="server" ID="txtSoDT" CssClass="textboxDen" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divDong1 ">
                        <div class="divLabel">
                            <asp:Label runat="server" ID="lblTenKH" Text="Tên KH:"></asp:Label>
                        </div>
                        <div class="divControl">
                            <asp:TextBox runat="server" ID="txtTenKH" CssClass="textboxDen" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divDong1 ">
                        <div class="divLabel">
                            <asp:Label runat="server" ID="lblDaiLy" Text="Đại lý:"></asp:Label>
                        </div>
                        <div class="divControl dropdown">
                            <asp:DropDownList runat="server" ID="drlDaiLy" CssClass="droplist" Width="100%"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="divDong1 ">
                        <div class="divLabel">
                            <asp:Label runat="server" ID="lblTu" Text="Từ:"></asp:Label>
                        </div>
                        <div class="divControl dropdown">
                            <asp:DropDownList runat="server" ID="drlu" CssClass="droplist" Width="100%"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="divDong1 ">
                        <div class="divLabel">
                            <asp:Label runat="server" ID="lblDen" Text="Đến:"></asp:Label>
                        </div>
                        <div class="divControl dropdown">
                            <asp:DropDownList runat="server" ID="drlDen" CssClass=" droplist" Width="100%"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="divDong1 ">
                        <asp:RadioButton Text="Tự đến" CssClass="radio divradio " runat="server" ID="rdbTuDen" GroupName="DonKhach" />
                        <asp:RadioButton Text="Dọc đường" CssClass="radio divradio1" runat="server" ID="rdbDocDuong" GroupName="DonKhach" />
                        <asp:RadioButton Text="Tận nhà" CssClass="radio divradio" runat="server" ID="rdbTanNha" GroupName="DonKhach" />
                    </div>
                    <div class="divDong1">
                        <asp:CheckBox runat="server"  ID="chkGheSub" Text="Ghế sub" />
                    </div>
                    <div class="divDong1">
                        <div class="divLabel">
                            <asp:Label runat="server" ID="lblMaGhe" Text="Mã ghế:"></asp:Label>
                        </div>
                        <div class="divControl">
                            <asp:TextBox runat="server" ID="txtMaGhe" CssClass="txt" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divDong1">
                        <hr class="hrDen" />
                    </div>
                    <div class="divDong1">
                        <div class="divLabelGiaVe">
                            <asp:Label runat="server" ID="lblDaChon" Text="Đã chọn:"></asp:Label>
                        </div>
                        <div class="divConTrolGiaVe">
                            <asp:TextBox CssClass="txt" runat="server" ID="txtDaChon" Width="100%" Text="0"></asp:TextBox>

                        </div>
                        <div class="divGhe">
                            <asp:Label runat="server" Text="ghế"></asp:Label>
                        </div>
                    </div>
                    <div class="divDong1">
                        <div class="divLabelGiaVe">
                            <asp:Label runat="server" ID="lblGiaVe" Text="Giá vé:"></asp:Label>
                        </div>
                        <div class="divConTrolGiaVe">
                            <asp:TextBox CssClass="txt" runat="server" ID="txtGiaVe" Width="100%" Text="0"></asp:TextBox>
                        </div>
                        <div class="divGhe">
                            <asp:Label runat="server" Text="VNĐ/ghế"></asp:Label>
                        </div>
                    </div>
                    <div class="divDong1 divTien">
                        <div class="divLabelThanhTien">
                            <asp:Label runat="server" Text="Thành tiền:" ID="lblThanhTien"></asp:Label>
                        </div>
                        <div class="divConTrolThanhtien">
                            <asp:TextBox runat="server" Style="background: #a3ce4e" Width="100%" CssClass="txt" ID="txtThanhTien"></asp:TextBox>
                        </div>
                        <div class="divVND">
                            <asp:Label runat="server" ID="lblLoaiTien" Text="VNĐ"></asp:Label>
                        </div>

                    </div>
                    <div class="divDong1 ">
                        <asp:CheckBox runat="server" ID="rdbDaThanhToan" Text="Đã thanh toán" />
                    </div>
                    <div class="divDong1 ">
                        <asp:CheckBox runat="server" ID="rdbVeKhongThuTien" Text="Vé không thu tiền" />
                        <asp:TextBox runat="server" ID="txtVeKhongThuTien" CssClass="textboxDen txtTienVe"></asp:TextBox>
                    </div>
                    <div class="divDong1">
                        <div class="divLabel">
                            <asp:Label runat="server" ID="lblGhiChu" Text="Ghi chú"></asp:Label>

                        </div>
                        <div class="divControl">
                            <asp:TextBox runat="server" ID="txtGhiChu" CssClass="txt" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divDong1 ">
                        <hr class="hrDen" />
                    </div>
                    <div class="divDong1">
                        <asp:Button runat="server" ID="btnHuy" Text="Hủy" CssClass="button maubtHuy divbt" />
                        <asp:Button runat="server" ID="btnLuu" Text="Lưu" CssClass="button maubtLuu divbt" />
                        <asp:Button runat="server" ID="btnIn" Text="In" CssClass="button maubtIn divbt " />
                        <asp:Button runat="server" ID="btnBoQua" Text="Bỏ qua" CssClass="button maubtBoQua divbt" />
                    </div>
                </div>


                <div class="divCha box">
                    <table style="width: 100%">
                        <tr>
                            <td class="title">Thống kê nhanh</td>
                        </tr>
                    </table>
                    <div class="divDong1">
                        <div class="divLabelTKTien">
                            <asp:Label ID="lblTongGheBan" Text="Tổng số ghế đã bán:" runat="server"></asp:Label></div>
                        <div class="divControlTKTien">
                            <asp:TextBox runat="server" Width="100%" CssClass="txt" ID="txtTongGheBan" Text="135"></asp:TextBox></div>
                        <div class="divLabelTKGhe">
                            <asp:Label runat="server" ID="lblGhe" Text="ghế"></asp:Label></div>
                    </div>
                    <div class="divDong1">
                        <div class="LabelTien">
                            <asp:Label ID="lblTienDaThu" Text="Tiền đã thu:" runat="server"></asp:Label></div>
                        <div class="ControlTien">
                            <asp:TextBox runat="server" Width="100%" CssClass="txt" ID="txtTienDaThu" Text="10.000.000"></asp:TextBox></div>
                        <div class="LabelD">
                            <asp:Label runat="server" ID="lblD" Text="đ"></asp:Label></div>
                    </div>
                    <div class="divDong1">
                        <div class="LabelTien">
                            <asp:Label ID="lblTienChuaThu" Text="Tiền chưa thu:" runat="server"></asp:Label></div>
                        <div class="ControlTien">
                            <asp:TextBox runat="server" Width="100%" CssClass="txt" ID="txtTienChuaThu" Text="3.500.000"></asp:TextBox></div>
                        <div class="LabelD">
                            <asp:Label runat="server" ID="lblD1" Text="đ"></asp:Label></div>
                    </div>
                    <div class="divDong1">
                        <div class="divLabelTKTien">
                            <asp:Label ID="lblXeXuatBen" Text=" Số xe xuất bến:" runat="server"></asp:Label></div>
                        <div class="divControlTKTien">
                            <asp:TextBox runat="server" Width="100%" CssClass="txt" ID="txtXeXuatBen" Text="10"></asp:TextBox></div>
                        <div class="divLabelTKGhe">
                            <asp:Label runat="server" ID="lblXe" Text="Xe"></asp:Label></div>
                    </div>
                </div>

            </div>

            <div class="divThongTinTuyenXe">
                <table style="width: 100%; height: 80%">
                    <tr>
                        <td class="title">Sơ đồ xe </td>
                    </tr>

                </table>
                <table style="width: 90%; height: 300px;"></table>
            </div>
          
        </div>
          <div class="divLon box">
                <div class="divCha ">
                    <table style="width: 100%">
                        <tr>
                            <td class="title">Kí Hiệu</td>
                        </tr>
                    </table>
                    <div class="divDong1">
                        <div class="divKiHieu1">
                            <div class="divDong1">
                                <div class="ControlKH">
                                    <div class="VeDaThuTien divLoaiVe"></div>
                                </div>
                                <div class="LabelKH">
                                    <asp:Label Text="Ghế đã thu" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="divKiHieu1">
                            <div class="divDong1">
                                <div class="ControlKH">
                                    <div class=" VeDangChon divLoaiVe"></div>
                                </div>
                                <div class="LabelKH">
                                    <asp:Label Text="Ghế đang chọn" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="divKiHieu1">
                            <div class="divDong1">
                                <div class="ControlKH">
                                    <div class="VeChuaThuTien divLoaiVe"></div>
                                </div>
                                <div class="LabelKH">
                                    <asp:Label Text="Ghế chưa thu" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="divKiHieu1">
                            <div class="divDong1">
                                <div class="ControlKH">
                                    <div class="VeNguoiDungKhacChon divLoaiVe"></div>
                                </div>
                                <div class="LabelKH">
                                    <asp:Label Text="Người dùng khác chọn" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="divKiHieu1">
                            <div class="divDong1">
                                <div class="ControlKH">
                                    <div class=" VeDaiLyBan divLoaiVe"></div>
                                </div>
                                <div class="LabelKH">
                                    <asp:Label Text="Ghế đại lý bán" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class=" divKiHieu1">
                            <div class="divDong1">
                                <div class="ControlLoaiDon ">
                                    <div class="divLoaiDon DonTanNha"></div>
                                </div>
                                <div class="LabelLoaiDon ">
                                    <asp:Label runat="server" Text="Đón khách tận nhà"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="divKiHieu1">
                            <div class="divDong1">
                                <div class="ControlLoaiDon">
                                    <div class="divLoaiDon DonDocDuong"></div>
                                </div>
                                <div class="LabelLoaiDon ">
                                    <asp:Label runat="server" Text="Đón khách dọc đường"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
