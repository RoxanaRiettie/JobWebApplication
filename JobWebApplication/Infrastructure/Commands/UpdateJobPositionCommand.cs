using JobWebApplication.Application.DTOs;
using MediatR;

namespace JobWebApplication.Infrastructure.Commands
{
    public record UpdateJobPositionCommand(int Id,string Title, string Description, string Location, string Status, int RecruiterId, int DepartmentId, double Budget, DateTime ClosingDate) : IRequest<JobPositionDto>;
    
}
