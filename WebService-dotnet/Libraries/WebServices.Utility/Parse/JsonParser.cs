using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebServices.Models.Database;
using WebServices.Models.External;

namespace WebServices.Utility.Parse
{
    internal static class JsonParser
    {
        public static Policy DeserializePolicy(string inputJson)
        {
            JObject jObject = JObject.Parse(inputJson);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Error,
                NullValueHandling = NullValueHandling.Include
            };
            Policy policy = JsonConvert.DeserializeObject<Policy>(inputJson, settings);

            return policy;
        }

        /// <summary>
        /// Deserialize System.Collections.Generic.Dictionary<string, string>
        /// </summary>
        /// <param name="inputJson"></param>
        /// <returns></returns>
        public static Dictionary<string, string> DeserializeStrDict(string inputJson)
        {
            Dictionary<string, string> dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(inputJson);
            return dic;
        }

        public static Dictionary<string, object> DeserializeDict(string inputJson)
        {
            Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(inputJson);
            return dic;
        }

        public static string SerializeSalesInfo(SalesInfo salesInfo)
        {
            if (salesInfo is LifeSalesInfo lInfo)
            {
                var output = new
                {
                    SalesName = lInfo.SalesName,
                    LifeInsQualID = lInfo.SalesQualID,
                    RegularQual = lInfo.SalesReg,
                    ForeignCurrencyQual = lInfo.SalesFC,
                    InvestQual = lInfo.SalesInvest,
                    MobileInsQual = lInfo.SalesMobIns
                };
                return JsonConvert.SerializeObject(output, Formatting.Indented);
            }
            else if (salesInfo is PropSalesInfo pInfo)
            {
                var output = new
                {
                    SalesName = pInfo.SalesName,
                    PropInsQualID = pInfo.SalesQualID,
                    PropInsQual = pInfo.SalesPropQual,
                    MobileInsQual = pInfo.SalesMobIns
                };
                return JsonConvert.SerializeObject(output, Formatting.Indented);
            }
            else
            {
                var output = new
                {
                    ErrorCode = "15",
                    ErrorMessage = "No related data on the server."
                };
                return JsonConvert.SerializeObject(output);
            }
        }

        public static string SerializeDictionary(Dictionary<string, object> dic)
        {
            string output = JsonConvert.SerializeObject(dic, Formatting.Indented);
            return output;
        }

        public static string SerializeStrDictionary(Dictionary<string, string> dic)
        {
            string output = JsonConvert.SerializeObject(dic, Formatting.Indented);
            return output;
        }
    }
}