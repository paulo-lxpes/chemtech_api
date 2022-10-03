using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHEMTECH_API.ENTIDADES
{
    public class CIDADE
    {
        public CIDADE(string nOME, string eSTADO)
        {
            NOME = nOME;
            ESTADO = eSTADO;
        }

        public CIDADE(int cID_COD, string nOME, string eSTADO)
        {
            CID_COD = cID_COD;
            NOME = nOME;
            ESTADO = eSTADO;
        }

        public int CID_COD { get; set; }
        public string NOME { get; set; }
        public string ESTADO { get; set; }
    }
}
