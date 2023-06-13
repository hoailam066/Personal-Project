using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ThongKe_ThongKeHang : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("TenTrang", typeof(string));
        dt.Columns.Add("TenQuyen", typeof(string));
        dt.Rows.Add(new object[] { "../ThongKe/HangNhanTheoNgay.aspx", "Hàng nhận theo ngày"});
        dt.Rows.Add(new object[] { "../NhanHang/PhieuNhanCaNhan.aspx", "Hàng nhận theo trạm" });
        dt.Rows.Add(new object[] { "../NhanHang/SuaPhieuNhan.aspx", "Hàng giao theo trạm" });
        dt.Rows.Add(new object[] { "../NhanHang/GhiChuNgay.aspx", "Hàng trên xe" });
        dt.Rows.Add(new object[] { "../NhanHang/PhieuNhanCaNhan.aspx", "Hàng xuống theo chuyến" });
        dt.Rows.Add(new object[] { "../NhanHang/SuaPhieuNhan.aspx", "Hàng chưa chuyển" });
        dt.Rows.Add(new object[] { "../NhanHang/GhiChuNgay.aspx", "Hàng đã chuyển" });
        dt.Rows.Add(new object[] { "../NhanHang/PhieuNhanCaNhan.aspx", "Hàng đã giao" });
        dt.Rows.Add(new object[] { "../NhanHang/SuaPhieuNhan.aspx", "Tổng lượng hàng chuyển" });
        ViewState.Add("TenTrang", "../ThongKe/HangNhanTheoNgay.aspx");
        rptQuyen.DataSource = dt;
        rptQuyen.DataBind();
    }
}