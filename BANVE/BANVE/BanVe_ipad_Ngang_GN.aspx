<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BanVe_ipad_Ngang_GN.aspx.cs" Inherits="BANVE_BanVe_ipad_Ngang_GN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/BanVe.css" rel="stylesheet" />
    <link href="../CSS/HideMenu.css" rel="stylesheet" />
    <link href="../CSS/BanVe_ipad_Ngang_GN.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, maximum-scale=1, minimum-scale=1" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="divLon box">
            <table style="width: 100%">
                <tr>
                    <td class="title">Sơ đồ ghế ngồi </td>
                </tr>
            </table>
            <div class="divDong" style="text-align: center">
                <asp:Label runat="server" CssClass="LabelSoXe" ID="lblSoXe" Text="51A 000.01"></asp:Label>
            </div>
            <div class="divDong" style="text-align: center">
                <div class="divDongGhe">
                    <div class="divLabelSoGhe">
                        <asp:Label runat="server" Text="Ghế Sub:" ID="lblGheSub"></asp:Label>
                    </div>
                    <div class="divLabelGhe">
                        <asp:Label runat="server" ID="lblSoGheSub" CssClass="SoGhe" Text="10"></asp:Label>
                    </div>
                    <div class="divLabelGhe">
                        <asp:Label runat="server" Text="ghế" ID="lblGhe"></asp:Label>
                    </div>
                </div>
            </div>

            <div class="divTangDuoi" style="text-align: center">
                <div class="divDong">
                    <asp:Label runat="server" ID="lblTangDuoi" Text="Tầng dưới" CssClass="LabelTang label"></asp:Label>
                </div>
                <div class="divDong">
                    <div class=" divtitle1">
                    <asp:Label runat="server" Text="Tài xế"  ID="lblTaiXe" CssClass="label"></asp:Label>
                        </div>
                      <div class=" divtitle2">
                    <asp:Label runat="server" Text="Cửa trước" ID="lblCuaTruoc" CssClass="label"></asp:Label>
                    </div>
                </div>
         
                   <div class="divDong">
                    <div class="divHinh VeDaThuTien DonKhachDocDuong">
                        <asp:Label runat="server" Text="A1" ID="lblA1" CssClass="label"></asp:Label><br />
                        <asp:Label runat="server" Text="696" ID="Label2"></asp:Label><br />
                        <asp:Label runat="server" Text="Phương" ID="Label3" ></asp:Label>
                    </div>
                    <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                        <asp:Label runat="server" Text="B1" ID="lblB1" CssClass="label" ></asp:Label>
                    </div>
                        <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                        <asp:Label runat="server" Text="C1" ID="lblC1" CssClass="label" ></asp:Label>
                    </div>
                </div>

                 <div class="divDong">
                    <div class="divHinh VeChuaDat ">
                        <asp:Label runat="server" Text="A3" ID="lblA3" CssClass="label"></asp:Label><br />
                    </div>
                    <div class="divTrong"></div>
                    <div class="divHinh VeDaiLyBan DonKhachTanNha">
                        <asp:Label runat="server" Text="B3" ID="lblB3" CssClass="label" ></asp:Label>
                    </div>
                         <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                        <asp:Label runat="server" Text="C3" ID="lblC3" CssClass="label" ></asp:Label>
                    </div>
                </div>

                   <div class="divDong">
                    <div class="divHinh VeChuaDat ">
                     
                        <asp:Label runat="server" Text="A5" CssClass="label" ID="lblA5"></asp:Label>
                    </div>
                    <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                             <asp:Label runat="server" Text="B5" ID="lblB5" CssClass="label" ></asp:Label>
                    </div>
                          <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                        <asp:Label runat="server" Text="C5" ID="lblC5" CssClass="label" ></asp:Label>
                    </div>
                </div>
                   <div class="divDong">
                    <div class="divHinh VeChuaDat ">
                     
                        <asp:Label runat="server" Text="A7" CssClass="label" ID="lblA7"></asp:Label>
                    </div>
                    <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                             <asp:Label runat="server" Text="B7" ID="lblB7" CssClass="label" ></asp:Label>
                    </div>
                          <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                        <asp:Label runat="server" Text="C7" ID="lblC7" CssClass="label" ></asp:Label>
                    </div>
                </div>
                   <div class="divDong">
                    <div class="divHinh VeChuaDat ">
                     
                        <asp:Label runat="server" Text="A9" CssClass="label" ID="lblA9"></asp:Label>
                    </div>
                    <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                             <asp:Label runat="server" Text="B9" ID="lblB9" CssClass="label" ></asp:Label>
                    </div>
                          <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                        <asp:Label runat="server" Text="C9" ID="lblC9" CssClass="label" ></asp:Label>
                    </div>
                </div>

                <div class="divDong">
                    <div class="divHinh VeChuaDat ">
                     
                        <asp:Label runat="server" Text="D1" CssClass="label" ID="lblD1"></asp:Label>
                    </div>
                    <div class="divHinh VeChuaDat">
                        <asp:Label runat="server" Text="D3" CssClass="label" ID="lblD3"></asp:Label>
                    </div>
                    <div class="divHinh VeChuaThuTien">
                             <asp:Label runat="server" Text="D5" ID="lblD5" CssClass="label" ></asp:Label>
                    </div>
                          <div class="divHinh VeChuaDat">
                             <asp:Label runat="server" Text="D7" ID="lblD7" CssClass="label" ></asp:Label>
                    </div>
                    <div class="divHinh VeChuaDat">
                        <asp:Label runat="server" Text="D9" ID="lblD9" CssClass="label" ></asp:Label>
                    </div>
                </div>
                       </div>

       
                <div class="divTangTren" style="text-align: center">
                <div class="divDong">
                    <asp:Label runat="server" ID="lblTangTren" Text="Tầng trên" CssClass="LabelTang label"></asp:Label>
                </div>
                    <div class="divDongTrong"></div>
                      <div class="divDong">
                    <div class="divHinh VeChuaDat ">
                     
                        <asp:Label runat="server" Text="A2" CssClass="label" ID="lblA2"></asp:Label>
                    </div>
                    <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                             <asp:Label runat="server" Text="B2" ID="lblB2" CssClass="label" ></asp:Label>
                    </div>
                              <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                        <asp:Label runat="server" Text="C2" ID="lblC2" CssClass="label" ></asp:Label>
                    </div>
                </div>
                    <div class="divDong">
                    <div class="divHinh VeChuaDat ">
                        <asp:Label runat="server" Text="A4" ID="lblA4" CssClass="label"></asp:Label><br />
                    </div>
                    <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                        <asp:Label runat="server" Text="B4" ID="lblB4" CssClass="label" ></asp:Label>
                    </div>
                         <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                        <asp:Label runat="server" Text="C4" ID="lblC4" CssClass="label" ></asp:Label>
                    </div>
                </div>

                   <div class="divDong">
                    <div class="divHinh VeChuaDat ">
                     
                        <asp:Label runat="server" Text="A6" CssClass="label" ID="lblA6"></asp:Label>
                    </div>
                    <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                             <asp:Label runat="server" Text="B6" ID="lblB6" CssClass="label" ></asp:Label>
                    </div>
                          <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                        <asp:Label runat="server" Text="C6" ID="lblC6" CssClass="label" ></asp:Label>
                    </div>
                </div>
                   <div class="divDong">
                    <div class="divHinh VeChuaDat ">
                     
                        <asp:Label runat="server" Text="A8" CssClass="label" ID="lblA8"></asp:Label>
                    </div>
                    <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                             <asp:Label runat="server" Text="B8" ID="lblB8" CssClass="label" ></asp:Label>
                    </div>
                          <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                        <asp:Label runat="server" Text="C8" ID="lblC8" CssClass="label" ></asp:Label>
                    </div>
                </div>
                   <div class="divDong">
                    <div class="divHinh VeChuaDat ">
                     
                        <asp:Label runat="server" Text="A10" CssClass="label" ID="lblA10"></asp:Label>
                    </div>
                    <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                             <asp:Label runat="server" Text="B10" ID="lblB10" CssClass="label" ></asp:Label>
                    </div>
                          <div class="divTrong"></div>
                    <div class="divHinh VeChuaDat">
                        <asp:Label runat="server" Text="C10" ID="lblC10" CssClass="label" ></asp:Label>
                    </div>
                </div>

                <div class="divDong">
                    <div class="divHinh VeChuaDat ">
                     
                        <asp:Label runat="server" Text="D2" CssClass="label" ID="lblD2"></asp:Label>
                    </div>
                    <div class="divHinh VeChuaDat">
                        <asp:Label runat="server" Text="D4" CssClass="label" ID="lblD4"></asp:Label>
                    </div>
                    <div class="divHinh VeChuaDat">
                             <asp:Label runat="server" Text="D6" ID="lblD6" CssClass="label" ></asp:Label>
                    </div>
                          <div class="divHinh VeChuaDat">
                             <asp:Label runat="server" Text="D8" ID="lblD8" CssClass="label" ></asp:Label>
                    </div>
                    <div class="divHinh VeChuaDat">
                        <asp:Label runat="server" Text="D10" ID="lblD10" CssClass="label" ></asp:Label>
                    </div>
                </div>
                </div>

            <div class="divDong">
                <div class="divTangDuoi" style="text-align:center">
                    <asp:Button runat="server" CssClass="button maubtIn btn " Text="In sơ đồ xe" />
                </div>
                 <div class="divTangTren" style="text-align:center">
                    <asp:Button runat="server" CssClass="button maubtInDS btn" Text="In danh sách" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
