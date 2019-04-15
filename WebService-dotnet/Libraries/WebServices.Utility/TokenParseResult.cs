namespace WebServices.Utility
{
    internal class TokenParseResult
    {
        public TokenParseResult(string errorCode)
        {
            this.Successed = false;
            this.ErrorCode = errorCode;
        }

        public TokenParseResult(bool success, System.Guid guid)
        {
            this.Successed = success;
            this.UserGUID = guid;
        }

        public readonly System.Guid UserGUID;
        public bool Successed { get; }
        public string ErrorCode;
        /// Status Code:
        ///     12: Token expired
        ///     13: Insurer doesn't match that in the token

    }
}