using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Offer
{
    public class Product
    {
        #region Properties
        public string Name { get; set; }
        public long ID { get; set; }
        public string Dimenzion { get; set; }
        public decimal Price { get; set; }
        #endregion

        #region Methods
        public override bool Equals(object obj)
        {
            return (obj is Product product && product.ID == ID);
        }
        #endregion
    }
}
