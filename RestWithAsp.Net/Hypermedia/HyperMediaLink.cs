using System.Text;

namespace RestWithAsp.Net.Hypermedia
{
    public class HyperMediaLink
    {
        public string Rel { get; set; }
        private string href { get; set; }
        public string Href 
        {
            get 
            { 
                object _lock  = new();
                lock (_lock)
                {
                    StringBuilder sb = new(href);
                    return sb.Replace("%2F", "/").ToString();
                }
            }
            set { href = value; }
        }
        public string Type { get; set; }
        public string Action { get; set; }
    }
}
