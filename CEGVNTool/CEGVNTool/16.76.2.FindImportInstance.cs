using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace CEGVNTool
{
    public class CegFindImportInstance
    {
        private static CegFindImportInstance _instance;
        private CegFindImportInstance() { }
        public static CegFindImportInstance Instance => _instance ?? (_instance = new CegFindImportInstance());
        // Function
        public List<CegImportInstanceInfor> GetImportInsntaceInfors(Document doc)
        {
            List<CegImportInstanceInfor> importInsntaces = new List<CegImportInstanceInfor>();
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            IList<Element> elements = collector.OfClass(typeof(ImportInstance)).ToElements();
            Dictionary<ElementId, ElementId> viewSheetDict = ViewSheetDict(doc);
            foreach (Element element in elements)
            {
                ImportInstance importInstance = element as ImportInstance;
                if (importInstance == null) continue;
                CegImportInstanceInfor importInsntaceInfor = new CegImportInstanceInfor();
                string name = importInstance.Category.Name;
                importInsntaceInfor.Name = name;
                importInsntaceInfor.Id = element.Id;
                View view = doc.GetElement(importInstance.OwnerViewId) as View;
                if(view == null) continue;
                importInsntaceInfor.ViewId = view.Id;
                importInsntaceInfor.ViewName = view.ViewName;
                if (viewSheetDict.ContainsKey(view.Id))
                {
                    ViewSheet viewSheet = doc.GetElement(viewSheetDict[view.Id]) as ViewSheet;
                    if (viewSheet != null)
                    {
                        importInsntaceInfor.SheetId = viewSheet.Id;
                        importInsntaceInfor.SheetName = viewSheet.Name;
                        importInsntaceInfor.SheetNumber = viewSheet.SheetNumber;
                    }
                }
                importInsntaces.Add(importInsntaceInfor);
            }
            return importInsntaces;
        }

        public Dictionary<ElementId, ElementId> ViewSheetDict(Document doc)
        {
            var dict = new Dictionary<ElementId, ElementId>();
            var collector = new FilteredElementCollector(doc);
            var elements = collector.OfClass(typeof(ViewSheet)).ToElements();
            foreach (var element in elements)
            {
                var viewSheet = element as ViewSheet;
                if (viewSheet == null) continue;
                var viewIds = viewSheet.GetAllPlacedViews();
                foreach (var id in viewIds) dict[id] = viewSheet.Id;
            }

            return dict;
        }

        public CegImportInstanceInfor GetImportInstanceInfor(List<CegImportInstanceInfor> importInstanceInfors,
            ElementId elementId)
        {
            CegImportInstanceInfor importInstanceInfor = new CegImportInstanceInfor();
            foreach (CegImportInstanceInfor instanceInfor in importInstanceInfors)
            {
                if (instanceInfor.Id.IntegerValue == elementId.IntegerValue)
                    importInstanceInfor = instanceInfor;
            }
            return importInstanceInfor;
        }
        // End class---------------------------------------------------------------------------
    }

    public class CegImportInstanceInfor
    {
        public string Name { get; set; }
        public ElementId Id { get; set; }
        public string ViewName { get; set; }
        public ElementId ViewId { get; set; }
        public string SheetNumber { get; set; }
        public string SheetName { get; set; }
        public ElementId SheetId { get; set; }
    }
}


