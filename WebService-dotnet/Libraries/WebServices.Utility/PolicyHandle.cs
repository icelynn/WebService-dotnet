using System;
using WebServices.Models.External;
using WebServices.Utility.Parse;

namespace WebServices.Utility
{
    public class PolicyHandle
    {
        private readonly string _input = String.Empty;
        private Policy _policy;

        public PolicyHandleResult HandleResult { get; }

        public PolicyHandle(string input)
        {
            Parse(input);
            Check(HandleResult);
        }

        public PolicyHandle(string input, string outputPath, string fileName)
        {

        }

        private void Parse(string input)
        {
            this._policy = JsonParser.DeserializePolicy(input);
        }

        private void Check(PolicyHandleResult result)
        {
            result = new PolicyHandleResult();
        }
    }
}
