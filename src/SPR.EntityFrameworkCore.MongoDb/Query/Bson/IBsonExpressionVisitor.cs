using JetBrains.Annotations;
using SPR.EntityFrameworkCore.MongoDb.Query.Expressions;
using System.Linq.Expressions;

namespace SPR.EntityFrameworkCore.MongoDb.Query.Bson
{
    public interface IBsonExpressionVisitor
    {
        Expression VisitField([NotNull] FieldExpression fieldExpression);

        Expression VisitFind([NotNull] FindExpression findExpression);

        Expression VisitCollection([NotNull] CollectionExpression collectionExpression);
    }
}
