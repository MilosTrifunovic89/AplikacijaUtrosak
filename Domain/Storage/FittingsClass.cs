using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Storage
{
    public class FittingsClass : PropertyChangedHelpClass
    {
        #region Fields
        private long _id;
        private string _fittingName;
        private decimal _price;
        private string _unitOfMeasure;
        private float _quantity;
        #endregion

        #region Properties
        public float Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        public string UnitOfMeasure
        {
            get { return _unitOfMeasure; }
            set { _unitOfMeasure = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string FittingName
        {
            get { return _fittingName; }
            set { _fittingName = value; }
        }

        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        #region Methods
        public override bool Equals(object obj)
        {
            return (obj is FittingsClass fittings && fittings.ID == _id);
        }
        #endregion
    }
}
