using Microsoft.AspNetCore.Mvc.Filters;

namespace RestWithAsp.Net.Hypermedia.Abstract
{
    public interface IResponserEnricher
    {
        bool CanEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context);
    }
}
