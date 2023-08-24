using Core.Entities;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get;}

        List<Expression<Func<T, object>>> Includes { get;}

        Expression<Func<T, object>> OrderByCriteria { get;}

        Expression<Func<T, object>> OrderByDescCriteria { get; }

    }
}
