using MeridiaCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeridiaCoreWebAPI.Utility
{
    public class UtilityFunctions
    {
        public JsonResult ReturnResponse(object data, string status, string message)
        {
            return new JsonResult(new
            {
                data = data,
                status = status,
                message = message
            });
        }
    }
}
