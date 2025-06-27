using JobWebApplication.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobWebApplication.Application.Common.Interfaces
{
    public interface IJobPositionRepository
    {
        Task<JobPosition> Add(JobPosition jobPosition);
        Task<JobPosition> Update(JobPosition jobPosition);
        Task<JobPosition> GetById(int id);
        Task<IEnumerable<JobPosition>> GetAll();
        Task<bool> Delete(int id);
    }
}
