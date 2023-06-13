<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BanVe_SoDoGhe.aspx.cs" Inherits="BANVE_BanVe_SoDoGhe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/DropDownList.css" rel="stylesheet" />
    <link href="../CSS/BanVe_SoDoGhe.css" rel="stylesheet" />
    <link href="../CSS/dropdownlist.css" rel="stylesheet" />
    <link href="../CSS/CheckBox.css" rel="stylesheet" />
    <link href="../CSS/BanVe.css" rel="stylesheet" />
    <link href="../CSS/Radio.css" rel="stylesheet" />
    <link href="../CSS/RaidoBoTron.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, maximum-scale=1, minimum-scale=1" />
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

            <div class="divXePhai">
                <div class="divDong">
                    <div class="divXe1">
                        <div class="divHinh">
                            <div class="NoidonDaBan ">
                                <asp:Label runat="server" Text="N5 C.Chó"></asp:Label>
                            </div>
                            <div class="divGheDaThu ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A1" CssClass="LableDaBan"></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <asp:Label runat="server" ID="Label1" Text="01648006816" CssClass="Label"></asp:Label><br />
                                    <asp:Label runat="server" ID="Label2" Text="Phương - 2G" CssClass="Label"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="divXe2">
                        <div class="divHinh">
                            <div class="NoidonChuaBan ">
                                <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                            </div>
                            <div class="divGheChuaBan ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A2" CssClass="LabelChuaBan"></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <%--Nội Dung vé--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="divDong">
                    <div class="divXe1">
                        <div class="divTrong"></div>
                    </div>
                    <div class="divXe2">
                        <div class="divHinh">
                            <div class="NoidonChuaBan ">
                                <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                            </div>
                            <div class="divGheChuaBan ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A3" CssClass="LabelChuaBan"></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <%--Nội Dung vé--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            <div class="divDong">
                <div class="divXe1">
                    <div class="divHinh">
                        <div class="NoidonChuaBan ">
                            <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                        </div>
                        <div class="divGheChuaBan ">
                            <div class="divSoGhe">
                                <asp:Label runat="server" Text="A10" CssClass="LabelChuaBan"></asp:Label>
                            </div>
                            <div class="divThongTin">
                                <%--Nội Dung vé--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="divXe2">
                    <div class="divHinh">
                        <div class="NoidonChuaBan ">
                            <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                        </div>
                        <div class="divGheChuaBan ">
                            <div class="divSoGhe">
                                <asp:Label runat="server" Text="A11" CssClass="LabelChuaBan"></asp:Label>
                            </div>
                            <div class="divThongTin">
                                <%--Nội Dung vé--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="divDong">
                    <div class="divXe1">
                        <div class="divHinh">
                            <div class="NoidonChuaBan ">
                                <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                            </div>
                            <div class="divGheChuaBan ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A14" CssClass="LabelChuaBan"></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <%--Nội Dung vé--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="divXe2">
                        <div class="divHinh">
                            <div class="NoidonVeDLBan ">
                                <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                            </div>
                            <div class="divGheDaiLyBan ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A15" CssClass="LabelChuaBan "></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <asp:Label runat="server" ID="Label5" Text="01648006816" CssClass="Label"></asp:Label><br />
                                    <asp:Label runat="server" ID="Label6" Text="Phương - 2G" CssClass="Label"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="divDong">
                <div class="divXe1">
                    <div class="divHinh">
                        <div class="NoidonChuaBan ">
                            <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                        </div>
                        <div class="divGheChuaBan ">
                            <div class="divSoGhe">
                                <asp:Label runat="server" Text="A18" CssClass="LabelChuaBan"></asp:Label>
                            </div>
                            <div class="divThongTin">
                                <%--Nội Dung vé--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="divXe2">
                    <div class="divHinh">
                        <div class="NoidonChuaBan ">
                            <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                        </div>
                        <div class="divGheChuaBan ">
                            <div class="divSoGhe">
                                <asp:Label runat="server" Text="A19" CssClass="LabelChuaBan"></asp:Label>
                            </div>
                            <div class="divThongTin">
                                <%--Nội Dung vé--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="divDong">
                <div class="divXe1">
                    <div class="divHinh">
                        <div class="NoidonChuaBan ">
                            <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                        </div>
                        <div class="divGheChuaBan ">
                            <div class="divSoGhe">
                                <asp:Label runat="server" Text="A22" CssClass="LabelChuaBan"></asp:Label>
                            </div>
                            <div class="divThongTin">
                                <%--Nội Dung vé--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="divXe2">
                    <div class="divHinh">
                        <div class="NoidonChuaBan ">
                            <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                        </div>
                        <div class="divGheChuaBan ">
                            <div class="divSoGhe">
                                <asp:Label runat="server" Text="A23" CssClass="LabelChuaBan"></asp:Label>
                            </div>
                            <div class="divThongTin">
                                <%--Nội Dung vé--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="divDong">
                <div class="divXe1">
                    <div class="divHinh">
                        <div class="NoidonChuaBan ">
                            <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                        </div>
                        <div class="divGheChuaBan ">
                            <div class="divSoGhe">
                                <asp:Label runat="server" Text="A27" CssClass="LabelChuaBan"></asp:Label>
                            </div>
                            <div class="divThongTin">
                                <%--Nội Dung vé--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="divXe2">
                    <div class="divHinh">
                        <div class="NoidonChuaBan ">
                            <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                        </div>
                        <div class="divGheChuaBan ">
                            <div class="divSoGhe">
                                <asp:Label runat="server" Text="A28" CssClass="LabelChuaBan"></asp:Label>
                            </div>
                            <div class="divThongTin">
                                <%--Nội Dung vé--%>
                            </div>
                        </div>
                    </div>
                </div>
                   </div>
         <div class="divTrongGiua">
             <div class="divTrong"></div>
         </div>
            </div>

         




            <div class="divXeTrai">

                <div class="divDong">
                    <div class="divXe1">
                        <div class="divHinh">
                            <div class="NoidonDaBan ">
                                <asp:Label runat="server" Text="N5 C.Chó"></asp:Label>
                            </div>
                            <div class="divGheDaThu ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A4" CssClass="LableDaBan"></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <asp:Label runat="server" ID="lblSDT" Text="01648006816" CssClass="Label"></asp:Label><br />
                                    <asp:Label runat="server" ID="lblNhanVien" Text="Phương - 2G" CssClass="Label"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="divXe2">
                        <div class="divHinh">
                            <div class="NoidonChuaBan ">
                                <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                            </div>
                            <div class="divGheChuaBan ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A5" CssClass="LabelChuaBan "></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <%--Nội Dung vé--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         <%--   <div class="divTrongGiua">
                <div class="divTrong"></div>
            </div>--%>

            <div class="divXeTrai">
                <div class="divDong">
                    <div class="divXe1">
                        <div class="divHinh">
                            <div class="NoidonChuaBan ">
                                <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                            </div>
                            <div class="divGheChuaBan ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A6" CssClass="LabelChuaBan"></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <%--Nội Dung vé--%>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="divXe2">
                        <div class="divHinh">
                            <div class="NoidonChuaBan ">
                                <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                            </div>
                            <div class="divGheChuaBan ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A7" CssClass="LabelChuaBan "></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <%--Nội Dung vé--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
           <%-- <div class="divTrongGiua">
                <div class="divTrong"></div>
            </div>--%>
            <div class="divXeTrai">
                <div class="divDong">
                    <div class="divXe1">
                        <div class="divHinh">
                            <div class="NoidonChuaBan ">
                                <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                            </div>
                            <div class="divGheChuaBan ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A8" CssClass="LabelChuaBan"></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <%--Nội Dung vé--%>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="divXe2">
                        <div class="divHinh">
                            <div class="NoidonChuaBan ">
                                <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                            </div>
                            <div class="divGheChuaBan ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A9" CssClass="LabelChuaBan "></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <%--Nội Dung vé--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
           <%-- <div class="divTrongGiua">
                <div class="divTrong"></div>
            </div>--%>
            <div class="divXeTrai">
                <div class="divDong">
                    <div class="divXe1">
                        <div class="divHinh">
                            <div class="NoidonChuaBan ">
                                <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                            </div>
                            <div class="divGheChuaBan ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A12" CssClass="LabelChuaBan"></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <%--Nội Dung vé--%>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="divXe2">
                        <div class="divHinh">
                            <div class="NoidonVeDLBan ">
                                <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                            </div>
                            <div class="divGheDaiLyBan ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A13" CssClass="LabelChuaBan "></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <asp:Label runat="server" ID="Label3" Text="01648006816" CssClass="Label"></asp:Label><br />
                                    <asp:Label runat="server" ID="Label4" Text="Phương - 2G" CssClass="Label"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
           <%-- <div class="divTrongGiua">
                <div class="divTrong"></div>
            </div>--%>

            <div class="divXeTrai">
                <div class="divDong">
                    <div class="divXe1">
                        <div class="divHinh">
                            <div class="NoidonChuaBan ">
                                <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                            </div>
                            <div class="divGheChuaBan ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A16" CssClass="LabelChuaBan"></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <%--Nội Dung vé--%>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="divXe2">
                        <div class="divHinh">
                            <div class="NoidonChuaBan ">
                                <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                            </div>
                            <div class="divGheChuaBan ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A17" CssClass="LabelChuaBan "></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <%--Nội Dung vé--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
          <%--  <div class="divTrongGiua">
                <div class="divTrong"></div>
            </div>--%>
            <div class="divXeTrai">
                <div class="divDong">
                    <div class="divXe1">
                        <div class="divHinh">
                            <div class="NoidonChuaBan ">
                                <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                            </div>
                            <div class="divGheChuaBan ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A20" CssClass="LabelChuaBan"></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <%--Nội Dung vé--%>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="divXe2">
                        <div class="divHinh">
                            <div class="NoidonChuaBan ">
                                <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                            </div>
                            <div class="divGheChuaBan ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A21" CssClass="LabelChuaBan "></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <%--Nội Dung vé--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         <%--   <div class="divTrongGiua">
                <div class="divTrong"></div>
            </div>--%>
            <div class="divXeTrai">
                <div class="divDong">
                    <div class="divXe1">
                        <div class="divHinh">
                            <div class="NoidonChuaBan ">
                                <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                            </div>
                            <div class="divGheChuaBan ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A24" CssClass="LabelChuaBan"></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <%--Nội Dung vé--%>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="divXe2">
                        <div class="divHinh">
                            <div class="NoidonChuaBan ">
                                <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                            </div>
                            <div class="divGheChuaBan ">
                                <div class="divSoGhe">
                                    <asp:Label runat="server" Text="A25" CssClass="LabelChuaBan "></asp:Label>
                                </div>
                                <div class="divThongTin">
                                    <%--Nội Dung vé--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="divTrongGiua">
                <div class="divXe3">
                    <div class="divHinh">
                        <div class="NoidonVeBanChuaThu ">
                            <asp:Label runat="server" Text="Nơi đón khách"></asp:Label>
                        </div>
                        <div class="divGheBanChuaThu ">
                            <div class="divSoGhe">
                                <asp:Label runat="server" Text="A26" CssClass="LabelChuaBan"></asp:Label>
                            </div>
                            <div class="divThongTin">
                                <%--Nội Dung vé--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
