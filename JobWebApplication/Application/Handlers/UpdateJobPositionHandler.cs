using JobWebApplication.Application.Common.Interfaces;
using JobWebApplication.Application.DTOs;
using JobWebApplication.Domain;
using JobWebApplication.Infrastructure.Commands;
using JobWebApplication.Infrastructure.Data;
using MediatR;
using System.Runtime.InteropServices;

namespace JobWebApplication.Application.Handlers
{
    public class UpdateJobPositionHandler : IRequestHandler<UpdateJobPositionCommand,JobPositionDto>
    {
        private readonly IJobPositionRepository _jobPositionRepository;

        public UpdateJobPositionHandler(IJobPositionRepository jobPositionRepository)
        {
            _jobPositionRepository = jobPositionRepository;
        }

        public async Task<JobPositionDto> Handle(UpdateJobPositionCommand request, CancellationToken cancellationToken)
        {
            var jobPosition = new JobPosition
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                Status = request.Status,
                RecruiterId = request.RecruiterId,
                DepartmentId = request.DepartmentId,
                Budget = request.Budget,
                ClosingDate = request.ClosingDate
            };

            jobPosition = await _jobPositionRepository.Update(jobPosition);

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
