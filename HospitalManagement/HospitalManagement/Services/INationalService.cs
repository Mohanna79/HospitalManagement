using NationalCopyService.Models;
using RestEase;
using System.Threading.Tasks;

namespace HospitalManagement.Services
{
    public interface INationalService
    {
        [AllowAnyStatusCode]
        [Post("api/NationalService")]
        Task<Response<NationalsService>> Create([Body] NationalsService nationalsService);
    }
}
