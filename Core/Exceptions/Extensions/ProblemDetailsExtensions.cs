using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Core.Exceptions.Extensions;

public static class ProblemDetailsExtensions
{
    public static string AsJson<TProbleDetail>(this TProbleDetail probleDetails)
        where TProbleDetail : ProblemDetails=>JsonSerializer.Serialize(probleDetails);
}
