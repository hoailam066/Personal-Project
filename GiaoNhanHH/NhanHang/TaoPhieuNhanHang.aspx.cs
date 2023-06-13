using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class NhanHang_TaoPhieuNhanHang : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LoadPhieu", "KichHoatPhieu(" + hidPhieuKichHoat.Value + ");", true);
            return;
        }
        lblTime.Text = lblTime2.Text = DateTime.Now.ToString("dd/MM/yyyy - HH:mm"); 


        //Dữ liệu demo
        DataTable dt = new DataTable();
        dt.Columns.Add("NgayNhan", typeof(DateTime));
        dt.Columns.Add("SoBienLai", typeof(int));
        dt.Columns.Add("SoLuong", typeof(int));
        dt.Rows.Add(new object[] { DateTime.Now, 1, 2 });
        dt.Rows.Add(new object[] { DateTime.Now.AddMinutes(4), 1, 1 });
        dt.Rows.Add(new object[] { DateTime.Now.AddHours(1), 2, 4 });
        dt.Rows.Add(new object[] { DateTime.Now.AddHours(3), 3, 5 });
        dt.Rows.Add(new object[] { DateTime.Now.AddDays(1), 4, 8 });
        dt.Rows.Add(new object[] { DateTime.Now.AddDays(2), 7, 2 });
        lblTongPhieuNhan.Text = dt.Rows.Count.ToString();
        lblTongHangTon.Text = dt.Compute("SUM(SoLuong)", "").ToString();
        grThongKeNhanh.DataSource = dt;
        grThongKeNhanh.DataBind();

    }
}