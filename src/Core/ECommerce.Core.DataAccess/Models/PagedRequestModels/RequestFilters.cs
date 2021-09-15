using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.DataAccess.Models.PagedRequestModels
{
    public class RequestFilters
    {
        public RequestFilters()
        {
            Filters = new List<Filter>();
        }

        public FilterLogicalOperators LogicalOperator { get; set; }

        public IList<Filter> Filters { get; set; }
    }
}
