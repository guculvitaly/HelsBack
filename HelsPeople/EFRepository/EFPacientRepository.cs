﻿using HelsPeople.Model;
using HelsPeople.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelsPeople.EFRepository
{
    public class EFPacientRepository : RepositoryBase<Pacient>, IPacientRepository
    {
        public EFPacientRepository(ApplicationContext context) : base(context)
        {

        }


    }
}
