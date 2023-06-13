<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhieuNhanCaNhan.aspx.cs" Inherits="NhanHang_PhieuNhanHangHoa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, maximum-scale=1, minimum-scale=1" />
    <link href="../CSS/CheckBox.css" rel="stylesheet" />
    <link href="../CSS/DropDownList.css" rel="stylesheet" />
    <link href="../CSS/HangHoa.css" rel="stylesheet" />
    <link href="../CSS/GridView.css" rel="stylesheet" />
    <link href="../CSS/RPS_PNhanhang.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div  class="box divLon" style="height:auto ">
            <table style="width: 100%">
                <tr>
                    <td class="title">TÌM PHIẾU NHẬN CÁ NHÂN</td>
                </tr>
            </table>
         <div class="divDong">
             <div class="divLabel">
                   <asp:Label runat="server" Text="Từ ngày:" ID="lblNgayNhan"></asp:Label>
             </div>
             <div class="divControl">
                 <asp:TextBox runat="server" Width="100%" ID="txtNgayNhan" CssClass="textbox"></asp:TextBox>
             </div>
        </div>
            <div class="divDong">
             <div class="divLabel"> 
                  <asp:Label runat="server" Text="Đến ngày:" ID="lblDen"></asp:Label>
             </div>
             <div class="divControl">
              <asp:TextBox runat="server" ID="txtDenNgay" Width="100%"  CssClass="textbox"></asp:TextBox>
             </div>
                </div>
            <div class="divDong">
             <div class="divLabel">
                 <asp:Label runat="server" Text="Người gửi:" ID="lblNguoiGui"></asp:Label>
            </div>
              <div class="divControl">
                   <asp:TextBox runat="server" ID="txtNguoiGui" Width="100%"  CssClass="textbox"></asp:TextBox>
                  </div>
                </div>
            <div class="divDong">
              <div class="divLabel">
                   <asp:Label runat="server" Text="Số ĐT:"  ID="lblSDTGui"></asp:Label>
                  </div>
             <div class="divControl">
                 <asp:TextBox runat="server" ID="txtSDTGui" Width="100%"  CssClass="textbox"></asp:TextBox>
                 </div>
                </div>
         <div class="divDong">
              <div class="divLabel">
              <asp:Label runat="server" ID="lblNoiNhan" Text="Nơi nhận:"></asp:Label>
                  </div>
              <div class="divControl">
                   <asp:DropDownList runat="server" Width="100%" ID="ddrNoiNhan" CssClass="tddrop">
                        <asp:ListItem>-- Tất cả -- </asp:ListItem>
                    </asp:DropDownList>
                  </div>
             </div>
          <div class="divLon" style="text-align:center" >
               <asp:Button  runat="server" Text="Tìm kiếm" CssClass="button blue tdbutton" />
          </div>
    </div>
       <div  class="box divLon" style="height:auto ">
            <table style="width: 100%">
                <tr>
                    <td class="title">DANH SÁCH PHIẾU NHẬN HÀNG CÁ NHÂN</td>
                </tr>
            </table>
           <div class="divDong">
               <asp:GridView runat="server" CssClass="tbl"></asp:GridView>
           </div>
        </div>
    </div>
    </form>
</body>
</html>
