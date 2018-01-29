using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonRepertoire.Controllers;
using MonRepertoire.Models;
using MonRepertoire.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonRepertoireWebAPITests;
using Moq;
using System.Linq.Expressions;

namespace MonRepertoire.Controllers.Tests
{
    [TestClass()]
    public class MorceauControllerTests
    {
        RepertoireContext repertoireContext = MockRepertoireContext();

        private static RepertoireContext MockRepertoireContext()
        {
            var niveauComplexite = new NiveauComplexite { Id = 1, Libelle = "Facile", Ordre = 1 };

            var dbSetMorceaux = MockTools.GetDbSet(
                new List<Morceau>
                {
                    new Morceau{ Id = 1, Titre = "morceau 1", Tonalite = "C", Grille = "D | E | G | A", NiveauComplexiteId = niveauComplexite.Id, NiveauComplexite = niveauComplexite }
                    ,new Morceau{ Id = 2, Titre = "morceau 2", Tonalite = "G", Grille = "G | C | C | G", NiveauComplexiteId = niveauComplexite.Id, NiveauComplexite = niveauComplexite }
                }
            );

            var dbSetNiveauxComplexites = MockTools.GetDbSet( new List<NiveauComplexite> { niveauComplexite });

            var mockRepertoireContext = new Mock<RepertoireContext>();
            mockRepertoireContext.Setup(c => c.Morceaux).Returns(dbSetMorceaux);
            mockRepertoireContext.Setup(c => c.NiveauxComplexites).Returns(dbSetNiveauxComplexites);

            return mockRepertoireContext.Object;
        }

        [TestMethod()]
        public void GetAllTest()
        {
            MorceauController morceauController = new MorceauController(repertoireContext);
            var morceauViewModels = morceauController.GetAll();

            Assert.IsTrue(morceauViewModels != null
                          && morceauViewModels.Count() == 2
                          && morceauViewModels.FirstOrDefault(m => m.Id == 1) != null
                          && morceauViewModels.FirstOrDefault(m => m.Id == 2) != null);
        }

        [TestMethod()]
        public void GetOneTest()
        {
            MorceauController morceauController = new MorceauController(repertoireContext);
            MorceauViewModel morceauViewModel = morceauController.GetOne(1);

            Assert.IsTrue(morceauViewModel != null
                            && morceauViewModel.Titre == "morceau 1");
        }

        [TestMethod()]
        public void AddOneTest()
        {
            MorceauViewModel morceauViewModel = new MorceauViewModel
            {
                Id = 3
                ,Complexite = "Facile"
                ,Grille = "D | E | G | A"
                ,Titre = "morceau 3"
                ,Tonalite = "C"
            };

            MorceauController morceauController = new MorceauController(repertoireContext);
            morceauController.AddOne(morceauViewModel);

            Assert.IsTrue(repertoireContext.Morceaux.FirstOrDefault(m => m.Id == 3) != null);
        }

        [TestMethod()]
        public void UpdateOneTest()
        {
            MorceauViewModel morceauViewModel = new MorceauViewModel
            {
                Id = 1
                ,Complexite = "Facile"
                ,Grille = "TEST"
                ,Titre = "nouveau titre morceau 1"
                ,Tonalite = "E"
            };

            MorceauController morceauController = new MorceauController(repertoireContext);
            morceauController.UpdateOne(morceauViewModel);

            Morceau morceau = repertoireContext.Morceaux.FirstOrDefault(m => m.Id == 1);
            Assert.IsTrue(morceau != null && morceau.Titre == "nouveau titre morceau 1");
        }

        [TestMethod()]
        public void DeleteOneTest()
        {
            MorceauController morceauController = new MorceauController(repertoireContext);
            morceauController.DeleteOne(1);

            Assert.IsTrue(repertoireContext.Morceaux.FirstOrDefault(m => m.Id == 1) == null);
        }
    }
}