using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHEMTECH_API.ENTIDADES.ModelViews
{
    public class CIDADEVIEW : Notifiable<Notification>
    {
        public string NOME { get; set; }
        public string ESTADO { get; set; }

        public CIDADE MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(NOME, "Informe o nome da cidade", "O nome da cidade não pode ser nulo")
                .IsNotNull(ESTADO, "Informe o Estado da cidade", "O estado não pode ser nulo"));

            return new CIDADE(NOME, ESTADO);
        }
    }

    public class CIDADUPDATEVIEW : Notifiable<Notification>
    {
        public int CID_COD { get; set; }
        public string NOME { get; set; }
        public string ESTADO { get; set; }

        public CIDADE MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(CID_COD, "Informe o ID da cidade que queira editar", "O ID não pode ser nulo")
                .IsNotNull(NOME, "Informe o nome da cidade", "O nome da cidade não pode ser nulo")
                .IsNotNull(ESTADO, "Informe o Estado da cidade", "O estado não pode ser nulo"));

            return new CIDADE(CID_COD, NOME, ESTADO);
        }
    }
}
