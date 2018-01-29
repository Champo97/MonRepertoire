using MonRepertoire.Helper;
using MonRepertoire.Models;
using MonRepertoire.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MonRepertoire.Controllers
{
    public abstract class BaseController<TModel, TViewModel> : ApiController where TViewModel : BaseViewModel<TModel>
    {
        public RepertoireContext repertoireContext;

        public BaseController() : this(new RepertoireContext())
        {
        }

        public BaseController(RepertoireContext repertoireContext)
        {
            this.repertoireContext = repertoireContext;
        }

        [HttpGet]
        public abstract IEnumerable<TViewModel> GetAll();

        [HttpGet]
        public abstract TViewModel GetOne(int id);

        [HttpPost]
        public abstract void AddOne(TViewModel viewModel);

        [HttpPost]
        public abstract void UpdateOne(TViewModel viewModel);

        [HttpDelete]
        public abstract void DeleteOne(int id);

        public abstract void ViewModelToModel(TViewModel viewModel, TModel model);

        public abstract void ModelToViewModel(TModel model, TViewModel viewModel);

        public void CopySimilarProperties<TInput, TOutput>(TInput source, TOutput target)
        {
            var propertyInfos = typeof(TInput).GetProperties();

            foreach (var propertyInfo in propertyInfos)
            {
                var p = typeof(TOutput).GetProperty(propertyInfo.Name);

                if (p != null && propertyInfo.PropertyType == p.PropertyType)
                    p.SetValue(target, propertyInfo.GetValue(source));
            };
        }

        internal TModel ViewModelConvert(TViewModel viewModel)
        {
            TModel model = Activator.CreateInstance<TModel>();
            ViewModelToModel(viewModel, model);
            return model;
        }

        public TViewModel ModelConvert(TModel model)
        {
            TViewModel viewModel = Activator.CreateInstance<TViewModel>();
            ModelToViewModel(model, viewModel);
            return viewModel;
        }
    }
}