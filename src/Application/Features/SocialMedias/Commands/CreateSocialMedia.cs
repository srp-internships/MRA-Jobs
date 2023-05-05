using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MRA.Jobs.Application.Contracts.SocialMedias.Commands;

namespace MRA.Jobs.Application.Features.SocialMedias.Commands;
public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, long>
{
    public Task<long> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
