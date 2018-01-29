using MonRepertoire.Helper;
using MonRepertoire.Models;
using MonRepertoire.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace MonRepertoire.Controllers
{
    public class SeanceController : BaseController<Seance, SeanceViewModel>
    {
        [HttpGet]
        public override IEnumerable<SeanceViewModel> GetAll()
        {
            var seances = repertoireContext.Seances.ToList();

            var result = seances.ConvertAll<SeanceViewModel>(
                new Converter<Seance, SeanceViewModel>(ModelConvert)
            );

            return result;
        }

        [HttpGet]
        public override SeanceViewModel GetOne(int id)
        {
            var seance = repertoireContext.Seances.Find(id);

            if (seance != null)
            {
                return ModelConvert(seance);
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        [HttpPost]
        public override void AddOne(SeanceViewModel seanceViewModel)
        {
            if (ModelState.IsValid)
            {
                var seance = ViewModelConvert(seanceViewModel);

                repertoireContext.Seances.Add(seance);

                repertoireContext.SaveChanges();
            }
        }

        [HttpPost]
        public override void UpdateOne(SeanceViewModel seanceViewModel)
        {
            if (ModelState.IsValid)
            {
                Seance seance = repertoireContext.Seances.Find(seanceViewModel.Id);

                ViewModelToModel(seanceViewModel, seance);

                repertoireContext.SaveChanges();
            }
        }

        [HttpDelete]
        public override void DeleteOne(int id)
        {
            var seance = repertoireContext.Seances.Find(id);
            if (seance != null)
            {
                repertoireContext.Seances.Remove(seance);
                repertoireContext.SaveChanges();
            }
        }

        public override void ViewModelToModel(SeanceViewModel seanceViewModel, Seance seance)
        {
            CopySimilarProperties(seanceViewModel, seance);

            var morceau = repertoireContext.Morceaux.FirstOrDefault(m => m.Titre == seanceViewModel.TitreMorceau);
            seance.MorceauId = morceau.Id;
            seance.Morceau = morceau;

            seance.DateDerniereRepetition = DateTime.ParseExact(seanceViewModel.DateDerniereRepetition, "dd/MM/yyyy", null);

            var niveauCompetence = repertoireContext.NiveauxCompetences.FirstOrDefault(n => n.Libelle == seanceViewModel.NiveauCompetence);
            seance.NiveauCompetenceId = niveauCompetence.Id;
            seance.NiveauCompetence = niveauCompetence;
        }

        public override void ModelToViewModel(Seance seance, SeanceViewModel seanceViewModel)
        {
            CopySimilarProperties(seance, seanceViewModel);

            seanceViewModel.NiveauCompetence = seance.NiveauCompetence.Libelle;
            seanceViewModel.DateDerniereRepetition = seance.DateDerniereRepetition.ToString("dd/MM/yyyy");
        }
    }
}