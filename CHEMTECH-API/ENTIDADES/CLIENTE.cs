using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHEMTECH_API.ENTIDADES

{

    public enum SEXO
    {
        M,
        F
    }
    public class CLIENTE
    {
        public CLIENTE(int cLI_COD, string nOME)
        {
            CLI_COD = cLI_COD;
            NOME = nOME;
        }

        public CLIENTE(string nOME, SEXO sEXO, DateTime dATA_NASCIMENTO, int iDADE, int cID_COD)
        {
            NOME = nOME;
            SEXO = sEXO;
            DATA_NASCIMENTO = dATA_NASCIMENTO;
            IDADE = iDADE;
            CID_COD = cID_COD;
        }

        public CLIENTE(int cLI_COD, string nOME, SEXO sEXO, DateTime dATA_NASCIMENTO, int iDADE, int cID_COD)
        {
            CLI_COD = cLI_COD;
            NOME = nOME;
            SEXO = sEXO;
            DATA_NASCIMENTO = dATA_NASCIMENTO;
            IDADE = iDADE;
            CID_COD = cID_COD;
        }

        public int CLI_COD { get; set; }
        public string NOME { get; set; }
        public SEXO SEXO { get; set; }
        public DateTime DATA_NASCIMENTO { get; set; }
        public int IDADE { get; set; }
        public int CID_COD { get; set; }

    }
}
