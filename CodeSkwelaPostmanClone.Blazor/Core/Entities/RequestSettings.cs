using CodeSkwelaPostmanClone.Blazor.Shared;

namespace CodeSkwelaPostmanClone.Blazor.Core.Entities
{
    public class RequestSettings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Verb { get; set; }
        public string Url { get; set; }
        public List<HeaderParameter> HeaderParameters { get; set; }
        public string Body { get; set; }
    }
}
