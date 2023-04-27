﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRA_Jobs.Domain.Entities;
public abstract class Vacancy : BaseEntity
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime PublishDate { get; set; }
    public DateTime EndDate { get; set; }
}