using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Collections;
using System.Linq.Expressions;

namespace Firestorm.Infra.Data.Query
{
    public class QueryParser
    {

        public ExpressionParser ExpressionParser
        {
            get;
            private set;
        }

        public QueryParser(ExpressionParser expression)
        {
            this.ExpressionParser = expression;

        }
        
        public IQueryable FilterAndSort(IQueryable source, ExpressionParser parser)
        {
            var query = this.ExpressionParser.ParseExpresion();


            if (parser.Expressions.Count > 0 && parser.Sorts.Count == 0)
                return source.Where(query).AsQueryable();

            if (parser.Expressions.Count > 0 && parser.Sorts.Count > 0)
            {
                var sort = parser.ParseSort();
                return source.Where(query).OrderBy(sort).AsQueryable();
            }

            if(parser.Expressions.Count == 0 && parser.Sorts.Count > 0)
            {
                var sort = parser.ParseSort();
                return source.OrderBy(sort).AsQueryable();
            }

            return null;
        }

        public IQueryable FilterAndSort(IQueryable source, ExpressionParser parser, int pageSize)
        {
            var query = this.ExpressionParser.ParseExpresion();


            if (parser.Expressions.Count > 0 && parser.Sorts.Count == 0)
                return source.Where(query).Take(pageSize).AsQueryable();

            if (parser.Expressions.Count > 0 && parser.Sorts.Count > 0)
            {
                var sort = parser.ParseSort();
                return source.Where(query).OrderBy(sort).Take(pageSize).AsQueryable();
            }

            if (parser.Expressions.Count == 0 && parser.Sorts.Count > 0)
            {
                var sort = parser.ParseSort();
                return source.OrderBy(sort).Take(pageSize).AsQueryable();
            }

            return source.Take(pageSize).AsQueryable();
        }

        public int Count(IQueryable source, Query.ExpressionParser expressionParser)
        {
            if (expressionParser != null)
            {
                var query = this.ExpressionParser.ParseExpresion();

                if (!String.IsNullOrEmpty(query))
                    return source.Where(query).Count();
            }
            
            return source.Count();
        }

        public dynamic Min(IQueryable source, Query.ExpressionParser expressionParser, string field)
        {
            throw new NotImplementedException();
        }


        public dynamic Max(IQueryable source, Query.ExpressionParser expressionParser, string field)
        {
            throw new NotImplementedException();
        }

        public dynamic Avg(IQueryable source, Query.ExpressionParser expressionParser, string field)
        {
            throw new NotImplementedException();
        }
        
        public IQueryable GroupBy(IQueryable source, Query.ExpressionParser expressionParser, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
