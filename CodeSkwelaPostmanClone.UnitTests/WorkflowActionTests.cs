using CodeSkwelaPostmanClone.Blazor.Core.Entities;
using CodeSkwelaPostmanClone.Blazor.Shared;
using CodeSkwelaPostmanClone.Blazor.Shared.WorkflowActions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CodeSkwelaPostmanClone.UnitTests
{
    public class WorkflowActionTests
    {
        private HttpClient GetHttpClient()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"name\":\"Reymon\"}")
            };
            var handler = new FakeHttpMessageHandler(response);

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://example.com")
            };

            return httpClient;
        }

        [Fact]
        public async Task Run_MustBeCalledOnce()
        {
            var workflow = new Workflow();
            var requestSettings = new RequestSettings { Url = "https://www.example.com", Verb = "get" };            
            var mockRequestAction = Substitute.For<RequestAction>(requestSettings, GetHttpClient());
            workflow.AddAction(mockRequestAction);

            await workflow.Run();

            mockRequestAction.Received(1).Run(Arg.Any<string>());
        }

        [Fact]
        public async Task Run_NextActionMustBeCalledOnce()
        {
            var workflow = new Workflow();
            var requestSettings = new RequestSettings { Url = "https://www.example.com", Verb = "get" };
            var mockRequestAction = Substitute.For<RequestAction>(requestSettings, GetHttpClient());
            workflow.AddAction(mockRequestAction);
            var requestSettings2 = new RequestSettings { Url = "https://www.example.com", Verb = "get" };
            var mockRequestAction2 = Substitute.For<RequestAction>(requestSettings, GetHttpClient());
            workflow.AddAction(mockRequestAction2);

            await workflow.Run();

            mockRequestAction2.Received(1).Run(Arg.Any<string>());
        }

    }

    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        private readonly HttpResponseMessage _response;

        public FakeHttpMessageHandler(HttpResponseMessage response)
        {
            _response = response;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(_response);
        }
    }
}
