namespace BL
{
    public interface IMailService
    {
        Task SendEmail(string destinataire, string sujet, string corps, byte[] PieceJointe, string namePieceJointe);
        //Task SendEmailAsync(string email, string subject, string message);
    }
}
