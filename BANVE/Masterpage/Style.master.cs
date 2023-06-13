using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Masterpage_Style : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        DataTable dt = new DataTable();
        dt.Columns.Add("TenTrang", typeof(string));
        dt.Columns.Add("TenMenu", typeof(string));
        dt.Columns.Add("keys", typeof(string));
        dt.Rows.Add(new object[] { "../HangHoa/HangDi.aspx?tab=trangchu", "TRANG CHỦ", "trangchu" });
        dt.Rows.Add(new object[] { "../NhanHang/NhanHang.aspx?tab=nhanhang", "ĐIỀU VÉ", "dieuve" });
        dt.Rows.Add(new object[] { "../BANVE/BanVe.aspx", "BÁN VÉ", "banve" });
        dt.Rows.Add(new object[] { "../CSKH/TaoMoiCSKH.aspx", "CSKH", "cskh" });
        dt.Rows.Add(new object[] { "#", "THỐNG KÊ", "thongke" });
        dt.Rows.Add(new object[] { "../ThongKe/ThongKe.aspx?tab=thongke", "NGƯỜI DÙNG", "nguoidung" });

        rptmenu.DataSource = dt;
        rptmenu.DataBind();
    }
}
