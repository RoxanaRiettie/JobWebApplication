using JobWebApplication.Application.Common.Interfaces;
using JobWebApplication.Domain;
using JobWebApplication.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace JobWebApplication.Infrastructure.Data.Repositories
{
    public class JobPositionRepository : IJobPositionRepository
    {
        private readonly ApplicationDbContext _dbContext; // Assuming you have a DbContext for database operations

        public JobPositionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<JobPosition> Add(JobPosition jobPosition)
        {
            _dbContext.JobPositions.Add(jobPosition); // Assuming you have a DbSet<JobPositionDto> in your DbContext
            await _dbContext.SaveChangesAsync(); // Save changes to the database
            return jobPosition; // Return the added job position
        }

        public async Task<bool> Delete(int id)
        {
            var jobPosition = await _dbContext.JobPositions.FindAsync(new object[] { id });
            if (jobPosition == null) return false;
            _dbContext.JobPositions.Remove(jobPosition);
            await _dbContext.SaveChangesAsync();
            return true; // Return true if deletion was successful
        }

        public async Task<IEnumerable<JobPosition>> GetAll()
        {
           return  await _dbContext.JobPositions.ToListAsync();
        }

        public async Task<JobPosition> GetById(int id)
        {
            return await _dbContext.JobPositions.FindAsync(new object[] { id });
        }

        public async Task<JobPosition> Update(JobPosition newJobValues)
        {
            var jobPosition = await _dbContext.JobPositions.FindAsync(new object[] { newJobValues.Id });
            if (jobPosition == null) return null;


            jobPosition.Title = newJobValues.Title;
            jobPosition.Description = newJobValues.Description;
            jobPosition.Location = newJobValues.Location;
            jobPosition.Status = newJobValues.Status;
            jobPosition.RecruiterId = newJobValues.RecruiterId;
            jobPosition.DepartmentId = newJobValues.DepartmentId;
            jobPosition.Budget = newJobValues.Budget;
            jobPosition.ClosingDate = newJobValues.ClosingDate;

            await _dbContext.SaveChangesAsync();
            return jobPosition; // Return the updated job position
        }
    }
}
