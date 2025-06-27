using JobWebApplication.Application.Common.Interfaces;
using JobWebApplication.Application.DTOs;
using JobWebApplication.Infrastructure.Data;
using JobWebApplication.Infrastructure.Queries;
using MediatR;

namespace JobWebApplication.Application.Handlers
{
    public class GetJobPositionByIdHandler : IRequestHandler<GetJobPositionByIdQuery, JobPositionDto>
    {
        private readonly IJobPositionRepository _jobPositionRepository;

        public GetJobPositionByIdHandler(IJobPositionRepository jobPositionRepository)
        {
            _jobPositionRepository = jobPositionRepository;
        }

        public async Task<JobPositionDto> Handle(GetJobPositionByIdQuery request, CancellationToken cancellationToken)
        {
            var jobPosition = await _jobPositionRepository.GetById(request.Id);
            if (jobPosition == null) return null;
            return new JobPositionDto
            {
                Id = jobPosition.Id,
                Title = jobPosition.Title,
                Description = jobPosition.Description,
                Location = jobPosition.Location,
                Status = jobPosition.Status,
                RecruiterId = jobPosition.RecruiterId,
                DepartmentId = jobPosition.DepartmentId,
                Budget = jobPosition.Budget,
                ClosingDate = jobPosition.ClosingDate
            };
        }
    }
}
