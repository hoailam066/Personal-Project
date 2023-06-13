<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThaoTacNangCao.aspx.cs" Inherits="CSKH_ThongTinBanVe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/BanVe.css" rel="stylesheet" />
    <link href="../CSS/ThaoTacNangcao.css" rel="stylesheet" />
    <link href="../CSS/HideMenu.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, maximum-scale=1, minimum-scale=1" />
    <link href="../CSS/DropDownList.css" rel="stylesheet" />
    <link href="../CSS/DropList.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="divLon">
            <div class="divCon1 box">
                <table style="width: 100%">
                    <tr>
                        <td class="title">THÔNG TIN TUYẾN XE</td>
                    </tr>
                </table>
                <div class="divThongtin1">
                    <div class="divDong">
                        <div class="divLabelNho">
                            <asp:Label runat="server" ID="lblNgay" Text="Ngày:"></asp:Label>
                        </div>
                        <div class="divControlNho">
                            <asp:TextBox runat="server" CssClass="txt" ID="txtNgay" Text="29/08/2017"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divDong">
                        <div class="divLabel">
                            <asp:Label runat="server" ID="lblGioKhoiHanh" Text="Giờ khởi hành:"></asp:Label>
                        </div>
                        <div class="divControl dropdownlist">
                            <asp:DropDownList runat="server" CssClass="droplist" ID="drlGioKhoiHanh">
                                <asp:ListItem> -- Tất cả -- </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="divThongtin2">
                    <div class="divDong">
                        <div class="divLabelNho">
                            <asp:Label runat="server" Text="Tuyến xe:" ID="lblTuyenXe"></asp:Label>
                        </div>
                        <div class="divControlNho dropdownlist ">
                            <asp:DropDownList runat="server" ID="drlTuyenXe" Width="100%" CssClass="droplist">
                                <asp:ListItem>TP.HCM - Kiên Giang </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="divDong">
                        <div class="divLabelNho">
                            <asp:Label runat="server" Text="Loại xe: " ID="lblLoaiXe"></asp:Label>
                        </div>
                        <div class="divControlNho dropdownlist">
                            <asp:DropDownList runat="server" ID="drlLoaiXe" CssClass="droplist">
                                <asp:ListItem>-- Tất cả -- </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="divLon">
                    <div class="divDong" style="margin-top: 3%;">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A1" ID="Label1" ></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A2" ID="lblA2"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B1" ID="lblB1"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B2" ID="lblB2"></asp:Label>
                        </div>
                    </div>
                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A3" ID="lblA3"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A4" ID="lblA4"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B3" ID="lblB3"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B4" ID="lblB4"></asp:Label>
                        </div>
                    </div>

                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A5" ID="lblA5"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A6" ID="lblA6"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B5" ID="lblB5"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B6" ID="lblB6"></asp:Label>
                        </div>
                    </div>

                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A7" ID="lblA7"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A8" ID="lblA8"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B7" ID="lblB7"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B8" ID="lblB8"></asp:Label>
                        </div>
                    </div>

                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A9" ID="lblA9"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A10" ID="lblA10"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B9" ID="lblB9"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B10" ID="lbl10"></asp:Label>
                        </div>
                    </div>

                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A11" ID="lblA11"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A12" ID="lblA12"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B11" ID="lblB11"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B12" ID="lblB12"></asp:Label>
                        </div>
                    </div>

                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A13" ID="lblA13"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A14" ID="lblA14"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B13" ID="lblB13"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B14" ID="lblB14"></asp:Label>
                        </div>
                    </div>

                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A15" ID="lblA15"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A16" ID="lblA16"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B15" ID="lblB15"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B16" ID="lblB16"></asp:Label>
                        </div>
                    </div>

                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A17" ID="lblA17"></asp:Label>
                        </div>
                        <div class="divHinh VeDaiLyBan">
                            <asp:Label runat="server" Text="A18" ID="lblA18"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B17" ID="lblB17"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B18" ID="lblB18"></asp:Label>
                        </div>
                    </div>

                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A19" ID="lblA19"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A20" ID="lblA20"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B19" ID="lblB19"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B20" ID="lblB20"></asp:Label>
                        </div>
                    </div>


                    <div class="divDong" style="margin-bottom:3%;">
                        <div class="divHinh VeDaThuTien">
                            <asp:Label runat="server" Text="A21" ID="lblA21"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A22" ID="lblA22"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A23" ID="lblA23"></asp:Label></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B21" ID="lblB21"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B22" ID="lblB22"></asp:Label>
                        </div>
                    </div>

                </div>





            </div>
            <div class="divCon2 box">
                <table style="width: 100%">
                    <tr>
                        <td class="title">THÔNG TIN TUYẾN XE</td>
                    </tr>
                </table>
                <div class="divThongtin1">
                    <div class="divDong">
                        <div class="divLabelNho">
                            <asp:Label runat="server" ID="lblNgayTX" Text="Ngày:"></asp:Label>
                        </div>
                        <div class="divControlNho">
                            <asp:TextBox runat="server" CssClass="txt" ID="txtNgayTX" Text="29/08/2017"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divDong">
                        <div class="divLabel">
                            <asp:Label runat="server" ID="lblGioKhoiHanhTX" Text="Giờ khởi hành:"></asp:Label>
                        </div>
                        <div class="divControl dropdownlist">
                            <asp:DropDownList Width="100%" runat="server" CssClass="droplist" ID="drlGioKhoiHanhTX">
                                <asp:ListItem> -- Tất cả -- </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="divThongtin2">
                    <div class="divDong">
                        <div class="divLabelNho">
                            <asp:Label runat="server" Text="Tuyến xe:" ID="lblTuyenXeTX"></asp:Label>
                        </div>
                        <div class="divControlNho dropdownlist">
                            <asp:DropDownList runat="server" ID="drlTuyenXeTX" Width="100%" CssClass="droplist">
                                <asp:ListItem>TP.HCM - Kiên Giang </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="divDong">
                        <div class="divLabelNho">
                            <asp:Label runat="server" Text="Loại xe: " ID="lblLoaiXeTX"></asp:Label>
                        </div>
                        <div class="divControlNho dropdownlist">
                            <asp:DropDownList runat="server" ID="drlLoaiXeTX" CssClass="droplist">
                                <asp:ListItem>-- Tất cả -- </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="divLon">
                    <div class="divDong" style="margin-top: 3%;">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A1" ID="lblA1TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A2" ID="lblA2TX"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B1" ID="lblB1TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B2" ID="lblB2TX"></asp:Label>
                        </div>
                    </div>
                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A3" ID="lblA3TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A4" ID="lblA4TX"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B3" ID="lblB3TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B4" ID="lblB4TX"></asp:Label>
                        </div>
                    </div>

                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A5" ID="lblA5TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A6" ID="lblA6TX"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B5" ID="lblB5TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B6" ID="lblB6TX"></asp:Label>
                        </div>
                    </div>

                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A7" ID="lblA7TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A8" ID="lblA8TX"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B7" ID="lblB7TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B8" ID="lblB8TX"></asp:Label>
                        </div>
                    </div>

                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A9" ID="lblA9TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A10" ID="lblA10TX"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B9" ID="lblB9TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B10" ID="lblB10TX"></asp:Label>
                        </div>
                    </div>

                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A11" ID="lblA11TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A12" ID="lblA12TX"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B11" ID="lblB11TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B12" ID="lblB12TX"></asp:Label>
                        </div>
                    </div>

                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A13" ID="lblA13TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A14" ID="lblA14TX"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B13" ID="lblB13TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B14" ID="lblB14TX"></asp:Label>
                        </div>
                    </div>

                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A15" ID="lblA15TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A16" ID="lblA16TX"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaThuTien">
                            <asp:Label runat="server" Text="B15" ID="lblB15TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B16" ID="lblB16TX"></asp:Label>
                        </div>
                    </div>

                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A17" ID="lblA17TX"></asp:Label>
                        </div>
                        <div class="divHinh VeDaiLyBan">
                            <asp:Label runat="server" Text="A18" ID="lblA18TX"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B17" ID="lblB17TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B18" ID="lblB18TX"></asp:Label>
                        </div>
                    </div>

                    <div class="divDong">
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A19" ID="lblA19TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A20" ID="lblA20TX"></asp:Label>
                        </div>
                        <div class="divTrong"></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B19" ID="lblB19TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B20" ID="lblB20TX"></asp:Label>
                        </div>
                    </div>


                    <div class="divDong" style="margin-bottom:3%;">
                        <div class="divHinh VeDaThuTien">
                            <asp:Label runat="server" Text="A21" ID="lblA21TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A22" ID="lblA22TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="A23" ID="lblA23TX"></asp:Label></div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B21" ID="lblB21TX"></asp:Label>
                        </div>
                        <div class="divHinh VeChuaDat">
                            <asp:Label runat="server" Text="B22" ID="lblB22TX"></asp:Label>
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </form>
</body>
</html>
