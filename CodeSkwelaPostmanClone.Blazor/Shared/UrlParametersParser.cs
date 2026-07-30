namespace CodeSkwelaPostmanClone.Blazor.Shared
{
    public class UrlParametersParser
    {
        public string ParseParameters(string url)
        {
            var result = url.Substring(url.IndexOf('?') + 1);

            return result;
        }

        public List<QueryStringParameter> ParseParametersToList(string url)
        {
            var result = new List<QueryStringParameter>();

            var parameters = ParseParameters(url);
            var splitParams = parameters.Split('&');

            foreach (var param in splitParams)
            {
                var splitParam = param.Split('=');
                if(splitParam.Length == 2)
                {
                    result.Add(new QueryStringParameter { Key = splitParam[0], Value = splitParam[1] });
                }
            }

            return result;
        }
    }
}
