using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Entities
{
    public class BuyPrice
    {
        public int carsNo { get; set; }
    
        public int buyPrice { get; set; }
    }
}
