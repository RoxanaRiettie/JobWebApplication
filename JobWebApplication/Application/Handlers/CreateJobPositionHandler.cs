using JobWebApplication.Application.Common.Interfaces;
using JobWebApplication.Application.DTOs;
using JobWebApplication.Domain;
using JobWebApplication.Infrastructure.Commands;
using MediatR;

namespace JobWebApplication.Application.Handlers
{
    public class CreateJobPositionHandler : IRequestHandler<CreateJobPositionCommand, JobPositionDto>
    {
        private readonly IJobPositionRepository _jobPositionRepository;

        public CreateJobPositionHandler(IJobPositionRepository jobPositionRepository)
        {
            _jobPositionRepository = jobPositionRepository;
        }
        public async Task<JobPositionDto> Handle(CreateJobPositionCommand request, CancellationToken cancellationToken)
        {
            // Here you would typically interact with your database or service layer to create the job position.
            // For demonstration purposes, we will return a dummy JobPositionDto.
           
            var jobPosition = new JobPosition
            {
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                Status = request.Status,
                RecruiterId = request.RecruiterId,
                DepartmentId = request.DepartmentId,
                Budget = request.Budget,
                ClosingDate = request.ClosingDate
            };
           
            jobPosition = await _jobPositionRepository.Add(jobPosition);

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
