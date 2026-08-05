namespace CodeSkwelaPostmanClone.Blazor.Shared
{
    public class RequestParameter
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class QueryStringParameter : RequestParameter
    {
    }

    public class HeaderParameter : RequestParameter
    {
        public HeaderType HeaderType { get; set; }
    }

}
