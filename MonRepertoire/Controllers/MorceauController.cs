using MonRepertoire.Helper;
using MonRepertoire.Models;
using MonRepertoire.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MonRepertoire.Controllers
{
    public class MorceauController : BaseController<Morceau, MorceauViewModel>
    {
        public MorceauController() : base()
        {

        }

        public MorceauController(RepertoireContext repertoireContext) : base(repertoireContext)
        {

        }

        [HttpGet]
        public override IEnumerable<MorceauViewModel> GetAll()
        {

            var morceaux = repertoireContext.Morceaux.ToList();

            var result = morceaux.ConvertAll<MorceauViewModel>(
                new Converter<Morceau, MorceauViewModel>(ModelConvert)
            );

            return result;
        }

        [HttpGet]
        public override MorceauViewModel GetOne(int id)
        {
            var morceau = repertoireContext.Morceaux.Find(id);

            if (morceau != null)
            {
                return ModelConvert(morceau);
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        [HttpPost]
        public override void AddOne(MorceauViewModel morceauViewModel)
        {
            if (ModelState.IsValid)
            {
                var morceau = ViewModelConvert(morceauViewModel);

                repertoireContext.Morceaux.Add(morceau);

                repertoireContext.SaveChanges();
            }
        }

        [HttpPost]
        public override void UpdateOne(MorceauViewModel morceauViewModel)
        {
            if (ModelState.IsValid)
            {
                Morceau morceau = repertoireContext.Morceaux.Find(morceauViewModel.Id);

                ViewModelToModel(morceauViewModel, morceau);

                repertoireContext.SaveChanges();
            }
        }

        [HttpDelete]
        public override void DeleteOne(int id)
        {
            var morceau = repertoireContext.Morceaux.Find(id);
            if (morceau != null)
            {
                repertoireContext.Morceaux.Remove(morceau);
                repertoireContext.SaveChanges();
            }
        }

        public override void ViewModelToModel(MorceauViewModel morceauViewModel, Morceau morceau)
        {
            CopySimilarProperties(morceauViewModel, morceau);

            NiveauComplexite niveauComplexite = repertoireContext.NiveauxComplexites.FirstOrDefault(n => n.Libelle == morceauViewModel.Complexite);
            morceau.NiveauComplexiteId = niveauComplexite.Id;
            morceau.NiveauComplexite = niveauComplexite;
        }

        public override void ModelToViewModel(Morceau morceau, MorceauViewModel morceauViewModel)
        {
            CopySimilarProperties(morceau, morceauViewModel);

            var niveauComplexite = repertoireContext.NiveauxComplexites.Find(morceau.NiveauComplexiteId);
            if (niveauComplexite != null)
            {
                morceauViewModel.Complexite = niveauComplexite.Libelle;
            }
        }
    }
}