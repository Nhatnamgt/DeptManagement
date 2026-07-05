namespace DeptManagement.RazorPage;

public static class ApiUrlHelper
{
    public static string GetBaseUrl(IConfiguration configuration, string fallback = "https://deptmanagement.onrender.com/api")
    {
        var baseUrl = (configuration["ApiSettings:BaseUrl"] ?? fallback).Trim().TrimEnd('/');

        if (!baseUrl.EndsWith("/api", StringComparison.OrdinalIgnoreCase))
        {
            baseUrl += "/api";
        }

        return baseUrl;
    }
}
