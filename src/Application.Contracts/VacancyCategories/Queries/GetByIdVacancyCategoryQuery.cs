﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MRA.Jobs.Domain.Entities;

namespace MRA.Jobs.Application.Contracts.VacancyCategories.Queries;
public class GetByIdVacancyCategoryQuery : IRequest<Responces.VacancyCategoryResponce>
{
    public int Id { get; set; }
}
