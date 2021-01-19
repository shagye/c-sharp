using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Entities
{
    public class Rental_List
    {
        public int carsNo { get; set; }
        public String cModel { get; set; }
        public String cBrand { get; set; }
        public int rentalNo { get; set; }
        public int clientID { get; set; }

        public override string ToString()
        {
            return string.Format("RentalNo: {0}    AraçNo: {1}    Model: {2}     Marka: {3}    MüşteriID: {4} ",rentalNo,carsNo,cModel,cBrand,clientID);
        }
    }
}
