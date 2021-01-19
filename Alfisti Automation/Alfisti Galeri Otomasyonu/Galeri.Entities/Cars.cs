using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Entities
{
    public class Cars 
    {
        public int carsNo { get; set; }
        public String cBrand { get; set; }
        public String cModel { get; set; }
        public String cColor { get; set; }
        public int cYear { get; set; }
        public String cInfo { get; set; }
        public String cExamination { get; set; }
        public String cType { get; set; }
        public String cKilometer { get; set; }
        public String cFueltype { get; set; }
        public int cEngine { get; set; }
        public String RBStatus { get; set; }
        public int carPrice { get; set; }

        

        public override string ToString()
        {
            return string.Format("ID:{0}  |  Marka:{1}    |    {2}    |    {3}    |    {4}   |   Durum:{5}    |    {6}    |    {7}    |    {8}    |    {9} |   {10}  |    Fiyat:{11} ", carsNo, cBrand , cModel ,cColor, cYear ,cInfo ,cExamination, cType ,cKilometer ,cFueltype,RBStatus,carPrice);
        }
        
    }
}
