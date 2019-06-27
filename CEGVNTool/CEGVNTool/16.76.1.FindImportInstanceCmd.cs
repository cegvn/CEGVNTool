#region Namespaces

using System.Collections.Generic;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Application = Autodesk.Revit.ApplicationServices.Application;
using View = Autodesk.Revit.DB.View;

#endregion

namespace CEGVNTool
{
    [Transaction(TransactionMode.Manual)]
    public class FindImportInstanceCmd : IExternalCommand
    {
        public Document Doc;
        public List<CegImportInstanceInfor> InstanceList = new List<CegImportInstanceInfor>();
        public ElementId ViewId;
        public ElementId SheetId;
        public ElementId ImportId;
        public bool GotoView = false;
        public bool GotoSheet = false;
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Doc = uidoc.Document;
            Selection selection = uidoc.Selection;
            InstanceList = CegFindImportInstance.Instance.GetImportInsntaceInfors(Doc);
            using (FindImportInstanceForm form = new FindImportInstanceForm(this))
            {
                if(form.ShowDialog() != DialogResult.OK) return Result.Cancelled;
            }
            if (GotoView && ViewId != ElementId.InvalidElementId)
            {
                View view = Doc.GetElement(ViewId) as View;
                if (view != null) uidoc.ActiveView = view;
            }
            if (GotoSheet && SheetId != ElementId.InvalidElementId)
            {
                ViewSheet viewSheet = Doc.GetElement(SheetId) as ViewSheet;
                if(viewSheet != null) uidoc.ActiveView = viewSheet;
            }

            if (ImportId != ElementId.InvalidElementId)
            {
                selection.SetElementIds(new List<ElementId> {ImportId});
            }            
            return Result.Succeeded;
        }
        // end ****************
    }
}
