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
        dt.Rows.Add(new object[] { "../ThongKe/HangNhanTheoNgay.aspx", "Chỉnh sửa phiếu nhận"});
        dt.Rows.Add(new object[] { "../NhanHang/PhieuNhanCaNhan.aspx", "Chỉnh sửa phiếu chuyển" });
        ViewState.Add("TenTrang", "../ThongKe/HangNhanTheoNgay.aspx");
        rptQuyen.DataSource = dt;
        rptQuyen.DataBind();
    }
}