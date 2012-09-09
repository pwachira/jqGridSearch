using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pharmacy.linq;
using JqGridFilter.Helpers;

namespace Pharmacy
{
    internal static class Search
    {
        internal static IQueryable<T> FilterEntity<T>(filters filters, IQueryable<T> entities)
        {
            if (filters.groupOp == "AND")
                foreach (var rule in filters.rules)
                    entities = entities.Where<T>(
                        rule.field, rule.data,
                        (WhereOperation)StringEnum.Parse(typeof(WhereOperation), rule.op)
                        );
            else
            {
                //Or

                IQueryable<T> temp = null;
                foreach (var rule in filters.rules)
                {
                    var t = entities.Where<T>(rule.field, rule.data,
                    (WhereOperation)StringEnum.Parse(typeof(WhereOperation), rule.op));

                    if (temp == null)
                        temp = t;
                    else
                        temp = temp.Union(t);
                }
                entities = temp;
            }
            return entities;
        }
    }
}

