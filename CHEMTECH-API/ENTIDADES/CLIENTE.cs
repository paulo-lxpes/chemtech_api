using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CHEMTECH_API.ENTIDADES

{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Sexo
    {
        M,
        F
    }
    public class CLIENTE
    {
        public CLIENTE(int cli_cod, string nome)
        {
            CLI_COD = cli_cod;
            NOME = nome;
        }

        public CLIENTE(string nome, Sexo sexo, DateTime data_nascimento, int idade, int cid_cod)
        {
            NOME = nome;
            SEXO = sexo;
            DATA_NASCIMENTO = data_nascimento;
            IDADE = idade;
            CID_COD = cid_cod;
        }

        public CLIENTE(int cli_cod, string nome, Sexo sexo, DateTime data_nascimento, int idade, int cid_cod)
        {
            CLI_COD = cli_cod;
            NOME = nome;
            SEXO = sexo;
            DATA_NASCIMENTO = data_nascimento;
            IDADE = idade;
            CID_COD = cid_cod;
        }

        public int CLI_COD { get; set; }
        public string NOME { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Sexo SEXO { get; set; }
        public DateTime DATA_NASCIMENTO { get; set; }
        public int IDADE { get; set; }
        public int CID_COD { get; set; }

    }
}
