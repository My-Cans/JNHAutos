namespace JNHAutos.Data
{
    public interface IEmailRepository
    {
        Task SendContactEmail(string name, string email, string phoneNumber, string message);
    }
}
