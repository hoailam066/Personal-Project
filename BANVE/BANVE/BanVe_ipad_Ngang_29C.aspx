<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BanVe_ipad_Ngang_29C.aspx.cs" Inherits="BANVE_BanVe_ipad_Ngang_29C" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/BanVe.css" rel="stylesheet" />
    <link href="../CSS/BanVe_ipad_Ngang_29C.css" rel="stylesheet" />
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
         <div class="divLon">
             <div class="divPhai">
                   <div class="divDong">
                     <div class="divHinh VeChuaDat margin">
                         <asp:Label runat="server" ID="Label1" Text="A13" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                        <div class="divHinh VeChuaDat">
                         <asp:Label runat="server" ID="Label5" Text="A11" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                        <div class="divHinh VeChuaDat">
                         <asp:Label runat="server" ID="Label6" Text="A9" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                      <div class="divHinhTrong">
                         <asp:Label runat="server" ID="Label14" Text="Tài xế" CssClass="lblTaiXe"></asp:Label>
                     </div>
                 </div>
                 <div class="divDong">
                     <div class="divHinh VeChuaDat margin" >
                         <asp:Label runat="server" ID="Label11" Text="A14" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                        <div class="divHinh VeChuaDat">
                         <asp:Label runat="server" ID="Label12" Text="A12" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                        <div class="divHinh VeChuaDat">
                         <asp:Label runat="server" ID="Label13" Text="A10" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                      <div class="divHinhTrong">
                          
                     </div>
                 </div>
                 </div>
                
             <div class="divTrai">
                 <div class="divDong">
                     <div class="divHinhTrai VeDaThuTien DonKhachDocDuong">
                         <asp:Label runat="server" ID="lblA9" Text="A21" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                      <div class="divHinhTrai VeChuaDat">
                         <asp:Label runat="server" ID="Label2" Text="A19" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                      <div class="divHinhTrai VeChuaDat">
                         <asp:Label runat="server" ID="Label3" Text="A17" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                      <div class="divHinhTrai VeChuaDat">
                         <asp:Label runat="server" ID="Label4" Text="A15" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                 </div>
                  <div class="divDong">
                     <div class="divHinhTrai VeChuaDat">
                         <asp:Label runat="server" ID="Label7" Text="A22" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                      <div class="divHinhTrai VeChuaDat">
                         <asp:Label runat="server" ID="Label8" Text="A20" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                      <div class="divHinhTrai VeDaiLyBan DonKhachTanNha">
                         <asp:Label runat="server" ID="Label9" Text="A18" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                      <div class="divHinhTrai VeChuaDat">
                         <asp:Label runat="server" ID="Label10" Text="A16" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                 </div></div>
              <div class="divTrai">
                        <div class="divDong">
                     <div class="divHinhTrai VeChuaDat">
                         <asp:Label runat="server" Text="A23" ID="lblA23" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                     <div class="divHinhTrong"></div>
                 </div>
             </div>
             <div class="divPhai">
                 <div class="divDong">
                     <div class="divHinhTrong">
                     </div>
                     
                 </div>
             </div>
             <div class="divPhai">
                 
                  <div class="divDong">
                     <div class="divHinh VeChuaDat margin" >
                         <asp:Label runat="server" ID="Label15" Text="B13" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                        <div class="divHinhTrong">
                      
                     </div>
                        <div class="divTrong"></div>
                        
                      <div class="divHinh VeChuaDat">
                          <asp:Label runat="server" ID="Label18" Text="B5" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                 </div>
                  <div class="divDong">
                     <div class="divHinh VeChuaDat margin">
                         <asp:Label runat="server" ID="Label19" Text="B14" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                        <div class="divHinhTrong" >
                         <asp:Label runat="server" ID="Label20" Text="Cửa trước" CssClass="lblTaiXe"></asp:Label>
                     </div>
                       
                      <div class="divHinh VeChuaDat">
                          <asp:Label runat="server" ID="Label22" Text="B8" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                        
                      <div class="divHinh VeChuaDat">
                          <asp:Label runat="server" ID="Label17" Text="B6" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                 </div>

             </div>
         
             <div class="divTrai">
          
                 <div class="divDong">
                     <div class="divHinhTrai VeChuaDat">
                         <asp:Label runat="server" ID="Label23" Text="B21" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                      <div class="divHinhTrai VeChuaDat">
                         <asp:Label runat="server" ID="Label24" Text="B19" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                      <div class="divHinhTrai VeChuaDat">
                         <asp:Label runat="server" ID="Label25" Text="B17" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                      <div class="divHinhTrai VeChuaThuTien">
                         <asp:Label runat="server" ID="Label26" Text="B15" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                 </div>
                 <div class="divDong">
                     <div class="divHinhTrai VeChuaDat">
                         <asp:Label runat="server" ID="Label27" Text="B22" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                      <div class="divHinhTrai VeChuaDat">
                         <asp:Label runat="server" ID="Label28" Text="B20" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                      <div class="divHinhTrai VeChuaDat">
                         <asp:Label runat="server" ID="Label29" Text="B18" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                      <div class="divHinhTrai VeChuaDat">
                         <asp:Label runat="server" ID="Label30" Text="B16" CssClass="LabelSoGhe"></asp:Label>
                     </div>
                 </div>
             </div>

         </div>
         <div class="divDong">
             <div class="divCon" style="text-align:center">
                 <asp:Button runat="server" CssClass="button maubtIn" Text="In sơ đồ xe" ID="btnInSoDoXe" />

             </div>
              <div class="divCon" style="text-align:center">
                 <asp:Button runat="server" CssClass="button maubtInDS" Text="In danh sách" ID="btnInDS" />

             </div>
         </div>


         </div>
    </form>
</body>
</html>
