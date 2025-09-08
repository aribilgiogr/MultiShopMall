namespace Core.Abstracts.IServices
{
    public interface IAccountService
    {
        Task LoginAsync();
        Task RegisterAsync();
        Task ForgotPasswordAsync(string email);
        Task ResetPasswordAsync(string code);
    }
}
