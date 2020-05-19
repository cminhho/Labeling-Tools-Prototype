using System;
using System.Collections.Generic;
using System.Text;

namespace BackendSharedCore.Pagination
{
    public interface IPageable
    {
        bool IsPaged { get; }
        int PageNumber { get; }
        int PageSize { get; }
        int Offset { get; }
    }
}
