namespace Shared.RequestFeatures;
public abstract class RequestParamters
{
    private int _pageSize = 10;
    private int _maxPageSize = 50;

    public int PageNumber { get; set; } = 1;

    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > _maxPageSize) ? _maxPageSize : value;
        }
    }
}
