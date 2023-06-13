<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TaoPhieuChuyenHang.aspx.cs" Inherits="HangDi_ThongTinHangDi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../CSS/CheckBox.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, maximum-scale=1, minimum-scale=1" />
    <link href="../CSS/DropDownList.css" rel="stylesheet" />
    <link href="../CSS/GridView.css" rel="stylesheet" />
    <link href="../CSS/HangHoa.css" rel="stylesheet" />
    <link href="../CSS/RPS_HangDi.css" rel="stylesheet" />
    <link href="../CSS/Radio.css" rel="stylesheet" />
    <script src="../Js/TableSelected.js"></script>
    <script type="text/javascript">

        var allchk = new Array();
        function SubCheckBox(parent, listchild) {
            this.parent = parent;
            this.listchild = listchild;
            this.checkall = function () {
                for (var i = 0; i < listchild.length; i++) {
                    document.getElementById(listchild[i]).checked = true;
                }
            };
            this.uncheckall = function () {
                for (var i = 0; i < listchild.length; i++) {
                    document.getElementById(listchild[i]).checked = false;
                }
            };
            this.add = function () {
                for (var i = 0; i < listchild.length; i++) {
                    document.getElementById(listchild[i]).checked = false;
                }
            };
        }

        function check(obj) {
            for (var i = 0; i < allchk.length; i++) {
                if (allchk[i].parent == obj.id) {
                    if (obj.checked) {
                        allchk[i].checkall();
                    }
                    else
                        allchk[i].uncheckall();
                }
            }
        }
        function add(arr, obj) {
            arr[arr.length] = obj;
        }

        function checki(obj, ckall) {
            if (!obj.checked)
                document.getElementById(ckall).checked = '';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box divLon ">
            <table style="width: 100%">
                <tr>
                    <td class="title">THÔNG TIN PHIẾU CHUYỂN HÀNG</td>
                </tr>
            </table>
          
            <div class="divLon" style="text-align: center">
                <asp:TextBox CssClass="textbox" ID="TextBox1" runat="server" width="50%"  Style="text-align: center;padding: 4px; margin-right:20px"  placeholder="Tên người gửi  |  Tên người nhận  |   Số điện thoại người gửi  |  Số điện thoại người nhận "></asp:TextBox>
                <asp:Button CssClass="button blue" ID="Button1" Text="Tìm Kiếm " runat="server" />
            </div>
        <div class="divLon margin">
            <div class="divDong">
                <div class="divLabel">
                    <asp:Label runat="server" Text="Ngày-Giờ :" ID="lblNgayGio"></asp:Label>
                </div>
                <div class="divControl">
                    <asp:TextBox runat="server" ID="txtNgayGio" Width="100% " CssClass="textbox"></asp:TextBox>
                </div>
            </div>
            <div class="divDong">
                <div class="divLabel">Tuyến:</div>
                <div class="divControl">
                <asp:DropDownList runat="server" ID="drTuyen" CssClass="tddrop" Width="100%">
                    <asp:ListItem runat="server">TP.HCM - Kiên Giang </asp:ListItem>
                </asp:DropDownList>
                    </div>
            </div>
            <div class="divDong">
                <div class="divLabel">
                    <asp:Label runat="server" Text="Tên lái xe :" ID="lblTLaiXe"></asp:Label>
                </div>
                <div class="divControl">
                    <asp:TextBox runat="server" ID="txtTLaiXe" CssClass="textbox " Width="100%" ></asp:TextBox>
                </div>
            </div>
            <div class="divDong">
                <div class="divLabel">
                    <asp:Label runat="server" Text="Số xe :" ID="lblSoXe" ></asp:Label>
                </div>
                <div class="divControl">
                     <asp:TextBox runat="server" ID="txtSoXe" CssClass="textbox" Width="100% " ></asp:TextBox>
                </div>
            </div>
           </div>
            <div class="divLon" style="text-align: center">
                <asp:Button CssClass="button green tdbutton" ID="btnTaoPhieu" Text="Tạo phiếu chuyển hàng" runat="server" />
            </div>
              </div>
       <div class="box divLon ">
            <table style="width: 100%">
                <tr>
                    <td class="title">DANH SÁCH HÀNG CẦN CHUYỂN</td>
                </tr>
            </table>
       </div>
        <div class="divLon">
            <asp:Repeater runat="server" ID="rptPhieuNhan">
                    <HeaderTemplate>
                        <table id="tbl" style="width: 99%; margin-left: 0.5%" cellspacing="0" cellpadding="0">
                            <tr class="th">
                                <td class="brl brb brt" style="font-weight: bold;width:5%">Chọn</td>
                                <td class="brl brb brt" style="font-weight: bold;width:5%">STT</td>
                                <td class="brl brb brt" style="font-weight: bold;width:12%">Giờ nhận</td>
                                <td class="brl brb brt" style="font-weight: bold;width:7%">Mã hàng</td>
                                <td class="brl brb brt" style="font-weight: bold;width:13%">Người gửi</td>
                                <td class="brl brb brt" style="font-weight: bold;width:7%">Số ĐT</td>
                                <td class="brl brb brt" style="font-weight: bold;width:13%">Người nhận</td>
                                <td class="brl brb brt" style="font-weight: bold;width:10%">Số ĐT</td>
                                <td class="brl brb brt brr" style="font-weight: bold;width:7%">SL</td>
                                <td class="brl brb brt" style="font-weight: bold;width:21%">Hàng</td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="tdGroup">
                            <td class="brl brr" style="text-align: left;" colspan="10">
                                <asp:CheckBox runat="server" ID="Chk_All" onclick="check(this)" />
                                <script type="text/javascript">
                                    var ar = new Array();
                                    var chk = new SubCheckBox('<%# ((Control)Container).FindControl("Chk_All").ClientID %>', ar);
                                </script>
                                <b><%#Eval("TramGui")+ " - "+ Eval("TramNhan")%></b>
                            </td>
                        </tr>
                        <tr>
                            
                            <asp:Repeater runat="server" ID="rptCt" DataSource='<%#Eval("TblChiTiet") %>'>
                                <ItemTemplate>
                                    <tr <%#Eval("Tien").ToString() == "True" ? "style='background:#ffff00'" : (Container.ItemIndex%2==0?"":"class='td'")%>>
                                        <td class="brl brb">
                                            <asp:CheckBox ID="Chk_Chon" class="filled-in" runat="server" onclick="checki(this, 'ckall1')" />
                                            <script type="text/javascript">
                                                add(ar, '<%# ((Control)Container).FindControl("Chk_Chon").ClientID %>');
                                            </script>
                                            <asp:Label ID="Lb_Id" Visible="false" runat="server" Text='<%# Eval("Id_Hang") %>'></asp:Label>
                                            <asp:Label ID="Lb_IdLsHang" Visible="false" runat="server" Text='<%# Eval("Id_LsHang") %>'></asp:Label>
                                            <asp:Label ID="Lb_NoiDen" Visible="false" runat="server" Text='<%# (Eval("NoiNhan").ToString().Equals("10062"))?Eval("NN_DiaChi"): Eval("TramNhan") %>'></asp:Label>
                                        </td>
                                        <td class="brl brb"><%#Container.ItemIndex+1 %></td>
                                        <td class="brl brb">
                                            <asp:Label ID="Lb_GioNhan" runat="server" Text='<%# Eval("NgayNhan","{0:dd/MM/yyyy HH:mm}") %>'></asp:Label></td>
                                        <td class="brl brb">
                                            <asp:Label ID="Lb_MaSo" runat="server" Text='<%# Eval("SoBienLai") %>'></asp:Label></td>
                                        <td class="brl brb">
                                            <asp:Label ID="Lb_NguoiGui" runat="server" Text='<%# Eval("TenNguoiGui") %>'></asp:Label></td>
                                        <td class="brl brb">
                                            <asp:Label ID="Lb_SoDT" runat="server" Text='<%# Eval("NG_SoDT") %>'></asp:Label></td>
                                         <td class="brl brb">
                                            <asp:Label ID="Lb_NguoiNhan" runat="server" Text='<%#Eval("TenNguoiNhan") %>'></asp:Label></td>
                                        <td class="brl brb">
                                            <asp:Label ID="Lb_SoDTNhan" runat="server" Text='<%#Eval("NN_SoDT") %>'></asp:Label></td>
                                        <td class="brl brb">
                                            <asp:TextBox ID="Txt_SL" Width="40px" style="text-indent:0px;text-align:center;font-weight:bold" runat="server" Text='<%# Eval("SoLuong") %>'></asp:TextBox>
                                            <asp:Label ID="Lb_SL" runat="server" Text='<%# Eval("SoLuong") %>' Visible="false"></asp:Label></td>
                                        <td class="brl brb brr">
                                            <asp:Label ID="Lb_LoaiHang" runat="server" Text='<%# Eval("LoaiHang") %>'></asp:Label></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <script type="text/javascript">
                                add(allchk, chk);
                            </script>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
        </div>
    </form>
</body>
</html>
