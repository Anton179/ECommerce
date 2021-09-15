using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.DataAccess.Models.PagedRequestModels
{
    public class PaginatedResult<T> where T : class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public IList<T> Items { get; set; }
    }
}
