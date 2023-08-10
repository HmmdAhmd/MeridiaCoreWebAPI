using MeridiaCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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

        public object MapFields(object source, object destination)
        {
            foreach (PropertyInfo item in source.GetType().GetProperties())
            {
                PropertyInfo destProp = destination.GetType().GetProperty(item.Name);
                if (destProp != null && (destProp.PropertyType.FullName == item.PropertyType.FullName))
                {
                    destProp.SetValue(destination, item.GetValue(source));
                }
            }
            return destination;
        }
    }
}
