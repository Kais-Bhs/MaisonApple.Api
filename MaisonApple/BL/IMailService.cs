using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IMailService
    {
        Task SendEmail(string destinataire, string sujet, string corps, byte[] PieceJointe, string namePieceJointe);
        //Task SendEmailAsync(string email, string subject, string message);
    }
}
