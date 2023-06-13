<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TaoPhieuNhanHang.aspx.cs" Inherits="NhanHang_TaoPhieuNhanHang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:Tạo phiếu nhận hàng:.</title>
     <meta name="viewport" content="width=device-width, maximum-scale=1, minimum-scale=1" />
    <link href="../CSS/NhanHang.css" rel="stylesheet" />
    <link href="../CSS/DropDownList.css" rel="stylesheet" />
    <link href="../CSS/Radio.css" rel="stylesheet" />
    <link href="../CSS/HangHoa.css" rel="stylesheet" />
    <link href="../CSS/CheckBox.css" rel="stylesheet" />
    <script src="../Js/jquery-3.1.1.js"></script>
    <script src="../Js/Common.js"></script>
    <script src="../Js/TableSelected.js"></script>
    <script type="text/javascript">
        function KichHoatPhieu(sophieu)
        {
            document.getElementById('<%=hidPhieuKichHoat.ClientID%>').value = sophieu.toString();
            var hide = document.getElementById("divKichHoat");
            var hide2 = document.getElementById("divKichHoat2");
            if(sophieu == 2)
            {
                hide.style.display = "block"; 
                hide2.style.display = "none";
                document.getElementById('<%=txtTenNguoiGui2.ClientID%>').focus();
            }
            else
            {
                hide2.style.display = "block";
                hide.style.display = "none";
                document.getElementById('<%=txtTenNguoiGui.ClientID%>').focus();
            }
        }
        var secs;
        var timerID = null;
        var timerRunning = false;
        var delay = 1000;

        function InitializeTimer() {
            secs = 1;
            StopTheClock();
            timerID = setTimeout("StartTheTimer()", delay);
        }

        function StopTheClock() {
            if (timerRunning)
                clearTimeout(timerID)
            timerRunning = false
        }

        function StartTheTimer() {
            StopTheClock();
            var date = new Date();
            var d = (date.getDate() < 10 ? "0" : "") + date.getDate().toString();
            var m = (date.getMonth() + 1 < 10 ? "0" : "") + (date.getMonth() + 1).toString();
            var y = (date.getFullYear() < 10 ? "0" : "") + date.getFullYear().toString();
            var h = (date.getHours() < 10 ? "0" : "") + date.getHours().toString();
            var mn = (date.getMinutes() < 10 ? "0" : "") + date.getMinutes().toString();
            document.getElementById('lblTime').innerHTML = d + "/" + m + "/" + y+" - " + h + ":" + mn;
            document.getElementById('lblTime2').innerHTML = d + "/" + m + "/" + y + " - " + h + ":" + mn;
            InitializeTimer();
        }
    </script>
</head>
<body onload="InitializeTimer()" >
    <form id="form1" runat="server">
    <div class="divMain">
        <%--Phiếu nhận số 1--%>
        <div id="divPhieuNhan1" class="divPhieuNhan1 box">
            <div class="divRow">
                <div class="h2">Thông tin phiếu nhận</div>
            </div>
            <div class="divRowTime">
                <div class="divTime"><asp:Label ID="lblTime" runat="server" Text="21/08/2017 - 12:00"></asp:Label></div>
            </div>
            <div class="divRow">
                <div class="divTenCongTy"><asp:Label ID="lblTenCongTy" runat="server" Text="công ty vận tải sài gòn" CssClass="h1"></asp:Label></div>
            </div>
            <div class="divRow">
                <div class="div30p">Mã hàng: <asp:Label ID="lblMaHang" runat="server" Text="4" Font-Bold="true"></asp:Label></div>
                <div class="div70p" style="text-align:right">Điện thoại: <asp:Label ID="lblSoDTTram" runat="server" Text="0966.170.493" Font-Bold="true"></asp:Label></div>
            </div>
            <div class="divRow h3">
                <div class="divThongTinHang">Thông tin chuyển</div>
            </div>
            <div class="divRow">
                <div class="div50p textsize" style="text-align:center"><asp:RadioButton ID="rdGuiHang" runat="server" Checked="true" GroupName="loaigui" Text="Gửi hàng" Font-Bold="true" /></div>
                <div class="div50p textsize" style="text-align:center"><asp:RadioButton ID="rdGuiTien" runat="server" GroupName="loaigui" Text="Gửi tiền" Font-Bold="true"/></div>
            </div>
            <div class="divRowCT">
                <div class="divNoiNhan divLabel textsize">Nơi nhận:</div>
                <div class="divControl divdrNoiNhan">
                    <asp:DropDownList ID="drNoiNhan" runat="server" Width="100%">
                        <asp:ListItem>Hàng dọc đường</asp:ListItem>
                    </asp:DropDownList></div>
            </div>
            <div class="divRowCT">
                <div class="divNguoiGui divLabel textsize">Người gửi<sup style="color:red">(*)</sup>:</div>
                <div class="divControl divtxtNguoiGui">
                    <asp:TextBox ID="txtTenNguoiGui" runat="server" Width="100%"></asp:TextBox></div>
            </div>
            <div class="divRowCT">
                <div class="divSDT divLabel textsize">Số ĐT:</div>
                <div class="divControl divtxtSDT">
                    <asp:TextBox ID="txtSDTNguoiGui" runat="server" Width="100%" onkeyup="splitphone(this.value, this);"></asp:TextBox></div>
            </div>
            <div class="divRowCT">
                <div class="divNguoiNhan divLabel textsize">Người nhận<sup style="color:red">(*)</sup>:</div>
                <div class="divControl divtxtNguoiNhan">
                    <asp:TextBox ID="txtTenNguoiNhan" runat="server" Width="100%"></asp:TextBox></div>
            </div>
            <div class="divRowCT">
                <div class="divSDT divLabel textsize">Số ĐT<sup style="color:red">(*)</sup>:</div>
                <div class="divControl divtxtSDT">
                    <asp:TextBox ID="txtSDTNguoiNhan" runat="server" Width="100%" onkeyup="splitphone(this.value, this);"></asp:TextBox></div>
            </div>
            <div class="divRowCT">
                <div class="divDiaChi divLabel textsize">Địa chỉ:</div>
                <div class="divControl divtxtDiaChi">
                    <asp:TextBox ID="txtDiaChiNhan" runat="server" Width="100%"></asp:TextBox></div>
            </div>
            <div class="divRowCT">
                <div class="divLuuY divLabel textsize">Lưu ý:</div>
                <div class="divControl divtxtLuuY">
                    <asp:TextBox ID="txtLuuY" runat="server" Width="100%"></asp:TextBox></div>
            </div>
            <div class="divRow h3">
                <div class="divThongTinHang">Thông tin hàng</div>
            </div>
            <div class="divRowCT">
                <div class="divHang divLabel textsize">Hàng<sup style="color:red">(*)</sup>:</div>
                <div class="divControl divtxtHang">
                    <asp:TextBox ID="txtHang" runat="server" Width="100%"></asp:TextBox></div>
            </div>
            <div class="divRow">
                <div class="div50p">
                    <div class="divSoLuong divLabel textsize">Số lượng<sup style="color:red">(*)</sup>:</div>
                    <div class="divtxtSoLuong"><asp:TextBox ID="txtSoLuong" Style="text-align:center" runat="server" Width="95%" Text="1"></asp:TextBox></div>
                </div>
                <div class="div50p">
                    <div class="divSoLuong divLabel textsize">Ước giá<sup style="color:red">(*)</sup>:</div>
                    <div class="divtxtSoLuong"><asp:TextBox ID="txtUocGia" Style="text-align:center" runat="server" Width="100%" Text="0"></asp:TextBox></div>
                </div>
            </div>
            <div class="divRow">
                <div class="div50p textsize" style="text-align:center"><asp:RadioButton ID="rdCuocRoi" runat="server" Checked="true" GroupName="cuoc" Text="Cước rồi (CR)" Font-Bold="true"/></div>
                <div class="div50p textsize" style="text-align:center"><asp:RadioButton ID="rdChuaCuoc" runat="server" GroupName="cuoc" Text="Chưa cước (CC)" Font-Bold="true"/></div>
            </div>
            <%--Check Nợ, Kiểm duyệt --%>
            <div class="divRow"  style="display:none">
                <asp:CheckBox ID="chkNo" runat="server" Text="Nợ" CssClass="textsize"/>
                <asp:CheckBox ID="chkKiemDuyet" runat="server" Text="Kiểm duyệt" CssClass="textsize"/>
            </div>
            <div class="divRowCuocPhi" style="background-color:#ffcc00">
                <div class="divCuocPhi divLabel textsize" style="text-align:center">Cước phí<sup style="color:red">(*)</sup>:</div>
                <div class="divtxtCuocPhi"><asp:TextBox ID="txtCuocPhi" runat="server" Width="100%" Text="0" ></asp:TextBox></div>
            </div>
            <div class="divRowButton">
                    <asp:Button ID="btnHuy" runat="server" Text="Hủy"  CssClass="button red divButton textsize"/>
                    <asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="button green divButton textsize" />
                    <asp:Button ID="btnLuuIn" runat="server" Text="Lưu và in" CssClass="button blue divButton textsize"/>
            </div>
        </div>



        <%--Phiếu nhận số 2--%>
        <div id="divPhieuNhan2" class="divPhieuNhan2 box">
            <div class="divRow">
                <div class="h2">Thông tin phiếu nhận</div>
            </div>
            <div class="divRowTime">
                <div class="divTime"><asp:Label ID="lblTime2" runat="server" Text="21/08/2017 - 12:00"></asp:Label></div>
            </div>
            <div class="divRow">
                <div class="divTenCongTy"><asp:Label ID="lblTenCongTy2" runat="server" Text="công ty vận tải sài gòn" CssClass="h1"></asp:Label></div>
            </div>
            <div class="divRow">
                <div class="div30p">Mã hàng: <asp:Label ID="lblMaHang2" runat="server" Text="4" Font-Bold="true"></asp:Label></div>
                <div class="div70p" style="text-align:right">Điện thoại: <asp:Label ID="lblSoDTTram2" runat="server" Text="0966.170.493" Font-Bold="true"></asp:Label></div>
            </div>
            <div class="divRow h3">
                <div class="divThongTinHang">Thông tin chuyển</div>
            </div>
            <div class="divRow">
                <div class="div50p textsize" style="text-align:center"><asp:RadioButton ID="rdGuiHang2" runat="server" Checked="true" GroupName="loaigui2" Text="Gửi hàng" Font-Bold="true" /></div>
                <div class="div50p textsize" style="text-align:center"><asp:RadioButton ID="rdGuiTien2" runat="server" GroupName="loaigui2" Text="Gửi tiền" Font-Bold="true"/></div>
            </div>
            <div class="divRowCT">
                <div class="divNoiNhan divLabel textsize">Nơi nhận:</div>
                <div class="divControl divdrNoiNhan">
                    <asp:DropDownList ID="drNoiNhan2" runat="server" Width="100%">
                        <asp:ListItem>Hàng dọc đường</asp:ListItem>
                    </asp:DropDownList></div>
            </div>
            <div class="divRowCT">
                <div class="divNguoiGui divLabel textsize">Người gửi<sup style="color:red">(*)</sup>:</div>
                <div class="divControl divtxtNguoiGui">
                    <asp:TextBox ID="txtTenNguoiGui2" runat="server" Width="100%"></asp:TextBox></div>
            </div>
            <div class="divRowCT">
                <div class="divSDT divLabel textsize">Số ĐT:</div>
                <div class="divControl divtxtSDT">
                    <asp:TextBox ID="txtSDTNguoiGui2" runat="server" Width="100%" onkeyup="splitphone(this.value, this);"></asp:TextBox></div>
            </div>
            <div class="divRowCT">
                <div class="divNguoiNhan divLabel textsize">Người nhận<sup style="color:red">(*)</sup>:</div>
                <div class="divControl divtxtNguoiNhan">
                    <asp:TextBox ID="txtTenNguoiNhan2" runat="server" Width="100%"></asp:TextBox></div>
            </div>
            <div class="divRowCT">
                <div class="divSDT divLabel textsize">Số ĐT<sup style="color:red">(*)</sup>:</div>
                <div class="divControl divtxtSDT">
                    <asp:TextBox ID="txtSDTNguoiNhan2" runat="server" Width="100%" onkeyup="splitphone(this.value, this);"></asp:TextBox></div>
            </div>
            <div class="divRowCT">
                <div class="divDiaChi divLabel textsize">Địa chỉ:</div>
                <div class="divControl divtxtDiaChi">
                    <asp:TextBox ID="txtDiaChiNhan2" runat="server" Width="100%"></asp:TextBox></div>
            </div>
            <div class="divRowCT">
                <div class="divLuuY divLabel textsize">Lưu ý:</div>
                <div class="divControl divtxtLuuY">
                    <asp:TextBox ID="txtLuuY2" runat="server" Width="100%"></asp:TextBox></div>
            </div>
            <div class="divRow h3">
                <div class="divThongTinHang ">Thông tin hàng</div>
            </div>
            <div class="divRowCT">
                <div class="divHang divLabel textsize">Hàng<sup style="color:red">(*)</sup>:</div>
                <div class="divControl divtxtHang">
                    <asp:TextBox ID="txtHang2" runat="server" Width="100%"></asp:TextBox></div>
            </div>
            <div class="divRow">
                <div class="div50p">
                    <div class="divSoLuong divLabel textsize">Số lượng<sup style="color:red">(*)</sup>:</div>
                    <div class="divtxtSoLuong"><asp:TextBox ID="txtSoLuong2" Style="text-align:center" runat="server" Width="95%" Text="1"></asp:TextBox></div>
                </div>
                <div class="div50p">
                    <div class="divSoLuong divLabel textsize">Ước giá<sup style="color:red">(*)</sup>:</div>
                    <div class="divtxtSoLuong"><asp:TextBox ID="txtUocGia2" Style="text-align:center" runat="server" Width="100%" Text="0"></asp:TextBox></div>
                </div>
            </div>
            <div class="divRow">
                <div class="div50p textsize" style="text-align:center"><asp:RadioButton ID="rdCuocRoi2" runat="server" Checked="true" GroupName="cuoc2" Text="Cước rồi (CR)" Font-Bold="true"/></div>
                <div class="div50p textsize" style="text-align:center"><asp:RadioButton ID="rdChuaCuoc2" runat="server" GroupName="cuoc2" Text="Chưa cước (CC)" Font-Bold="true"/></div>
            </div>
            <%--Check Nợ, Kiểm duyệt --%>
            <div class="divRow" style="display:none">
                <asp:CheckBox ID="chkNo2" runat="server" Text="Nợ" CssClass="textsize"/>
                <asp:CheckBox ID="chkKiemDuyet2" runat="server" Text="Kiểm duyệt" CssClass="textsize"/>
            </div>
            <div class="divRowCuocPhi" style="background-color:#ffcc00">
                <div class="divCuocPhi divLabel textsize" style="text-align:center">Cước phí<sup style="color:red">(*)</sup>:</div>
                <div class="divtxtCuocPhi textsize"><asp:TextBox ID="txtCuocPhi2" runat="server" Width="100%" Text="0" ></asp:TextBox></div>
            </div>
            <div class="divRowButton">
                    <asp:Button ID="btnHuy2" runat="server" Text="Hủy"  CssClass="button red divButton textsize"/>
                    <asp:Button ID="btnLuu2" runat="server" Text="Lưu" CssClass="button green divButton textsize" />
                    <asp:Button ID="btnLuuIn2" runat="server" Text="Lưu và in" CssClass="button blue divButton textsize"/>
            </div>
        </div>


        <%--Thống kê nhanh--%>
        <div id="divThongKe"  class="divThongKe box">
            <div class="title"><span class="h2" style="padding-left:2%">thống kê nhanh</span></div>
            <div style="width:100%; height:30px; float:left"></div>
            <div class="divRowCT" style="background-color:#ffcc00">
                <div class="div50p" style="font-weight:bold">Tổng nhận: <asp:Label ID="lblTongPhieuNhan" runat="server" Text="0"></asp:Label></div>
                <div class="div50p"  style="font-weight:bold; text-align:center">Hàng tồn: <asp:Label ID="lblTongHangTon" runat="server" Text="0"></asp:Label></div>
            </div>
            <div class="divRowCT">
                <asp:GridView ID="grThongKeNhanh" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="tbl">
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="NgayNhan" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Thời gian nhận" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SoBienLai" HeaderText="Mã hàng" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="divHide box" id="divKichHoat" style="display:none">
            <img id="imgkichhoat"  src="../Image/kichhoat.png" class="divKichHoat" onclick="KichHoatPhieu(1);" />
        </div>
        <div class="divHide2 box" id="divKichHoat2"  style="display:block">
            <img id="imgkichhoat2"  src="../Image/kichhoat.png" class="divKichHoat" onclick="KichHoatPhieu(2);" />
        </div>
    </div>
        <asp:HiddenField ID="hidPhieuKichHoat" runat="server" Value="1" />
    </form>
</body>
</html>
