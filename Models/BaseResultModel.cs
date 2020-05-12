namespace Album_Web.Models
{
    public class BaseResultModel
    {
        public int? Code { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
        public ReturnStatus ReturnStatus { get; set; }

        public BaseResultModel(int? code = null, string message = null,
           object result = null, ReturnStatus returnStatus = ReturnStatus.Success)
        {
            this.Code = code;
            this.Result = result;
            this.Message = message;
            this.ReturnStatus = returnStatus;
        }
    }

    public enum ReturnStatus
    {
        Success = 1,
        Fail = 0,
        ConfirmIsContinue = 2,
        Error = 3
    }
}