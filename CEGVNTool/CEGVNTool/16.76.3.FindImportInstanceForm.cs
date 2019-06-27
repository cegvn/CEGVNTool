using System;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Form = System.Windows.Forms.Form;

namespace CEGVNTool
{
    public partial class FindImportInstanceForm : Form
    {
        private FindImportInstanceCmd _data;
        public FindImportInstanceForm(FindImportInstanceCmd data)
        {
            _data = data;
            InitializeComponent();
        }

        private void FindImportInstanceForm_Load(object sender, EventArgs e)
        {
            // load dwg instance
            foreach (CegImportInstanceInfor instanceInfor in _data.InstanceList)
            {
                int i = dtgView.Rows.Add();
                DataGridViewRow row = dtgView.Rows[i];
                // name
                DataGridViewTextBoxCell dwgCell = row.Cells[dwgName.Name] as DataGridViewTextBoxCell;
                if (dwgCell != null) dwgCell.Value = instanceInfor.Name;
                // view name 
                DataGridViewTextBoxCell viewCell = row.Cells[viewName.Name] as DataGridViewTextBoxCell;
                if (viewCell != null) viewCell.Value = instanceInfor.ViewName;
                // sheet number
                DataGridViewTextBoxCell numberCell = row.Cells[sheetNumber.Name] as DataGridViewTextBoxCell;
                if (numberCell != null) numberCell.Value = instanceInfor.SheetNumber;
                // sheet name
                DataGridViewTextBoxCell nameCell = row.Cells[sheetName.Name] as DataGridViewTextBoxCell;
                if (nameCell != null) nameCell.Value = instanceInfor.SheetName;
                // id
                DataGridViewTextBoxCell idCell = row.Cells[id.Name] as DataGridViewTextBoxCell;
                if (idCell != null) idCell.Value = instanceInfor.Id;
            }
        }

        private void gotoViewBtn_Click(object sender, EventArgs e)
        {
            if(dtgView.SelectedRows.Count == 0) return;
            string sid = dtgView.SelectedRows[0].Cells[id.Name].Value.ToString();
            int i;
            if(!int.TryParse(sid, out i)) return;
            ElementId elementId = new ElementId(i);
            if(elementId == ElementId.InvalidElementId) return;
            CegImportInstanceInfor importInstanceInfor =
                CegFindImportInstance.Instance.GetImportInstanceInfor(_data.InstanceList, elementId);
            _data.GotoView = true;
            _data.ViewId = importInstanceInfor.ViewId;
            _data.ImportId = elementId;
        }

        private void gotoSheetBtn_Click(object sender, EventArgs e)
        {
            if (dtgView.SelectedRows.Count == 0) return;
            string sid = dtgView.SelectedRows[0].Cells[id.Name].Value.ToString();
            int i;
            if (!int.TryParse(sid, out i)) return;
            ElementId elementId = new ElementId(i);
            if (elementId == ElementId.InvalidElementId) return;
            CegImportInstanceInfor importInstanceInfor =
                CegFindImportInstance.Instance.GetImportInstanceInfor(_data.InstanceList, elementId);
            _data.GotoSheet = true;
            _data.SheetId = importInstanceInfor.SheetId;
            _data.ImportId = elementId;
        }

        // some function
    }
}
