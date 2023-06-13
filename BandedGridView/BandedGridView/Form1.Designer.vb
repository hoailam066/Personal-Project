<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnAddNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnBandAdd = New DHSErp.Control.DHSSimpleButton()
        Me.btnBandUp = New DHSErp.Control.DHSSimpleButton()
        Me.btnBandDel = New DHSErp.Control.DHSSimpleButton()
        Me.btnBandDown = New DHSErp.Control.DHSSimpleButton()
        Me.btnCopyBand = New DHSErp.Control.DHSSimpleButton()
        Me.lsbBand = New DevExpress.XtraEditors.ListBoxControl()
        Me.PropertyBand = New System.Windows.Forms.PropertyGrid()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.gridPreview = New DHSErp.Control.DHSGridControl()
        Me.bgvPreview = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.btnSave = New DHSErp.Control.DHSSimpleButton()
        Me.txtmenuid = New DHSErp.Control.DHSTextEdit()
        Me.DhsLabelControl1 = New DHSErp.Control.DHSLabelControl()
        Me.txtmamau = New DHSErp.Control.DHSTextEdit()
        Me.DhsLabelControl2 = New DHSErp.Control.DHSLabelControl()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnColumnAdd = New DHSErp.Control.DHSSimpleButton()
        Me.btnColumnUp = New DHSErp.Control.DHSSimpleButton()
        Me.btnColumnDel = New DHSErp.Control.DHSSimpleButton()
        Me.btnColumnDown = New DHSErp.Control.DHSSimpleButton()
        Me.btnCopyColumn = New DHSErp.Control.DHSSimpleButton()
        Me.lsbColumn = New DevExpress.XtraEditors.ListBoxControl()
        Me.PropertyColumn = New System.Windows.Forms.PropertyGrid()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnAddExxcel = New DHSErp.Control.DHSSimpleButton()
        Me.btnDelExxcel = New DHSErp.Control.DHSSimpleButton()
        Me.btnCopyExxcelObject = New DHSErp.Control.DHSSimpleButton()
        Me.lsbExcelObject = New DevExpress.XtraEditors.ListBoxControl()
        Me.PropertyExcelObject = New System.Windows.Forms.PropertyGrid()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnTestExportExcel = New DHSErp.Control.DHSSimpleButton()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.lsbBand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.gridPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtmenuid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtmamau.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.lsbColumn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.lsbExcelObject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnAddNew, Me.mnDelete, Me.mnUp, Me.mnDown})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(129, 92)
        '
        'mnAddNew
        '
        Me.mnAddNew.Name = "mnAddNew"
        Me.mnAddNew.Size = New System.Drawing.Size(128, 22)
        Me.mnAddNew.Text = "Thêm mới"
        '
        'mnDelete
        '
        Me.mnDelete.Name = "mnDelete"
        Me.mnDelete.Size = New System.Drawing.Size(128, 22)
        Me.mnDelete.Text = "Xóa"
        '
        'mnUp
        '
        Me.mnUp.Name = "mnUp"
        Me.mnUp.Size = New System.Drawing.Size(128, 22)
        Me.mnUp.Text = "Lên"
        '
        'mnDown
        '
        Me.mnDown.Name = "mnDown"
        Me.mnDown.Size = New System.Drawing.Size(128, 22)
        Me.mnDown.Text = "Xuống"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(3, 59)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(522, 522)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Band group"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lsbBand, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PropertyBand, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 21)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(518, 499)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 2)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnBandAdd, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnBandUp, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnBandDel, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnBandDown, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnCopyBand, 4, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(518, 50)
        Me.TableLayoutPanel2.TabIndex = 6
        '
        'btnBandAdd
        '
        Me.btnBandAdd.Image = CType(resources.GetObject("btnBandAdd.Image"), System.Drawing.Image)
        Me.btnBandAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnBandAdd.Location = New System.Drawing.Point(3, 3)
        Me.btnBandAdd.Name = "btnBandAdd"
        Me.btnBandAdd.ResourceID = Nothing
        Me.btnBandAdd.Size = New System.Drawing.Size(48, 44)
        Me.btnBandAdd.TabIndex = 6
        Me.btnBandAdd.ToolTip = "Add"
        '
        'btnBandUp
        '
        Me.btnBandUp.Image = CType(resources.GetObject("btnBandUp.Image"), System.Drawing.Image)
        Me.btnBandUp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnBandUp.Location = New System.Drawing.Point(111, 3)
        Me.btnBandUp.Name = "btnBandUp"
        Me.btnBandUp.ResourceID = Nothing
        Me.btnBandUp.Size = New System.Drawing.Size(48, 44)
        Me.btnBandUp.TabIndex = 6
        Me.btnBandUp.ToolTip = "Up"
        '
        'btnBandDel
        '
        Me.btnBandDel.Image = CType(resources.GetObject("btnBandDel.Image"), System.Drawing.Image)
        Me.btnBandDel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnBandDel.Location = New System.Drawing.Point(57, 3)
        Me.btnBandDel.Name = "btnBandDel"
        Me.btnBandDel.ResourceID = Nothing
        Me.btnBandDel.Size = New System.Drawing.Size(48, 44)
        Me.btnBandDel.TabIndex = 6
        Me.btnBandDel.ToolTip = "Delete"
        '
        'btnBandDown
        '
        Me.btnBandDown.Image = CType(resources.GetObject("btnBandDown.Image"), System.Drawing.Image)
        Me.btnBandDown.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnBandDown.Location = New System.Drawing.Point(165, 3)
        Me.btnBandDown.Name = "btnBandDown"
        Me.btnBandDown.ResourceID = Nothing
        Me.btnBandDown.Size = New System.Drawing.Size(52, 44)
        Me.btnBandDown.TabIndex = 6
        Me.btnBandDown.ToolTip = "Down"
        '
        'btnCopyBand
        '
        Me.btnCopyBand.Image = CType(resources.GetObject("btnCopyBand.Image"), System.Drawing.Image)
        Me.btnCopyBand.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnCopyBand.Location = New System.Drawing.Point(223, 3)
        Me.btnCopyBand.Name = "btnCopyBand"
        Me.btnCopyBand.ResourceID = Nothing
        Me.btnCopyBand.Size = New System.Drawing.Size(48, 44)
        Me.btnCopyBand.TabIndex = 6
        Me.btnCopyBand.ToolTip = "Copy"
        '
        'lsbBand
        '
        Me.lsbBand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsbBand.Location = New System.Drawing.Point(3, 53)
        Me.lsbBand.Name = "lsbBand"
        Me.lsbBand.Size = New System.Drawing.Size(201, 443)
        Me.lsbBand.TabIndex = 6
        '
        'PropertyBand
        '
        Me.PropertyBand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyBand.Location = New System.Drawing.Point(210, 53)
        Me.PropertyBand.Name = "PropertyBand"
        Me.PropertyBand.Size = New System.Drawing.Size(305, 443)
        Me.PropertyBand.TabIndex = 7
        '
        'GroupControl3
        '
        Me.TableLayoutPanel7.SetColumnSpan(Me.GroupControl3, 3)
        Me.GroupControl3.Controls.Add(Me.gridPreview)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl3.Location = New System.Drawing.Point(3, 587)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(1578, 171)
        Me.GroupControl3.TabIndex = 2
        Me.GroupControl3.Text = "Preview"
        '
        'gridPreview
        '
        Me.gridPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPreview.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.gridPreview.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.gridPreview.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.gridPreview.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.gridPreview.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.gridPreview.Location = New System.Drawing.Point(2, 21)
        Me.gridPreview.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.gridPreview.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridPreview.MainView = Me.bgvPreview
        Me.gridPreview.Name = "gridPreview"
        Me.gridPreview.Size = New System.Drawing.Size(1574, 148)
        Me.gridPreview.TabIndex = 0
        Me.gridPreview.UseEmbeddedNavigator = True
        Me.gridPreview.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvPreview})
        '
        'bgvPreview
        '
        Me.bgvPreview.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand1})
        Me.bgvPreview.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn1, Me.BandedGridColumn2})
        Me.bgvPreview.GridControl = Me.gridPreview
        Me.bgvPreview.Name = "bgvPreview"
        Me.bgvPreview.OptionsView.ColumnAutoWidth = False
        Me.bgvPreview.OptionsView.EnableAppearanceEvenRow = True
        Me.bgvPreview.OptionsView.ShowGroupPanel = False
        '
        'gridBand1
        '
        Me.gridBand1.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.gridBand1.AppearanceHeader.Options.UseBackColor = True
        Me.gridBand1.Caption = "gridBand1"
        Me.gridBand1.Columns.Add(Me.BandedGridColumn1)
        Me.gridBand1.Columns.Add(Me.BandedGridColumn2)
        Me.gridBand1.Name = "gridBand1"
        Me.gridBand1.VisibleIndex = 0
        Me.gridBand1.Width = 150
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BandedGridColumn1.AppearanceHeader.Options.UseBackColor = True
        Me.BandedGridColumn1.Caption = "BandedGridColumn1"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.Visible = True
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BandedGridColumn2.AppearanceHeader.Options.UseBackColor = True
        Me.BandedGridColumn2.Caption = "BandedGridColumn2"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'GridBand2
        '
        Me.GridBand2.Caption = "GridBand1"
        Me.GridBand2.Name = "GridBand2"
        Me.GridBand2.VisibleIndex = -1
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(22, 9)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.ResourceID = Nothing
        Me.btnSave.Size = New System.Drawing.Size(85, 34)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Lưu"
        '
        'txtmenuid
        '
        Me.txtmenuid.EditValue = "01.01.01"
        Me.txtmenuid.Location = New System.Drawing.Point(232, 15)
        Me.txtmenuid.Name = "txtmenuid"
        Me.txtmenuid.Size = New System.Drawing.Size(100, 20)
        Me.txtmenuid.TabIndex = 4
        '
        'DhsLabelControl1
        '
        Me.DhsLabelControl1.Location = New System.Drawing.Point(178, 18)
        Me.DhsLabelControl1.Name = "DhsLabelControl1"
        Me.DhsLabelControl1.ResourceID = Nothing
        Me.DhsLabelControl1.Size = New System.Drawing.Size(34, 13)
        Me.DhsLabelControl1.TabIndex = 5
        Me.DhsLabelControl1.Text = "Menuid"
        '
        'txtmamau
        '
        Me.txtmamau.EditValue = "01"
        Me.txtmamau.Location = New System.Drawing.Point(417, 15)
        Me.txtmamau.Name = "txtmamau"
        Me.txtmamau.Size = New System.Drawing.Size(100, 20)
        Me.txtmamau.TabIndex = 4
        '
        'DhsLabelControl2
        '
        Me.DhsLabelControl2.Location = New System.Drawing.Point(363, 18)
        Me.DhsLabelControl2.Name = "DhsLabelControl2"
        Me.DhsLabelControl2.ResourceID = Nothing
        Me.DhsLabelControl2.Size = New System.Drawing.Size(20, 13)
        Me.DhsLabelControl2.TabIndex = 5
        Me.DhsLabelControl2.Text = "Mẫu"
        '
        'GroupControl4
        '
        Me.GroupControl4.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl4.Location = New System.Drawing.Point(531, 59)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(522, 522)
        Me.GroupControl4.TabIndex = 1
        Me.GroupControl4.Text = "Band column"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lsbColumn, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.PropertyColumn, 1, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(2, 21)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(518, 499)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 6
        Me.TableLayoutPanel3.SetColumnSpan(Me.TableLayoutPanel4, 2)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnColumnAdd, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnColumnUp, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnColumnDel, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnColumnDown, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnCopyColumn, 4, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(518, 50)
        Me.TableLayoutPanel4.TabIndex = 6
        '
        'btnColumnAdd
        '
        Me.btnColumnAdd.Image = CType(resources.GetObject("btnColumnAdd.Image"), System.Drawing.Image)
        Me.btnColumnAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnColumnAdd.Location = New System.Drawing.Point(3, 3)
        Me.btnColumnAdd.Name = "btnColumnAdd"
        Me.btnColumnAdd.ResourceID = Nothing
        Me.btnColumnAdd.Size = New System.Drawing.Size(48, 44)
        Me.btnColumnAdd.TabIndex = 6
        Me.btnColumnAdd.ToolTip = "Add"
        '
        'btnColumnUp
        '
        Me.btnColumnUp.Image = CType(resources.GetObject("btnColumnUp.Image"), System.Drawing.Image)
        Me.btnColumnUp.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnColumnUp.Location = New System.Drawing.Point(111, 3)
        Me.btnColumnUp.Name = "btnColumnUp"
        Me.btnColumnUp.ResourceID = Nothing
        Me.btnColumnUp.Size = New System.Drawing.Size(48, 44)
        Me.btnColumnUp.TabIndex = 6
        Me.btnColumnUp.ToolTip = "Up"
        '
        'btnColumnDel
        '
        Me.btnColumnDel.Image = CType(resources.GetObject("btnColumnDel.Image"), System.Drawing.Image)
        Me.btnColumnDel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnColumnDel.Location = New System.Drawing.Point(57, 3)
        Me.btnColumnDel.Name = "btnColumnDel"
        Me.btnColumnDel.ResourceID = Nothing
        Me.btnColumnDel.Size = New System.Drawing.Size(48, 44)
        Me.btnColumnDel.TabIndex = 6
        Me.btnColumnDel.ToolTip = "Delete"
        '
        'btnColumnDown
        '
        Me.btnColumnDown.Image = CType(resources.GetObject("btnColumnDown.Image"), System.Drawing.Image)
        Me.btnColumnDown.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnColumnDown.Location = New System.Drawing.Point(165, 3)
        Me.btnColumnDown.Name = "btnColumnDown"
        Me.btnColumnDown.ResourceID = Nothing
        Me.btnColumnDown.Size = New System.Drawing.Size(52, 44)
        Me.btnColumnDown.TabIndex = 6
        Me.btnColumnDown.ToolTip = "Down"
        '
        'btnCopyColumn
        '
        Me.btnCopyColumn.Image = CType(resources.GetObject("btnCopyColumn.Image"), System.Drawing.Image)
        Me.btnCopyColumn.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnCopyColumn.Location = New System.Drawing.Point(223, 3)
        Me.btnCopyColumn.Name = "btnCopyColumn"
        Me.btnCopyColumn.ResourceID = Nothing
        Me.btnCopyColumn.Size = New System.Drawing.Size(48, 44)
        Me.btnCopyColumn.TabIndex = 6
        Me.btnCopyColumn.ToolTip = "Copy"
        '
        'lsbColumn
        '
        Me.lsbColumn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsbColumn.Location = New System.Drawing.Point(3, 53)
        Me.lsbColumn.Name = "lsbColumn"
        Me.lsbColumn.Size = New System.Drawing.Size(201, 443)
        Me.lsbColumn.TabIndex = 6
        '
        'PropertyColumn
        '
        Me.PropertyColumn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyColumn.Location = New System.Drawing.Point(210, 53)
        Me.PropertyColumn.Name = "PropertyColumn"
        Me.PropertyColumn.Size = New System.Drawing.Size(305, 443)
        Me.PropertyColumn.TabIndex = 7
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.TableLayoutPanel5)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(1059, 59)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(522, 522)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "Excel object"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel6, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.lsbExcelObject, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.PropertyExcelObject, 1, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(2, 21)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(518, 499)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 4
        Me.TableLayoutPanel5.SetColumnSpan(Me.TableLayoutPanel6, 2)
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.btnAddExxcel, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.btnDelExxcel, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.btnCopyExxcelObject, 2, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(518, 50)
        Me.TableLayoutPanel6.TabIndex = 6
        '
        'btnAddExxcel
        '
        Me.btnAddExxcel.Image = CType(resources.GetObject("btnAddExxcel.Image"), System.Drawing.Image)
        Me.btnAddExxcel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAddExxcel.Location = New System.Drawing.Point(3, 3)
        Me.btnAddExxcel.Name = "btnAddExxcel"
        Me.btnAddExxcel.ResourceID = Nothing
        Me.btnAddExxcel.Size = New System.Drawing.Size(48, 44)
        Me.btnAddExxcel.TabIndex = 6
        Me.btnAddExxcel.ToolTip = "Add"
        '
        'btnDelExxcel
        '
        Me.btnDelExxcel.Image = CType(resources.GetObject("btnDelExxcel.Image"), System.Drawing.Image)
        Me.btnDelExxcel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnDelExxcel.Location = New System.Drawing.Point(57, 3)
        Me.btnDelExxcel.Name = "btnDelExxcel"
        Me.btnDelExxcel.ResourceID = Nothing
        Me.btnDelExxcel.Size = New System.Drawing.Size(48, 44)
        Me.btnDelExxcel.TabIndex = 6
        Me.btnDelExxcel.ToolTip = "Delete"
        '
        'btnCopyExxcelObject
        '
        Me.btnCopyExxcelObject.Image = CType(resources.GetObject("btnCopyExxcelObject.Image"), System.Drawing.Image)
        Me.btnCopyExxcelObject.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnCopyExxcelObject.Location = New System.Drawing.Point(111, 3)
        Me.btnCopyExxcelObject.Name = "btnCopyExxcelObject"
        Me.btnCopyExxcelObject.ResourceID = Nothing
        Me.btnCopyExxcelObject.Size = New System.Drawing.Size(48, 44)
        Me.btnCopyExxcelObject.TabIndex = 6
        Me.btnCopyExxcelObject.ToolTip = "Copy"
        '
        'lsbExcelObject
        '
        Me.lsbExcelObject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsbExcelObject.Location = New System.Drawing.Point(3, 53)
        Me.lsbExcelObject.Name = "lsbExcelObject"
        Me.lsbExcelObject.Size = New System.Drawing.Size(201, 443)
        Me.lsbExcelObject.TabIndex = 6
        '
        'PropertyExcelObject
        '
        Me.PropertyExcelObject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyExcelObject.Location = New System.Drawing.Point(210, 53)
        Me.PropertyExcelObject.Name = "PropertyExcelObject"
        Me.PropertyExcelObject.Size = New System.Drawing.Size(305, 443)
        Me.PropertyExcelObject.TabIndex = 7
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 3
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.Controls.Add(Me.GroupControl2, 2, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.GroupControl4, 1, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.GroupControl1, 0, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.GroupControl3, 0, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 3
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(1584, 761)
        Me.TableLayoutPanel7.TabIndex = 6
        '
        'Panel1
        '
        Me.TableLayoutPanel7.SetColumnSpan(Me.Panel1, 3)
        Me.Panel1.Controls.Add(Me.btnTestExportExcel)
        Me.Panel1.Controls.Add(Me.txtmenuid)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.DhsLabelControl2)
        Me.Panel1.Controls.Add(Me.txtmamau)
        Me.Panel1.Controls.Add(Me.DhsLabelControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1578, 50)
        Me.Panel1.TabIndex = 3
        '
        'btnTestExportExcel
        '
        Me.btnTestExportExcel.Location = New System.Drawing.Point(599, 15)
        Me.btnTestExportExcel.Name = "btnTestExportExcel"
        Me.btnTestExportExcel.ResourceID = Nothing
        Me.btnTestExportExcel.Size = New System.Drawing.Size(99, 23)
        Me.btnTestExportExcel.TabIndex = 6
        Me.btnTestExportExcel.Text = "Test xuất excel "
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1584, 761)
        Me.Controls.Add(Me.TableLayoutPanel7)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.lsbBand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.gridPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtmenuid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtmamau.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.lsbColumn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        CType(Me.lsbExcelObject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnAddNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gridPreview As DHSErp.Control.DHSGridControl
    Friend WithEvents bgvPreview As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents btnSave As DHSErp.Control.DHSSimpleButton
    Friend WithEvents txtmenuid As DHSErp.Control.DHSTextEdit
    Friend WithEvents DhsLabelControl1 As DHSErp.Control.DHSLabelControl
    Friend WithEvents txtmamau As DHSErp.Control.DHSTextEdit
    Friend WithEvents DhsLabelControl2 As DHSErp.Control.DHSLabelControl
    Friend WithEvents gridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lsbBand As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents PropertyBand As System.Windows.Forms.PropertyGrid
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnBandAdd As DHSErp.Control.DHSSimpleButton
    Friend WithEvents btnBandDel As DHSErp.Control.DHSSimpleButton
    Friend WithEvents btnBandUp As DHSErp.Control.DHSSimpleButton
    Friend WithEvents btnBandDown As DHSErp.Control.DHSSimpleButton
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnColumnAdd As DHSErp.Control.DHSSimpleButton
    Friend WithEvents btnColumnUp As DHSErp.Control.DHSSimpleButton
    Friend WithEvents btnColumnDel As DHSErp.Control.DHSSimpleButton
    Friend WithEvents btnColumnDown As DHSErp.Control.DHSSimpleButton
    Friend WithEvents lsbColumn As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents PropertyColumn As System.Windows.Forms.PropertyGrid
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnAddExxcel As DHSErp.Control.DHSSimpleButton
    Friend WithEvents btnDelExxcel As DHSErp.Control.DHSSimpleButton
    Friend WithEvents lsbExcelObject As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents PropertyExcelObject As System.Windows.Forms.PropertyGrid
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCopyBand As DHSErp.Control.DHSSimpleButton
    Friend WithEvents btnCopyExxcelObject As DHSErp.Control.DHSSimpleButton
    Friend WithEvents btnCopyColumn As DHSErp.Control.DHSSimpleButton
    Friend WithEvents btnTestExportExcel As DHSErp.Control.DHSSimpleButton
End Class
