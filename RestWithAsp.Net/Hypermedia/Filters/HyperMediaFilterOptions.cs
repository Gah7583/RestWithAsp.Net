using RestWithAsp.Net.Hypermedia.Abstract;

namespace RestWithAsp.Net.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponserEnricher> ContentResponseEnricherList { get; set; } = new List<IResponserEnricher>();


    }
}
