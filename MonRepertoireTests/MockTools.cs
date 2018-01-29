using MonRepertoire.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MonRepertoireWebAPITests
{
    public class MockTools
    {
        public static DbSet<T> GetDbSet<T>(List<T> listEntities) where T : class
        {
            var queryable = listEntities.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => listEntities.Add(s));
            dbSet.Setup(m => m.Remove(It.IsAny<T>())).Callback<T>((entity) => listEntities.Remove(entity));

            return dbSet.Object;
        }
    }
}
