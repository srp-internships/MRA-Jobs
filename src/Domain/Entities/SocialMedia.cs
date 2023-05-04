using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRA.Jobs.Domain.Enums;

namespace MRA.Jobs.Domain.Entities;
public class SocialMedia:BaseEntity
{
    public string Portfolio { get; set; }
    public SocialMediaType SocialMediaType { get; set; }
}
