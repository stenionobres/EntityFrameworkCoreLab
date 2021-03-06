﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation
{
    public class DependentEntityByFluentApiOTM
    {
        public int Id { get; set; }
        public int FirstProperty { get; set; }
        public decimal SecondProperty { get; set; }
        public int ForeignKeyToPrincipalEntity { get; set; }
    }
}
