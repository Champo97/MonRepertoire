using MonRepertoire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonRepertoire.ViewModels
{
    public class SeanceViewModel : BaseViewModel<Seance>
    {
        public string TitreMorceau { get; set; }
        public string NiveauCompetence { get; set; }
        public string DateDerniereRepetition { get; set; }
        public int MorceauId { get; set; }
    }
}