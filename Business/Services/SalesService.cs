using Core.Abstracts;
using Core.Abstracts.IServices;

namespace Business.Services
{
    public class SalesService(IUnitOfWork unitOfWork) : ISalesService
    {
    }
}
