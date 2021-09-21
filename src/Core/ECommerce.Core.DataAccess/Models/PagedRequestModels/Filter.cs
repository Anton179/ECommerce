using ECommerce.Core.DataAccess.Models.PagedRequestModels.FilterEnums;

namespace ECommerce.Core.DataAccess.Models.PagedRequestModels
{
    public class Filter
    {
        public string Path { get; set; }
        public string Value { get; set; }
        public FilterOperators Operator { get; set; }

    }
}
