using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Storage
{
    public class EdgeTape
    {
        #region Fields
        private long _id;
        private double _thickness;
        private int _width;
        private string _type;
        private string _edgeTapeName;
        private int _length;
        private decimal _price;
        #endregion

        #region Properties
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public string EdgeTapeName
        {
            get { return _edgeTapeName; }
            set { _edgeTapeName = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public double Thickness
        {
            get { return _thickness; }
            set { _thickness = value; }
        }

        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{_edgeTapeName} | {_type} - {_width}/{_thickness}";
        }

        public override bool Equals(object obj)
        {
            return (obj is EdgeTape edgeTape && edgeTape.ID == _id);
        }
        #endregion
    }
}
