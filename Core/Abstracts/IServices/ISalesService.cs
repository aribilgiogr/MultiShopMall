namespace Core.Abstracts.IServices
{
    public interface ISalesService
    {
        Task<CurrentCart> GetCurrentCartAsync(string username);
    }
}
