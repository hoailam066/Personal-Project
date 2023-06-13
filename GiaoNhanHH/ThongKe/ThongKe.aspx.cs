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
            Response.Redirect(Request.Url.AbsoluteUri + "?tab=thongke");
        //Load Quyền
        DataTable dt = new DataTable();
        dt.Columns.Add("TenTrang", typeof(string));
        dt.Columns.Add("TenQuyen", typeof(string));
        dt.Columns.Add("Icon", typeof(string));
        dt.Rows.Add(new object[] { "../ThongKe/TimKiemHang.aspx", "Tìm kiếm hàng", "../Image/iconphieunhanhang.png" });
        dt.Rows.Add(new object[] { "../ThongKe/ThongKeHang.aspx", "Thống kê hàng", "../Image/iconphieunhancanhan.png" });
        dt.Rows.Add(new object[] { "../ThongKe/ThongKeTien.aspx", "Thống kê tiền", "../Image/iconsuaphieunhan.png" });
        dt.Rows.Add(new object[] { "../ThongKe/ThongKeChinhSua.aspx", "Thống kê chỉnh sửa", "../Image/iconghichungay.png" });
        ViewState.Add("TenTrang", "../ThongKe/TimKiemHang.aspx");
        rptTrang.DataSource = dt;
        rpt_Quyen.DataSource = dt;
        rpt_Quyen.DataBind();
        rptTrang.DataBind();
        
    }
}