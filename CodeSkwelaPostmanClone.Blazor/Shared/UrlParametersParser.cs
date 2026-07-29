namespace CodeSkwelaPostmanClone.Blazor.Shared
{
    public class UrlParametersParser
    {
        public string ParseParameters(string url)
        {
            var result = url.Substring(url.IndexOf('?') + 1);

            return result;
        }

        public List<KeyValuePair<string, string>> ParseParametersToList(string url)
        {
            var result = new List<KeyValuePair<string, string>>();

            var parameters = ParseParameters(url);
            var splitParams = parameters.Split('&');

            foreach (var param in splitParams)
            {
                var splitParam = param.Split('=');
                if(splitParam.Length == 2)
                {
                    result.Add(new KeyValuePair<string, string>(splitParam[0], splitParam[1]));
                }
            }

            return result;
        }
    }
}
