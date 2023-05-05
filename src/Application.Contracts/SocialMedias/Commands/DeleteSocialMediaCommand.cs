﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MRA.Jobs.Application.Contracts.SocialMedias.Commands;
public class DeleteSocialMediaCommand:IRequest<bool>
{
    public long Id { get; set; }
}
