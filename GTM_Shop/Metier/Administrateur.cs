﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTM_Shop.Metier
{

    public class Administrateur : Utilisateur
    {

        [Required(ErrorMessage="Une profession est obligatoire")]
        public string Profession { get; set; }

    }
}
