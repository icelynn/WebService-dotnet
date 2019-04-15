using System;
using System.Linq;
using WebServices.Models.Database;
using WebServices.Models.External;

namespace WebServices.Utility
{
    public class TokenHandle
    {
        private TokenParseResult _parseResult;
        private TokenErrorModel _errorHandler = new TokenErrorModel();

        public TokenHandleResult HandleResult { get; }

        public TokenHandle(System.Collections.Generic.Dictionary<string, string> content, string salesType)
        {
            string token = content["token"];
            string insurer = content["insurer"];

            if (!String.IsNullOrEmpty(token) && !String.IsNullOrEmpty(insurer))
            {
                TokenParse tokenParser = new TokenParse(token, insurer);
                _parseResult = tokenParser.GetUserGUID();
                if (_parseResult.Successed)
                {
                    SearchResult searchResult = SearchGUID(_parseResult.UserGUID, salesType);
                    if (searchResult.Successed)
                    {
                        // Return the info if successed
                        SalesInfo salesInfo = searchResult.RetrievedSalesInfo;
                        HandleResult = new TokenHandleResult(salesInfo, insurer);
                    }
                    else
                    {
                        // Error 14: Not found
                        HandleResult = new TokenHandleResult(_errorHandler.NotFoundError());
                    }
                }
                else
                {
                    // Error 12: Token expired    or    Error 13: Illegal token
                    HandleResult = new TokenHandleResult(_errorHandler.ParseError(_parseResult.ErrorCode));
                }
            }
            else
            {
                // Error 11: Indicates that the token or the insurer is NULL
                HandleResult = new TokenHandleResult(_errorHandler.ParamaterError());
            }
        }

        private SearchResult SearchGUID(Guid guid, string salesType)
        {
            if (String.Equals("life", salesType, StringComparison.OrdinalIgnoreCase))
            {
                using (LifeSalesInfoDbEntities entities = new LifeSalesInfoDbEntities())
                {
                    var entity = entities.LifeSalesInfos.FirstOrDefault(e => e.SalesGUID == guid);
                    return GetSearchResult(entity);
                }
            }
            else if (String.Equals("prop", salesType, StringComparison.OrdinalIgnoreCase))
            {                    
                using (PropSalesInfoDbEntities entities = new PropSalesInfoDbEntities())
                {
                    var entity = entities.PropSalesInfos.FirstOrDefault(e => e.SalesGUID == guid);
                    return GetSearchResult(entity);
                }
            }
            else
                return new SearchResult();
        }

        private SearchResult GetSearchResult(SalesInfo entity)
        {
            if (entity != null)
            {
                // Get the SalesInfo if successed
                return new SearchResult(entity);
            }
            else
                // No SalesInfo to get if the searching failed
                return new SearchResult();
        }

        private class SearchResult
        {
            public SalesInfo RetrievedSalesInfo { get; }
            public bool Successed { get; private set; }

            public SearchResult(SalesInfo salesInfo)
            {
                this.Successed = true;
                this.RetrievedSalesInfo = salesInfo;
            }

            public SearchResult()
            {
                this.Successed = false;
            }
        }

    }
}