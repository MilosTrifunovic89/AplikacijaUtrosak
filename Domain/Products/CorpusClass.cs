using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class CorpusClass : Element
    {
        #region Fields
        private int _legHeight;
        #endregion

        #region Properties
        public int LegHeight
        {
            get { return _legHeight; }
            set { _legHeight = value; }
        }
        #endregion

        #region Constructors
        public CorpusClass(long id, string elementName, int width, int height, int depth, int legHeight, Material material) : base(id, elementName, width, height, depth)
        {
            _legHeight = legHeight;
            DetailList = new ObservableCollection<Detail>() { new Detail("Plafon"), new Detail("Stranica"), new Detail("Stranica"), new Detail("Pod"), new Detail("Ledja") };
            foreach (var detalj in DetailList)
            {
                detalj.Material = material;
            }
        }

        public void CuttingList()
        {
            List<Detail> cuttingList = new List<Detail>();

            int thicknessSide = 0, thicknessCap = 0, thichnessFloor = 0;

            foreach (var detail in DetailList)
            {
                if (detail.DetailName == "Stranica")
                    thicknessSide = detail.Material.Thickness;
                else if (detail.DetailName == "Plafon")
                    thicknessCap = detail.Material.Thickness;
                else if (detail.DetailName == "Pod")
                    thichnessFloor = detail.Material.Thickness;
            }

            foreach (var detail in DetailList)
            {
                if (detail.DetailName == "Stranica")
                {
                    detail.Length = Height - LegHeight;
                    detail.Width = Depth;
                }
                else if (detail.DetailName == "Pod" || detail.DetailName == "Plafon")
                {
                    detail.Length = Width;
                    detail.Width = Depth;
                }
                else if (detail.DetailName == "Ledja")
                {
                    detail.Length = Height - 18 - _legHeight;
                    detail.Width = Width - 18;
                }

                cuttingList.Add(detail);
            }
        }

        public void AddDetail(string selectedDetail, int quantity, Material material)
        {
            int detailLength = 0, detailWidth = 0;

            if (selectedDetail == "Pregrada")
            {
                detailLength = Height - LegHeight;
                detailWidth = Depth;
            }
            else if (selectedDetail == "Polica")
            {
                detailLength = Width;
                detailWidth = Depth;
            }
            else if (selectedDetail == "Vrata")
            {
                detailLength = Height - LegHeight;
                detailWidth = Width / quantity;
            }
            else if (selectedDetail == "Sokla")
            {
                detailLength = Width;
                detailWidth = LegHeight;
            }
            else if (selectedDetail == "Top")
            {
                detailLength = Width;
                detailWidth = Depth + 20;
            }
            else if (selectedDetail == "Stranica")
            {
                detailLength = Height;
                detailWidth = Depth;
            }


            Detail detail = new Detail()
            {
                DetailName = selectedDetail,
                Length = detailLength,
                Width = detailWidth,
                Material = material,
                Quantity = quantity,
            };

            if (DetailList.Contains(detail))
            {
                foreach (var item in DetailList)
                    if (detail.DetailName == item.DetailName)
                        item.Quantity += detail.Quantity;
            }
            else
                DetailList.Add(detail);
        }

        public void RemoveDetail(Detail detail)
        {
            foreach (var item in DetailList)
            {
                if (item.DetailName == detail.DetailName)
                {
                    DetailList.Remove(item);
                    break;
                }
            }
        }
        #endregion
    }
}
