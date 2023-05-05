using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MRA.Jobs.Application.Contracts.SocialMedias.Responses;

namespace MRA.Jobs.Application.Contracts.SocialMedias.Queries;
public class GetByIdSocialMedia:IRequest<GetSocialMediasResponse>
{
    public long Id { get; set; }
}
