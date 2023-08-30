using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderByCriteria { get; private set; }

        public Expression<Func<T, object>> OrderByDescCriteria { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        protected void AddIncludes(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderByCriteria = orderByExpression;
        }

        protected void AddOrderDescBy(Expression<Func<T, object>> orderDescExpression)
        {
            OrderByDescCriteria = orderDescExpression;
        }

        protected void ApplyPaging(int take, int skip)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}
