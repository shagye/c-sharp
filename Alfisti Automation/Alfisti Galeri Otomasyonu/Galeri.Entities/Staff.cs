using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Entities
{
    public class Staff
    {
        public int staffID { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String fName { get; set; }
        public String lName { get; set; }

        public override string ToString()
        {
            return string.Format("StaffID: {0}    Ad: {1}    Soyad: {2}     KullanıcıAdı: {3}    Şifre: {4} ", staffID,fName,lName, Username, Password);
        }
    }
}
