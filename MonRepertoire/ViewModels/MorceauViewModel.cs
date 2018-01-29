using MonRepertoire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonRepertoire.ViewModels
{
    public class MorceauViewModel : BaseViewModel<Morceau>
    {
        public string Titre { get; set; }
        public string Tonalite { get; set; }
        public string Grille { get; set; }
        public string Complexite { get; set; }
    }
}