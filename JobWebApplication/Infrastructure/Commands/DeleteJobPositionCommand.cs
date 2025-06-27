using JobWebApplication.Application.DTOs;
using MediatR;

namespace JobWebApplication.Infrastructure.Commands
{
    public record DeleteJobPositionCommand(int Id) : IRequest<bool>;
    
}
