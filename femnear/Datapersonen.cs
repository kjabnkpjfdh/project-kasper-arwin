﻿using System.ComponentModel.DataAnnotations;

namespace femnear
{
    public class Datapersonen
    {

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public int Leeftijd { get; set; }

        public int LocatieID { get; set; }

        [Key]
        public int PersoonID { get; set; }
    }
}
