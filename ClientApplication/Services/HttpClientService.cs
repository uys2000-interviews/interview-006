using System;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using ClientApplication.Models;

namespace ClientApplication.Services.HttpClientService;
public class HttpClientService
{   
    public static HttpClient client = new HttpClient();
    public static void SetBaseUrl(string baseUrl)
    {
        client.BaseAddress = new Uri(baseUrl);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }
    public static async Task<T?> GetAsync<T>(string url)
    {
        HttpResponseMessage response = await client.GetAsync(url);
        try{
            T? result = await response.Content.ReadFromJsonAsync<T>();
            if (result is null) return default;
            return result;
        } catch {
            return default;
        }
    }
    public static async Task<T?> PostAsync<T>(string url, T item)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync(url, item);
        T? result = await response.Content.ReadFromJsonAsync<T>();
        if (result is null) return default;
        return result;
    }
    public static async Task<HttpStatusCode> PutAsync<T>(string url, T item)
    {
        HttpResponseMessage response = await client.PutAsJsonAsync(url, item);
        return response.StatusCode;
    }
    public static async Task<HttpStatusCode> DeleteAsync(string url)
    {
        HttpResponseMessage response = await client.DeleteAsync(url);
        return response.StatusCode;
    }
    
}