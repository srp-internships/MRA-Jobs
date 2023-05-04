﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MRA.Jobs.Application.Contracts.VacancyTag.Commands;
public class UpdateUserTagCommand: IRequest<long>
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long TagId { get; set; }
}