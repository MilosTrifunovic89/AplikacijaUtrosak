using System.Collections.ObjectModel;

namespace Domain.Products
{
    public class TableClass : Element
    {
        #region Properties
        public int BinderWidth { get; set; }
        #endregion

        #region Constructors
        public TableClass(long id, string elementName, int width, int height, int depth, int binderWidth, Material material) : base(id, elementName, width, height, depth)
        {
            BinderWidth = binderWidth;
            DetailList = new ObservableCollection<Detail> { new Detail("Ploca"), new Detail("Stranica"), new Detail("Stranica"), new Detail("Vezac") };
            foreach (Detail detail in DetailList)
            {
                detail.Material = material;
            }
        }

        public TableClass(long id, string elementName, int width, int depth, int height, Material material) : base()
        {
            ID = id;
            ElementName = elementName;
            Width = width;
            Depth = depth;
            Height = height;
            Material = material;

            DetailList = new ObservableCollection<Detail> { new Detail("Ploca") };
            foreach (Detail detail in DetailList)
            {
                detail.Material = material;
            }
        }
        #endregion

        #region Methods
        public void CuttingList()
        {
            ObservableCollection<Detail> cuttingList = new ObservableCollection<Detail>();

            int thicknessSide = 0, thicknessBoard = 0, thichnessBinder = 0;

            foreach (var detail in DetailList)
            {
                if (detail.DetailName == "Stranica")
                    thicknessSide = detail.Material.Thickness;
                else if (detail.DetailName == "Ploca")
                    thicknessBoard = detail.Material.Thickness;
                else if (detail.DetailName == "Vezac")
                    thichnessBinder = detail.Material.Thickness;
            }

            foreach (var detail in DetailList)
            {
                if (detail.DetailName == "Stranica")
                {
                    detail.Length = Height;
                    detail.Width = Depth;
                }
                else if (detail.DetailName == "Ploca")
                {
                    detail.Length = Width;
                    detail.Width = Depth;
                }
                else if (detail.DetailName == "Vezac")
                {
                    detail.Length = Width;
                    detail.Width = BinderWidth;
                }

                cuttingList.Add(detail);
            }
        }
        #endregion
    }
}
