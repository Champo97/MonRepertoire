using System;
using MonRepertoire.Models;

namespace MonRepertoire.ViewModels
{
    public abstract class BaseViewModel<TModel>
    {
        public int Id { get; set; }
    }
}