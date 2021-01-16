using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Offer
{
    public class OfferProduct : PropertyChangedHelpClass
    {
        private long _productID;
        private int _quantity;
        private string _description;
        #region Fields
        public long OfferID { get; set; }
        public long ProductID { get { return _productID; } set { _productID = value; } }
        public string ProductName { get; set; }//ne znam
        public string Dimension { get; set; }//ne znam
        public decimal Price { get; set; }//ne znam
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if(_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
        public string Image { get; set; }
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
        #endregion

            #region Methods
        public override bool Equals(object obj)
        {
            OfferProduct oP = obj as OfferProduct;
            return (oP != null && /*offerProduct.OfferID == OfferID &&*/ ProductID == oP.ProductID);
        }
        #endregion
    }
}
