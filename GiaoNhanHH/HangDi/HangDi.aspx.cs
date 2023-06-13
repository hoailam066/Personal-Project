using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HangHoa_HangDi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        if (Request.Url.Query == "")
            Response.Redirect(Request.Url.AbsoluteUri + "?tab=hangdi");
        //Load Quyền
        DataTable dt = new DataTable();
        dt.Columns.Add("TenTrang", typeof(string));
        dt.Columns.Add("TenQuyen", typeof(string));
        dt.Columns.Add("Icon", typeof(string));
        dt.Rows.Add(new object[] { "../HangDi/TaoPhieuChuyenHang.aspx", "Tạo phiếu chuyển hàng", "../Image/iconphieunhanhang.png" });
        dt.Rows.Add(new object[] { "../NhanHang/PhieuNhanCaNhan.aspx", "Danh sách phiếu nhận", "../Image/iconphieunhancanhan.png" });
        dt.Rows.Add(new object[] { "../NhanHang/SuaPhieuNhan.aspx", "Sửa phiếu nhận", "../Image/iconsuaphieunhan.png" });
        dt.Rows.Add(new object[] { "../NhanHang/GhiChuNgay.aspx", "Ghi chú", "../Image/iconghichungay.png" });
        ViewState.Add("TenTrang", "../HangDi/TaoPhieuChuyenHang.aspx");
        rptTrang.DataSource = dt;
        rpt_Quyen.DataSource = dt;
        rpt_Quyen.DataBind();
        rptTrang.DataBind();
        
    }
}