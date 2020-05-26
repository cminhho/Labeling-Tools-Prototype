
namespace LayoutService.API.Common
{
    public interface IPageable
    {
        bool IsPaged { get; }
        int PageNumber { get; }
        int PageSize { get; }
        int Offset { get; }
        Sort Sort { get; }
    }
}