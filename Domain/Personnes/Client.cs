﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBAppartement.Domain.Personnes
{
    public class Client : Personne
    {
        public Guid id_client { get; set; }

        public Personne Personne { get; set; }
    }
}
