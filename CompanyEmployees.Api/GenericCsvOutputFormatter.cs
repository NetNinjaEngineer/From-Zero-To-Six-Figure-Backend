using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace CompanyEmployees;

public class GenericCsvOutputFormatter : TextOutputFormatter
{
    public GenericCsvOutputFormatter()
    {
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
        SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
    }

    public override async Task WriteResponseBodyAsync(
        OutputFormatterWriteContext context,
        Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var buffer = new StringBuilder();

        if (context.Object is IEnumerable<object> source)
        {
            foreach (var obj in source)
            {
                var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var property in properties)
                    buffer.Append(property.GetValue(obj, null));
            }

        }
        else
        {
            var properties = context.Object?.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (properties?.Length > 0)
                foreach (var property in properties)
                    buffer.Append(property.GetValue(context.Object, null));
        }

        await response.WriteAsync(buffer.ToString());

    }
}
