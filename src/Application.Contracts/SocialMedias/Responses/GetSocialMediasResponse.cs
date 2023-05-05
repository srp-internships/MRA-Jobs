using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRA.Jobs.Domain.Enums;

namespace MRA.Jobs.Application.Contracts.SocialMedias.Responses;
public class GetSocialMediasResponse
{
    public long Id { get; set; }
    public string Portfolio { get; set; }
    public SocialMediaType SocialMediaType { get; set; }
    public long ApplicantId { get; set; }
}
