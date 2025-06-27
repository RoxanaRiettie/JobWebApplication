using JobWebApplication.Application.Common.Interfaces;
using JobWebApplication.Application.DTOs;
using JobWebApplication.Domain;
using JobWebApplication.Infrastructure.Data;
using JobWebApplication.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace JobWebApplication.Application.Handlers
{
    public class GetAllJobPositionHandler : IRequestHandler<GetAllJobPositionsQuery, IEnumerable<JobPositionDto>>
    {
        private readonly IJobPositionRepository _jobPositionRepository;

        public GetAllJobPositionHandler(IJobPositionRepository jobPositionRepository)
        {
            _jobPositionRepository = jobPositionRepository;
        }

        public async Task<IEnumerable<JobPositionDto>> Handle(GetAllJobPositionsQuery request, CancellationToken cancellationToken)
        {
            var jobPositions = await _jobPositionRepository.GetAll();

            return jobPositions.Select(x => new JobPositionDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Location = x.Location,
                Status = x.Status,
                RecruiterId = x.RecruiterId,
                DepartmentId = x.DepartmentId,
                Budget = x.Budget,
                ClosingDate = x.ClosingDate
            });
        }
    }
}
