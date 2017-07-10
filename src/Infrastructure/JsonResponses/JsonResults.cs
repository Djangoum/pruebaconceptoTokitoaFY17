namespace Infrastructure.JsonResponses
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class StandardJsonResult : JsonResult
    {
        public StandardJsonResult(object Value) : base(Value) { }

        public StandardJsonResult SetError(string ErrorCode)
        {
            var PreviousValue = Value;

            Value = new
            {
                Error = ErrorCode,
                Data = Value,
            };

            StatusCode = Convert.ToInt32(System.Net.HttpStatusCode.InternalServerError);
            return this;
        }

        public StandardJsonResult SetSuccess(string SuccessCode)
        {

            StatusCode = Convert.ToInt32(System.Net.HttpStatusCode.OK);

            Value = new
            {
                Success = SuccessCode,
                Data = Value,
            };

            return this;
        }

        public static StandardJsonResult Create(object Value)
        {
            return new StandardJsonResult(Value);
        }
    }
}