using JobWebApplication.Application.Common.Interfaces;
using JobWebApplication.Infrastructure.Commands;
using JobWebApplication.Infrastructure.Data;
using MediatR;

namespace JobWebApplication.Application.Handlers
{
    public class DeleteJobPositionHandler : IRequestHandler<DeleteJobPositionCommand,bool>
    {
        private readonly IJobPositionRepository _jobPositionRepository;

        public DeleteJobPositionHandler(IJobPositionRepository jobPositionRepository)
        {
            _jobPositionRepository = jobPositionRepository;
        }

        public async Task<bool> Handle(DeleteJobPositionCommand request, CancellationToken cancellationToken)
        {
            
            return await _jobPositionRepository.Delete(request.Id);
        }
    }
}
