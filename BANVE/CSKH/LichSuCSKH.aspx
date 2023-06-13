<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LichSuCSKH.aspx.cs" Inherits="LichSuCSKH" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/BanVe.css" rel="stylesheet" />
    <link href="../CSS/CSKH.css" rel="stylesheet" />
    <link href="../CSS/Gridview.css" rel="stylesheet" />

    <meta name="viewport" content="width=device-width, maximum-scale=1, minimum-scale=1" />
</head>
<body>
    <form id="form1" runat="server">
          <div class="divLon box">
              <table style="width:100%">
                  <tr>
                      <td class="title"> LỊCH SỬ PHỤC VỤ </td>
                  </tr>
              </table>

                  <div class="divLon" style="text-align:center; margin-top:20px">
                      <asp:Label runat="server" Text="Công ty TNHH dịch vụ vận tải ABC" CssClass="font" ></asp:Label>
                  </div>
                  <div class="divLon" style="text-align:center; margin-top:20px">
                      <asp:TextBox runat="server" Width="40%" Style="padding:5px;" ID="txtTimKiem"  placeholder="Mã hàng  |  Số điện thoại " CssClass="textboxtimkiem"></asp:TextBox>
                  </div>
           
              <div class="divDongtennhom">
                  <div class="divLabeltennhom"> <asp:Label Text="Tên/Nhóm:" ID="lblTenNhom" runat="server"></asp:Label></div>
                  <div class="divControltennhom"> <asp:TextBox runat="server" ID="txtTenNhom" Width="90%" CssClass="txt txtTenRieng tdtxt" Text="Nguyễn Văn phú minh"></asp:TextBox></div>
              </div>

               <div class="divDongdienthoai" >
                  <div class="divLabeldienthoai"> <asp:Label Text="Điện thoại:" ID="lblDienThoai" runat="server"></asp:Label></div>
                  <div class="divControldienthoai"> <asp:TextBox runat="server" ID="txtDienThoai" Width="90%" CssClass="txt tdtxt" Text="01648006816"></asp:TextBox></div>
              </div>

               <div class="divDongdiachi">
                  <div class="divLabeldiachi"> <asp:Label Text="Địa chỉ:" ID="lblDiaChi" runat="server"></asp:Label></div>
                  <div class="divControldiachi"> <asp:TextBox runat="server" ID="txtDiaChi" Width="90%" CssClass="txt tdtxt" Text="Kinh Dương Vương, Bình Tân, TP.HCM"></asp:TextBox></div>
              </div>

               <div class="divDongkhachhang">
                  <div class="divLabelkhachhang"> <asp:Label Text="Khách hàng:" ID="lblKhachHang" runat="server"></asp:Label></div>
                  <div class="divControlkhachhang" > <asp:TextBox runat="server" ID="txtKhachHang" Width="90%" CssClass="txt tdtxt" Text="Thân thiết/Vip"></asp:TextBox></div>
              </div>

               <div class="divDongdiemthuong" >
                  <div class="divLabeldiemthuong"> <asp:Label Text="Điểm thưởng:" ID="lblDiemThuong" runat="server"></asp:Label></div>
                  <div class="divControldiemthuong"> <asp:TextBox runat="server" ID="txtDiemThuong" Width="90%" CssClass="txt tdtxt" Text="26"></asp:TextBox></div>
              </div>

              <div class="divLon" style="text-align:center">
                  <asp:Button runat="server" Text="Đổi thưởng" ID="btnDoiThuong" class="button maubt" />
              </div>


            <div class="divLon"  style="margin-top:1%" >
                <span class="font"> LỊCH SỬ GIAO DỊCH </span>
            </div>
              <div class="divLon" style="margin-top:1%">
           <asp:Repeater runat="server" ID="rptCSKH">
                    <HeaderTemplate>
                        <table id="tbl" style="width: 99%; margin-left: 0.5%" cellspacing="0" cellpadding="0">
                            <tr class="th">
                                <td class="brl brb brt" style="font-weight: bold;width:10%">Ngày</td>
                                <td class="brl brb brt" style="font-weight: bold;width:7%">Giờ</td>
                                <td class="brl brb brt" style="font-weight: bold;width:15%">Hàng hóa</td>
                                <td class="brl brb brt" style="font-weight: bold;width:10%">Vé</td>
                                <td class="brl brb brt" style="font-weight: bold;width:30%">Tuyến</td>
                                <td class="brl brb brt" style="font-weight: bold;width:12%">Chi tiết</td>
                                <td class="brl brb brt brr" style="font-weight: bold;width:15%">Điểm thường</td>

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
