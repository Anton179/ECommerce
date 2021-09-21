using System.Collections.Generic;
using ECommerce.Core.DataAccess.Models.PagedRequestModels.FilterEnums;

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
