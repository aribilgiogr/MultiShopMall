using Core.Abstracts;
using Core.Abstracts.IServices;

namespace Business.Services
{
    public class ShowroomService(IUnitOfWork unitOfWork) : IShowroomService
    {
    }
}
