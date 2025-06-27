using JobWebApplication.Application.DTOs;
using MediatR;

namespace JobWebApplication.Infrastructure.Queries
{
    public record GetAllJobPositionsQuery : IRequest<IEnumerable<JobPositionDto>>;

}
