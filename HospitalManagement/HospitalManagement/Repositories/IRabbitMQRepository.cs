using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public interface IRabbitMQRepository
    {
        void Producer(Reception reception);
    }
}
