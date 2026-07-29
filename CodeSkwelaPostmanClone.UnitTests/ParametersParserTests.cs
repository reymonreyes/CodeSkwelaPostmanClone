using CodeSkwelaPostmanClone.Blazor.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSkwelaPostmanClone.UnitTests
{
    public class ParametersParserTests
    {
        [Fact]
        public void Parse_MustGetParametersPart()
        {
            var url = "https://sample.com?param1=alpha&param2=bravo";
            var parametersExpected = "param1=alpha&param2=bravo";

            var parser = new UrlParametersParser();
            var parametersResult = parser.ParseParameters(url);

            Assert.Equal(parametersExpected, parametersResult);
        }

        [Fact]
        public void Parse_MustSplitParametersPart()
        {
            var url = "https://sample.com?param1=alpha&param2=bravo";
            var parametersExpected = new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("param1", "alpha"),
                new KeyValuePair<string, string>("param2", "bravo")
            };

            var parser = new UrlParametersParser();
            var parametersResult = parser.ParseParametersToList(url);

            Assert.Equal(parametersExpected, parametersResult);
        }        
    }
}
