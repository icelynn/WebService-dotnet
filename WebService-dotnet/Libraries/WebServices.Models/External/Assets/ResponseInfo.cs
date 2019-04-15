
namespace WebServices.Models.External
{
    public static class ResponseSet
    {
        public static readonly ResponseInfo DownloadSuccess             = new DownloadSuccess();
        public static readonly ResponseInfo SerialNumNotFoundError      = new SerialNumNotFoundError();
        public static readonly ResponseInfo XMLnPDFInaccessError        = new XMLnPDFInaccessError();
        public static readonly ResponseInfo PDFDownloadFailureError     = new PDFDownloadFailureError();
        public static readonly ResponseInfo XMLInaccessibleError        = new XMLInaccessibleError();
        public static readonly ResponseInfo FieldsError                 = new FieldsError();
        public static readonly ResponseInfo InternalError               = new InternalError();
    }

#region ResponseInfo collections definition

    public abstract class ResponseInfo
    {
        public abstract string ResponseCode();
        public abstract string ResponseMessage();
    }

    public sealed class DownloadSuccess : ResponseInfo
    {
        private readonly string _responseCode = "00";
        private readonly string _responseMessage = "SUCCESS";

        public override sealed string ResponseCode() { return this._responseCode; }
        public override sealed string ResponseMessage() { return this._responseMessage; }
    }

    public sealed class SerialNumNotFoundError : ResponseInfo
    {
        private readonly string _responseCode = "10";
        private readonly string _responseMessage = "查無該受理號碼";

        public override sealed string ResponseCode() { return this._responseCode; }
        public override sealed string ResponseMessage() { return this._responseMessage; }

    }

    public sealed class XMLnPDFInaccessError : ResponseInfo
    {
        private readonly string _responseCode = "11";
        private readonly string _responseMessage = "無法取得資料";

        public override sealed string ResponseCode() { return this._responseCode; }
        public override sealed string ResponseMessage() { return this._responseMessage; }
    }

    public sealed class PDFDownloadFailureError : ResponseInfo
    {
        private readonly string _responseCode = "12";
        private readonly string _responseMessage = "影像檔下載失敗";

        public override sealed string ResponseCode() { return this._responseCode; }
        public override sealed string ResponseMessage() { return this._responseMessage; }
    }

    public sealed class XMLInaccessibleError : ResponseInfo
    {
        private readonly string _responseCode = "13";
        private readonly string _responseMessage = "無法取得要保書資料";

        public override sealed string ResponseCode() { return this._responseCode; }
        public override sealed string ResponseMessage() { return this._responseMessage; }
    }

    public sealed class FieldsError : ResponseInfo
    {
        private readonly string _responseCode = "14";
        private readonly string _responseMessage = "欄位錯誤";

        public sealed override string ResponseCode() { return this._responseCode; }
        public sealed override string ResponseMessage() { return this._responseMessage; }
    }

    public sealed class InternalError : ResponseInfo
    {
        private readonly string _responseCode = "99";
        private readonly string _responseMessage = "INTERNAL_ERROR";

        public override sealed string ResponseCode() { return this._responseCode; }
        public override sealed string ResponseMessage() { return this._responseMessage; }
    }

#endregion

}
