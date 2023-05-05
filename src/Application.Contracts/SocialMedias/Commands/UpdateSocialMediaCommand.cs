using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MRA.Jobs.Domain.Enums;

namespace MRA.Jobs.Application.Contracts.SocialMedias.Commands;
public class UpdateSocialMediaCommand:IRequest<long>
{
    public long Id { get; set; }
    public string Portfolio { get; set; }
    public SocialMediaType SocialMediaType { get; set; }
    public long ApplicantId { get; set; }
}
