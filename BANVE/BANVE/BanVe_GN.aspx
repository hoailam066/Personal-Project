<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BanVe_GN.aspx.cs" Inherits="BANVE_BanVe_GN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/BanVe.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, maximum-scale=1, minimum-scale=1" />
    <link href="../CSS/BanVe_GN.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="divLon box">
            <table style="width: 100%">
                <tr>
                    <td class="title">Sơ đồ ghế ngồi</td>
                </tr>
            </table>
            <div class="divLon">
                <div class="divDong" style="text-align: center">
                    <asp:Label runat="server" ID="lblSoXe" Text="51A 000.01" CssClass="LabelSoXe"></asp:Label>
                </div>
                <div class="divDong " style="text-align: center">
                    <div class="divLabelSoGhe">
                        <asp:Label runat="server" CssClass="lbl" Text="Ghế Sub:" ID="lblGheSub"></asp:Label>
                    </div>
                    <div class="divLabelGhe">
                        <asp:Label runat="server" ID="lblSoGheSub" CssClass="SoGhe lbl" Text="10"></asp:Label>
                    </div>
                    <div class="divLabelGhe">
                        <asp:Label runat="server" Text="ghế" ID="lblGhe" CssClass="lbl"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="divDong">
                <div class=" divCon" style="text-align: center">
                    <asp:Button runat="server" ID="btnInDanhSach" Text="IN DANH SÁCH" CssClass="button maubtInDS buttonInDS" />
                </div>
                <div class="divCon1" style="text-align: center">
                    <asp:Button runat="server" ID="btnInDSDon" Text="In danh sách đón khách" CssClass="button maubtnInDSDonKhach" />
                </div>
            </div>

           
                <div class="divXeTrai">
                    <div class="divDong">
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonDaBan">
                                    <asp:Label runat="server" ID="lblNoiDonDaBan" Text="N5.C Chó"></asp:Label>
                                </div>
                                <div class="divGheDaThu">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" ID="lblA1" Text="A1" CssClass="LableDaBan"></asp:Label>

                                    </div>
                                    <div class="divThongTin">
                                        <asp:Label runat="server" ID="lblSDT" Text="0966170493"></asp:Label><br />
                                        <asp:Label runat="server" ID="lblNhanVien" Text="Phương - 2G"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label1" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="A2" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label4" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="A3" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- --%>
                    <div class="divDong">
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label2" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="A4" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label7" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="A5" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label8" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="A6" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%--  --%>
                    <div class="divDong">
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label3" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="A7" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label5" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="A8" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label6" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="A9" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%--  --%>

                    <div class="divDong">
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label9" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="A10" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                    </div>
                                    <%-- Nội dung --%>
                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonVeDLBan">
                                    <asp:Label runat="server" ID="Label10" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheDaiLyBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="A11" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                         <asp:Label runat="server" ID="Label22" Text="0966170493" CssClass="Label"></asp:Label><br />
                                        <asp:Label runat="server" ID="Label23" Text="Phương - 2G" CssClass="Label"></asp:Label>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>

                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label11" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="A12" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--  --%>

                    <div class="divDong">
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label12" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="A13" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label13" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="A14" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label14" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="A15" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--  --%>

                    <div class="divDong">
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label15" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="A16" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                    </div>
                                    <%-- Nội dung --%>
                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label16" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="A18" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                    </div>
                                    <%-- Nội dung --%>
                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonVeBanChuaThu">
                                    <asp:Label runat="server" ID="Label17" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheBanChuaThu">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="A20" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>

                                </div>
                            </div>
                        </div>
                        </div>
                        <%--  --%>
                    <div class="divDong">
                            <div class="divXe" style="text-align: center">
                                <div class="divHinh">
                                    <div class="NoidonChuaBan">
                                        <asp:Label runat="server" ID="Label18" Text="Nơi đón khách"></asp:Label>
                                    </div>
                                    <div class="divGheChuaBan">
                                        <div class="divSoGhe">
                                            <asp:Label runat="server" Text="A17" CssClass="LabelChuaBan"></asp:Label>
                                        </div>
                                        <div class="divThongTin">
                                        </div>
                                        <%-- Nội dung --%>
                                    </div>
                                </div>
                            </div>
                            <div class="divXe1" style="text-align: center">
                                <div class="divHinh">
                                    <div class="NoidonChuaBan">
                                        <asp:Label runat="server" ID="Label19" Text="Nơi đón khách"></asp:Label>
                                    </div>
                                    <div class="divGheChuaBan">
                                        <div class="divSoGhe">
                                            <asp:Label runat="server" Text="A19" CssClass="LabelChuaBan"></asp:Label>
                                        </div>
                                        <div class="divThongTin">
                                        </div>
                                        <%-- Nội dung --%>
                                    </div>
                                </div>
                            </div>
                        <div class="divXoayLabel divLabelTang">
                            <div id="myDiv">
                                Tầng dưới
                            </div>
                        </div>
                        </div>
                </div>

                <div class="divXePhai">
                    <div class="divDong">
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label20" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" ID="Label21" Text="B1" CssClass="LableDaBan"></asp:Label>

                                    </div>
                                    <div class="divThongTin">
                                       <%-- Nội dung--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label24" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="B2" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label25" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="B3" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- --%>
                    <div class="divDong">
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label26" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="B4" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label27" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="B5" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label28" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="B6" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%--  --%>
                    <div class="divDong">
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label29" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="B7" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label30" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="B8" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label31" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="B9" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%--  --%>

                    <div class="divDong">
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label32" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="B10" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                    </div>
                                    <%-- Nội dung --%>
                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label33" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="B11" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                    </div>
                                    <%-- Nội dung --%>
                                </div>
                            </div>
                        </div>
                        <div class="divGhe">
                            <div class="divHinh">
                                <div class="NoidonChuaBan">
                                    <asp:Label runat="server" ID="Label34" Text="Nơi đón khách"></asp:Label>
                                </div>
                                <div class="divGheChuaBan">
                                    <div class="divSoGhe">
                                        <asp:Label runat="server" Text="B12" CssClass="LabelChuaBan"></asp:Label>
                                    </div>
                                    <div class="divThongTin">
                                        <%-- Nội dung --%>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--  --%>

                        <div class="divDong">
                            <div class="divGhe">
                                <div class="divHinh">
                                    <div class="NoidonChuaBan">
                                        <asp:Label runat="server" ID="Label35" Text="Nơi đón khách"></asp:Label>
                                    </div>
                                    <div class="divGheChuaBan">
                                        <div class="divSoGhe">
                                            <asp:Label runat="server" Text="B13" CssClass="LabelChuaBan"></asp:Label>
                                        </div>
                                        <div class="divThongTin">
                                            <%-- Nội dung --%>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="divGhe">
                                <div class="divHinh">
                                    <div class="NoidonChuaBan">
                                        <asp:Label runat="server" ID="Label36" Text="Nơi đón khách"></asp:Label>
                                    </div>
                                    <div class="divGheChuaBan">
                                        <div class="divSoGhe">
                                            <asp:Label runat="server" Text="B14" CssClass="LabelChuaBan"></asp:Label>
                                        </div>
                                        <div class="divThongTin">
                                            <%-- Nội dung --%>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="divGhe">
                                <div class="divHinh">
                                    <div class="NoidonChuaBan">
                                        <asp:Label runat="server" ID="Label37" Text="Nơi đón khách"></asp:Label>
                                    </div>
                                    <div class="divGheChuaBan">
                                        <div class="divSoGhe">
                                            <asp:Label runat="server" Text="B15" CssClass="LabelChuaBan"></asp:Label>
                                        </div>
                                        <div class="divThongTin">
                                            <%-- Nội dung --%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--  --%>

                        <div class="divDong">
                            <div class="divGhe">
                                <div class="divHinh">
                                    <div class="NoidonChuaBan">
                                        <asp:Label runat="server" ID="Label38" Text="Nơi đón khách"></asp:Label>
                                    </div>
                                    <div class="divGheChuaBan">
                                        <div class="divSoGhe">
                                            <asp:Label runat="server" Text="B16" CssClass="LabelChuaBan"></asp:Label>
                                        </div>
                                        <div class="divThongTin">
                                        </div>
                                        <%-- Nội dung --%>
                                    </div>
                                </div>
                            </div>
                            <div class="divGhe">
                                <div class="divHinh">
                                    <div class="NoidonChuaBan">
                                        <asp:Label runat="server" ID="Label39" Text="Nơi đón khách"></asp:Label>
                                    </div>
                                    <div class="divGheChuaBan">
                                        <div class="divSoGhe">
                                            <asp:Label runat="server" Text="B18" CssClass="LabelChuaBan"></asp:Label>
                                        </div>
                                        <div class="divThongTin">
                                        </div>
                                        <%-- Nội dung --%>
                                    </div>
                                </div>
                            </div>
                            <div class="divGhe">
                                <div class="divHinh">
                                    <div class="NoidonChuaBan">
                                        <asp:Label runat="server" ID="Label40" Text="Nơi đón khách"></asp:Label>
                                    </div>
                                    <div class="divGheChuaBan">
                                        <div class="divSoGhe">
                                            <asp:Label runat="server" Text="B20" CssClass="LabelChuaBan"></asp:Label>
                                        </div>
                                        <div class="divThongTin">
                                            <%-- Nội dung --%>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <%--  --%>
                            <div class="divDong">
                                <div class="divLabelTang divXoayLabel">
                                    <div id="myDiv1">
                                        Tầng trên
                                    </div>
                                </div>

                                <div class="divXe" style="text-align: center">
                                    <div class="divHinh">
                                        <div class="NoidonChuaBan">
                                            <asp:Label runat="server" ID="Label41" Text="Nơi đón khách"></asp:Label>
                                        </div>
                                        <div class="divGheChuaBan">
                                            <div class="divSoGhe">
                                                <asp:Label runat="server" Text="B17" CssClass="LabelChuaBan"></asp:Label>
                                            </div>
                                            <div class="divThongTin">
                                            </div>
                                            <%-- Nội dung --%>
                                        </div>
                                    </div>
                                </div>
                                <div class="divXe1" style="text-align: center">
                                    <div class="divHinh">
                                        <div class="NoidonChuaBan">
                                            <asp:Label runat="server" ID="Label42" Text="Nơi đón khách"></asp:Label>
                                        </div>
                                        <div class="divGheChuaBan">
                                            <div class="divSoGhe">
                                                <asp:Label runat="server" Text="B19" CssClass="LabelChuaBan"></asp:Label>
                                            </div>
                                            <div class="divThongTin">
                                            </div>
                                            <%-- Nội dung --%>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>





                </div>
        </div>
    </form>
</body>
</html>
