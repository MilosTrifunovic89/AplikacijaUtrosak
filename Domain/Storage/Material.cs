using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Material : PropertyChangedHelpClass
    {
        private long _id;
        private int _thickness;
        private string _materialName;
        private decimal _price;
        private bool _texture;
        private string _type;

        #region Properties
        public long MaterialID { get; set; }
        public int Thickness { get; set; }
        public string MaterialName { get; set; }
        public decimal Price { get; set; }
        public bool Texture { get; set; }
        public string Type { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{MaterialName}/{Thickness}";
        }

        public override bool Equals(object obj)
        {
            Material material = obj as Material;
            return (material != null && material.MaterialID == MaterialID);
        }
        #endregion
    }
}
