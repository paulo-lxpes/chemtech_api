using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CHEMTECH_API.ENTIDADES.ModelViews
{
    public class CLIENTEVIEW : Notifiable<Notification>
    {
        public string NOME { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Sexo SEXO { get; set; }
        public DateTime DATA_NASCIMENTO { get; set; }
        public int IDADE { get; set; }
        public int CID_COD { get; set; }

        public CLIENTE MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(NOME, "Informe o nome da cidade", "O nome não pode ser nulo")
                .IsNotNull(SEXO, "Informe o Sexo", "O sexo não pode ser nulo")
                .IsNotNull(DATA_NASCIMENTO, "Informe a data de nascimento", "A Data de nascimento não pode ser nula")
                .IsNotNull(IDADE, "Informe a Idade", "A idade não pode ser nula")
                .IsNotNull(CID_COD, "Informe a Cidade", "Escolha uma cidade"));

            return new CLIENTE(NOME, SEXO, DATA_NASCIMENTO, IDADE, CID_COD);
        }
    }

    public class CLIENTEUPDATEVIEW : Notifiable<Notification>
    {
        public int CLI_COD { get; set; }
        public string NOME { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Sexo SEXO { get; set; }
        public DateTime DATA_NASCIMENTO { get; set; }
        public int IDADE { get; set; }
        public int CID_COD { get; set; }

        public CLIENTE MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(CLI_COD, "Informe o ID do cliente para editar", "O ID não pode ser nulo")
                .IsNotNull(NOME, "Informe o nome da cidade", "O nome não pode ser nulo")
                .IsNotNull(SEXO, "Informe o Sexo", "O sexo não pode ser nulo")
                .IsNotNull(DATA_NASCIMENTO, "Informe a data de nascimento", "A Data de nascimento não pode ser nula")
                .IsNotNull(IDADE, "Informe a Idade", "A idade não pode ser nula")
                .IsNotNull(CID_COD, "Informe a Cidade", "Escolha uma cidade"));

            return new CLIENTE(CLI_COD, NOME, SEXO, DATA_NASCIMENTO, IDADE, CID_COD);
        }
    }

    public class CLIENTEUPDATENOMEVIEW : Notifiable<Notification>
    {
        public int CLI_COD { get; set; }
        public string NOME { get; set; }

        public CLIENTE MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(CLI_COD, "Informe o ID do cliente para editar", "O ID não pode ser nulo")
                .IsNotNull(NOME, "Informe o nome da cidade", "O nome não pode ser nulo"));

            return new CLIENTE(CLI_COD, NOME);
        }
    }
}
