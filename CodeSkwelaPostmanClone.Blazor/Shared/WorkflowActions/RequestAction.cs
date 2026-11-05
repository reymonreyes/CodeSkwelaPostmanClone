using CodeSkwelaPostmanClone.Blazor.Core.Entities;
using System.Diagnostics;

namespace CodeSkwelaPostmanClone.Blazor.Shared.WorkflowActions
{
    public class RequestAction : WorkflowAction, IWorkflowAction
    {
        private Core.Entities.RequestSettings _requestSettings;
        private HttpClient _httpClient;        
        public RequestAction(string name, Core.Entities.RequestSettings requestSettings, HttpClient httpClient, Func<string?, Task> callback = null) : base(name, callback)
        {
            _requestSettings = requestSettings;
            _httpClient = httpClient;
        }

        private HttpRequestMessage CreateRequest(Core.Entities.RequestSettings requestSettings)
        {
            var request = new HttpRequestMessage
            {
                Method = new HttpMethod(requestSettings.Verb),
                RequestUri = new Uri(requestSettings.Url)
            };

            if (!string.IsNullOrWhiteSpace(requestSettings.Body))
                request.Content = new StringContent(requestSettings.Body);

            request.Headers.Clear();
            var requestHeader = requestSettings.HeaderParameters.Where(x => x.HeaderType == HeaderType.Request).ToList();

            foreach (var header in requestHeader)
                request.Headers.Add(header.Key, header.Value);

            if (request.Content != null) request.Content.Headers.Clear();

            var contentHeaders = requestSettings.HeaderParameters.Where(x => x.HeaderType == HeaderType.Content).ToList();

            foreach (var header in contentHeaders)
                request.Content.Headers.Add(header.Key, header.Value);

            return request;
        }

        public override async Task<string?> Run(string? parameters)
        {
            if (string.IsNullOrWhiteSpace(_requestSettings.Url))
            {
                throw new ArgumentNullException(nameof(RequestSettings.Url));
            }

            try
            {
                OnResponseOutput?.Invoke($"Running {this.Name}...");

                var request = CreateRequest(_requestSettings);
                var response = await _httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                OnResponseOutput?.Invoke(responseContent);
                return responseContent;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
