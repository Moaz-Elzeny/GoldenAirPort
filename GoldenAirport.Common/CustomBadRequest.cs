using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GoldenAirport.Common
{
    public class CustomBadRequest
    {
        public static BadRequestObjectResult CustomErrorResponse(ActionContext actionContext)
        {
            ErrorResponse ErrorResponse = new ErrorResponse() { Code = 101, Message = "Validats error", details = new List<DetailsResponse>() };
            foreach (var keyModelStatePair in actionContext.ModelState)
            {
                var key = keyModelStatePair.Key;
                var errors = keyModelStatePair.Value.Errors;
                if (errors != null && errors.Count > 0)
                {
                    DetailsResponse detailsResponse = new DetailsResponse() { Key = key };
                    foreach (var error in errors)
                    {
                        detailsResponse.Value += error.ErrorMessage + " ";
                    }
                    ErrorResponse.details.Add(detailsResponse);

                    ErrorResponse.Message = detailsResponse.Value;
                }
            }
            return new BadRequestObjectResult(ErrorResponse);
        }

        public static BadRequestObjectResult CustomExErrorResponse(Exception ex)
        {
            ErrorResponse ErrorResponse = new() { Code = 102 };

            ErrorResponse.details = new List<DetailsResponse>
                            {
                               new DetailsResponse
                               {
                                    Key = string.Join(",", ex.Data),
                                    Value = string.Join(",", ex.InnerException.Message)
                               }
                            };
            ErrorResponse.Message = ErrorResponse.details[0].Value;
            return new BadRequestObjectResult(ErrorResponse);
        }
        public static BadRequestObjectResult CustomModelStateErrorResponse(ModelStateDictionary ModelState)
        {
            ErrorResponse ErrorResponse = new() { Code = 103, Message = "Code error" };
            foreach (var modelState in ModelState)
            {
                foreach (var error in modelState.Value.Errors)
                {
                    ErrorResponse.Message = error.ErrorMessage;
                    ErrorResponse.details = new List<DetailsResponse>
                            {
                               new DetailsResponse
                               {
                                    Key = modelState.Key,
                                    Value = error.ErrorMessage
                               }
                            };
                }
            }



            return new BadRequestObjectResult(ErrorResponse);
        }
    }
}
