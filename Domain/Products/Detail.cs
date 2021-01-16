using Domain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class Detail : PropertyChangedHelpClass
    {
        #region Fields
        private string _detailName;
        private int _length;
        private int _width;
        private Material _material;
        private int _quantity;
        private EdgeTape[] _edgeTapeList = new EdgeTape[4];
        #endregion

        #region Properties
        public EdgeTape[] EdgeTapeList
        {
            get { return _edgeTapeList; }
            set { _edgeTapeList = value; }
        }
        public string DetailName { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        //public string DetailName
        //{
        //    get
        //    {
        //        return _detailName;
        //    }
        //    set
        //    {
        //        if (_detailName != value)
        //        {
        //            _detailName = value;
        //            OnPropertyChanged(nameof(DetailName));
        //        }
        //    }
        //}
        //public int Length
        //{
        //    get
        //    {
        //        return _length;
        //    }
        //    set
        //    {
        //        if (_length != value)
        //        {
        //            _length = value;
        //            OnPropertyChanged(nameof(Length));
        //        }
        //    }
        //}
        //public int Width
        //{
        //    get
        //    {
        //        return _width;
        //    }
        //    set
        //    {
        //        if (_width != value)
        //        {
        //            _width = value;
        //            OnPropertyChanged(nameof(Width));
        //        }
        //    }
        //}
        public Material Material
        {
            get
            {
                return _material;
            }
            set
            {
                if (_material != value)
                {
                    _material = value;
                    OnPropertyChanged(nameof(Material));
                }
            }
        }
        //public int Quantity
        //{
        //    get
        //    {
        //        return _quantity;
        //    }
        //    set
        //    {
        //        if (_quantity != value)
        //        {
        //            _quantity = value;
        //            OnPropertyChanged(nameof(Quantity));
        //        }
        //    }
        //}
        #endregion

        #region Constructors
        public Detail(string detailName, int quantity = 1)
        {
            DetailName = detailName;
            Quantity = quantity;
        }
        public Detail()
        {

        }
        #endregion

        #region Methods
        public float Surface()
        {
            return ((float)Length * Width) / 1000000 * Quantity;
        }

        public override bool Equals(object obj)
        {
            Detail detail = obj as Detail;
            return (detail != null && detail.DetailName == DetailName);
        }
        #endregion
    }
}
