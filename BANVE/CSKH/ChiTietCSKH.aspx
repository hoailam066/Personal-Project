<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChiTietCSKH.aspx.cs" Inherits="CSKH_ChiTietCSKH" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/RaidoBoTron.css" rel="stylesheet" />
    <link href="../CSS/BanVe.css" rel="stylesheet" />
    <link href="../CSS/HideMenu.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, maximum-scale=1, minimum-scale=1" />
    <link href="../CSS/ChiTietCSKH.css" rel="stylesheet" />
    <link href="../CSS/Radio.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="divLon box ">
            <table style="width: 100%">
                <tr>
                    <td class="title">THÔNG TIN CHI TIẾT</td>
                </tr>
            </table>

            <div class="divLon" style="text-align: center; margin-top: 2%;">
                <asp:Label runat="server" Text="CÔNG TY TNHH DỊCH VỤ VẬN TẢI ABC" CssClass="font"></asp:Label>
            </div>
            <div class="divLon" style="text-align: center; margin-top: 2%;">
                <asp:TextBox runat="server" ID="txtTimKiem" CssClass="textboxtimkiem" placeholder="Mã hàng  |  Số điện thoại"></asp:TextBox>
            </div>


            <div class="divDong" style="margin-left: 10px; margin-top: 2%">
                <asp:Label runat="server" Text="Thời gian:" CssClass="lbl"></asp:Label>
                <asp:TextBox runat="server" Width="50%" CssClass="txt" Style="color: red" Text="26/08/2017" ID="txtGio"></asp:TextBox>
            </div>


            <div class="divLon">
                <div class="divCon1">
                    <div class="divDong">
                        <asp:Label runat="server" CssClass="titleNoiDung" Text="Thông tin chi tiết"></asp:Label>
                    </div>
                    <div class="divDong">
                                <div class="divDong">
                                    <div class="divLabelChiTiet">
                                        <asp:Label runat="server" Text="- Tuyến:" ID="lblTuyen"></asp:Label>
                                    </div>
                                    <div class="divControlChitiet">
                                        <asp:TextBox runat="server" CssClass="txt" ID="txtTuyen" Width="100%" Text="TP.HCM - Phương Lâm"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="divDong">
                                    <div class="divLabelChiTiet">
                                        <asp:Label runat="server" Text="- Người gửi:" ID="lblNguoiGui"></asp:Label>
                                    </div>
                                    <div class="divControlChitiet">
                                        <asp:TextBox runat="server" CssClass="txt txtTenRieng" ID="txtNguoiGui" Width="100%" Text="Trần văn a"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="divDong">
                                    <div class="divLabelChiTiet">
                                        <asp:Label runat="server" Text="- SĐT:" ID="lblSDT"></asp:Label>
                                    </div>
                                    <div class="divControlChitiet">
                                        <asp:TextBox runat="server" CssClass="txt" ID="txtSDT" Width="100%" Text="01648006816"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="divDong">
                                    <div class="divLabelChiTiet">
                                        <asp:Label runat="server" Text="- Người nhận:" ID="lblNguoiNhan"></asp:Label>
                                    </div>
                                    <div class="divControlChitiet">
                                        <asp:TextBox runat="server" CssClass="txt txtTenRieng" ID="txtNguoiNhan" Width="100%" Text="Trần văn b"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="divDong">
                                    <div class="divLabelChiTiet">
                                        <asp:Label runat="server" Text="- SĐT:" ID="lblSDTNN"></asp:Label>
                                    </div>
                                    <div class="divControlChitiet">
                                        <asp:TextBox runat="server" CssClass="txt " ID="txtSDTNguoiNhan" Width="100%" Text="0966170493"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="divDong">
                                    <div class="divLabelChiTiet">
                                        <asp:Label runat="server" Text="- Lưu ý:" ID="lblLuuY"></asp:Label>
                                    </div>
                                    <div class="divControlChitiet">
                                        <asp:TextBox runat="server" CssClass="textboxthuong "  ID="txtLuuY" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                        <div class="divDong">
                            <hr class="hr" />
                        </div>

                        <div class="divDong">
                            <asp:Label runat="server" Text="Thông tin hàng" ID="lblTTH" CssClass="titleNoiDung"></asp:Label>
                        </div>
                        <div class="divDong">
                                    <div class="divDong">
                                        <div class="divLabelChiTiet">
                                            <asp:Label runat="server" Text="- Hàng:" ID="lblHang"></asp:Label>
                                        </div>
                                        <div class="divControlChitiet">
                                            <asp:TextBox runat="server" ID="txtHang" Width="100%" CssClass="textboxthuong"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="divDong">
                                        <div class="divLabelChiTiet">
                                            <asp:Label runat="server" Text="- Ghi chú:" ID="lblGhiChuHang"></asp:Label>
                                        </div>
                                        <div class="divControlChitiet">
                                            <asp:TextBox runat="server" ID="txtGhiChuHang" Width="100%" CssClass="textboxthuong"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="divDong">
                                        <div class="divLabelChiTiet">
                                            <asp:Label runat="server" Text="- SL:" ID="lblSoLuong"></asp:Label>
                                        </div>
                                        <div class="divControlChitiet">
                                            <asp:TextBox runat="server" ID="txtSoLuong" Width="100%" CssClass="textboxthuong"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="divDong">
                                        <div class="divLabelChiTiet">
                                            <asp:Label runat="server" Text="- Ước giá:" ID="lblUocgia"></asp:Label>
                                        </div>
                                        <div class="divControlChitiet">
                                            <asp:TextBox runat="server" ID="txtUocGia" Width="100%" CssClass="textboxthuong"></asp:TextBox>
                                        </div>
                                    </div>
                        </div>
                        <div class="divDong">
                            <div class="divRadio1 rdb" style="text-align: center;">
                                <asp:RadioButton Checked="true" Text="Đã thanh toán" ID="rdbDaThanhToan" runat="server" GroupName="CuocPhi" />
                            </div>
                            <div class="divRadio2 rdb" style="text-align: center">
                                <asp:RadioButton Text="Chưa thanh toán" ID="rdbChuaThanhToan" runat="server" GroupName="CuocPhi" />
                            </div>
                        </div>
                       
                    </div>
                </div>


                <div class="divCon2">
                    <div class="divDong">
                        <asp:Label runat="server" CssClass="titleNoiDung" Text="Tình trạng hàng"></asp:Label>
                    </div>
                    <div class="divDong">
                        <asp:Label Style="margin-left: 25px" runat="server" Text="Kho hàng" CssClass="lbl"></asp:Label></div>
                    <div class="divDong">
                                <div class="divDong">
                                    <div class="divLabelKhoHang">
                                        <asp:Label runat="server" Text="- Thời gian nhận:" ID="lblThoiGianNhan"></asp:Label></div>
                                    <div class="divControlKhoHang">
                                        <asp:TextBox runat="server" ID="txtThoiGianNhan" CssClass="textboxthuong tdtextbox"></asp:TextBox></div>
                                </div>
                                <div class="divDong">
                                    <div class="divLabelKhoHang">
                                        <asp:Label runat="server" Text="- Nhân viên nhận:" ID="lblNVNhan"></asp:Label></div>
                                    <div class="divControlKhoHang">
                                        <asp:TextBox runat="server" ID="txtNVNhan" CssClass="textboxthuong tdtextbox"></asp:TextBox></div>
                                </div>
                                <div class="divDong">
                                    <div class="divLabelKhoHang">
                                        <asp:Label runat="server" Text="- Trưởng ca:" ID="lblTruongCa"></asp:Label></div>
                                    <div class="divControlKhoHang">
                                        <asp:TextBox runat="server" ID="txtTruongCa" CssClass="textboxthuong tdtextbox"></asp:TextBox></div>
                                </div>
                                <div class="divDong">
                                    <div class="divLabelKhoHang">
                                        <asp:Label runat="server" Text="- Bốc xếp:" ID="lblBocXep"></asp:Label></div>
                                    <div class="divControlKhoHang">
                                        <asp:TextBox runat="server" ID="txtBocXep" CssClass="textboxthuong tdtextbox"></asp:TextBox></div>
                                </div>
                        <div class="divDong">
                            <div class="divLabel">
                                <asp:Label runat="server" Text="Xe vận chuyển:" ID="lblXeVanChuyen"></asp:Label></div>
                            <div class="divControl">
                                <asp:TextBox runat="server" ID="txtXeVanChuyen" Width="100%" CssClass="textboxthuong"></asp:TextBox></div>
                        </div>
                        <div class="divDong">
                            <div class="divLabel">
                                <asp:Label runat="server" Text="Kho xuống:" ID="lblKhoXuong"></asp:Label></div>
                            <div class="divControl">
                                <asp:TextBox runat="server" ID="txtKhoXuong" Width="100%" CssClass="textboxthuong"></asp:TextBox></div>
                        </div>
                        <div class="divDong">
                            <div class="divLabel">
                                <asp:Label  runat="server" Text="Trung chuyển:" ID="lblTrungChuyen"></asp:Label></div>
                            <div class="divControl">
                                <asp:TextBox runat="server" ID="txtTrungChuyen" Width="100%" CssClass="textboxthuong"></asp:TextBox></div>
                        </div>
                        <div class="divDong">
                            <div class="divLabel">
                                <asp:Label  runat="server" Text="Điểm cuối:" ID="lblDiemCuoi"></asp:Label></div>
                            <div class="divControl">
                                <asp:TextBox runat="server" ID="txtDiemCuoi" Width="100%" CssClass="textboxthuong"></asp:TextBox></div>
                        </div>
                        <div class="divDong">
                            <div class="divLabel">
                                <asp:Label  runat="server" Text="Khách hàng nhận:" ID="lblKHNhan"></asp:Label></div>
                            <div class="divControl">
                                <asp:TextBox runat="server" ID="txtKHNhan" Width="100%" CssClass="textboxthuong"></asp:TextBox></div>
                        </div>
                        <div class="divDong">
                            <div class="divLabel">
                                <asp:Label  runat="server" Text="Ghi chú nhận hàng:" ID="lblGCNhanHang"></asp:Label></div>
                            <div class="divControl">
                                <asp:TextBox runat="server" ID="txtGCNhanHang" Width="100%" CssClass="textboxthuong"></asp:TextBox></div>
                        </div>
                        <div class="divDong">
                            <div class="divLabel">
                                <asp:Label  runat="server" Text="Ghi chú giao hàng:" ID="lblGCGiaoHang"></asp:Label></div>
                            <div class="divControl">
                                <asp:TextBox runat="server" ID="txtGCGiaoHang" Width="100%" CssClass="textboxthuong"></asp:TextBox></div>
                        </div>
                        <div class="divDong">
                            <div class="divLabel">
                                <asp:Label  runat="server" Text="Ghi chú nhân viên:" ID="lblGCNV"></asp:Label></div>
                            <div class="divControl">
                                <asp:TextBox runat="server" ID="txtGCNV" Width="100%" CssClass="textboxthuong"></asp:TextBox></div>
                        </div>
                       
                    </div>
                </div>
                <div class="divDong">
                    <div class="divChiPhi1">
                            <div class=" cplabel">
                                <asp:Label runat="server" ID="lblChiPhi" Text="Chi Phí:"></asp:Label>
                            </div>
                            <div class=" cpcontrol">
                                <asp:TextBox runat="server" ID="txtChiPhi" CssClass="textboxTien txt" Width="100%" Text="60.000đ"></asp:TextBox>
                            </div>
                    </div>
                    <div class="divChiPhi2" >
                         <asp:Button runat="server" ID="btnGhiNhan" CssClass="button maubt" Text="Ghi nhận" />
                    </div>
                </div>
            </div>
            <div class="divLon">
                 <div class="divDong">
                        <asp:Label runat="server" CssClass="titleNoiDung" Text="Biên bản ghi nhận"></asp:Label>
                    </div>
                <div class="divDong">
                    <div class="divLabelBienBan">
                        <asp:Label runat="server" ID="lblTenKH" Text="Tên KH:"></asp:Label>
                    </div>
                    <div class="divControlBienBan"><asp:TextBox runat="server" Width="100%" ID="txtTenKH" CssClass="txt txtTenRieng" Text="Trần văn a"></asp:TextBox></div>
                </div>
                <div class="divDong">
                    <div class="divLabelBienBan"> <asp:Label runat="server"  ID="lblNoiDung" Text="Nội dung:"></asp:Label></div>
                    <div class="divControlBienBan"> <asp:TextBox runat="server" Width="100%" ID="txtNoiDung" CssClass="textboxthuong"></asp:TextBox></div>
                </div>
                  <div class="divDong">
                    <div class="divLabelBienBan"> <asp:Label runat="server"  ID="lblDeXuat" Text="Đề xuất ý kiến:"></asp:Label></div>
                    <div class="divControlBienBan"> <asp:TextBox runat="server" Width="100%" ID="txtDeXuat" CssClass="textboxthuong"></asp:TextBox></div>
                </div>

                <div class="divDong rdbbotron" style="margin-left:10px" >
                    <asp:RadioButton runat="server" Checked="true" Text="Tự giải quyết" ID="rdbTuGiaiQuyet" GroupName="GiaiQuyet"  />
                </div>
                <div class="divDong radio" style="margin-left:30px">
                    <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" >
                        <asp:ListItem Text="Lần 1">  </asp:ListItem>
                         <asp:ListItem Text="Lần 2">  </asp:ListItem>
                         <asp:ListItem Text="Lần 3">  </asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="divDong rdbbotron" style="margin-left:10px">
                    <asp:RadioButton runat="server"  Text="Xin ý kiến cấp trên" ID="rdbXinYKien" GroupName="GiaiQuyet" />
                </div>
                <div class="divDong"  style="margin-bottom:10px">
                    <div class="divCon1" style="text-align:center">
                        <asp:Button runat="server" ID="btnLuuvaChuyen" CssClass="button maubt" Text="Lưu & Chuyển" />
                    </div>
                </div>
            </div>

        </div>

       
    </form>
</body>
</html>
