using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace BLL
{
    public class NhaCungCapBLL
    {
        
        public static DataTable layAllNhaCC()
        {
            return NhaCungCapDAL.layAllNhaCC();
        }
    }
}
