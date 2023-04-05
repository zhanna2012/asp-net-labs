using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class JsonPlaceholderApiClient<T>
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public JsonPlaceholderApiClient(string baseUrl)
    {
        _httpClient = new HttpClient();
        _baseUrl = baseUrl;
    }

    public async Task<AnswerModel<T>> Get()
    {
        try
        {
            var response = await _httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<T>>(responseBody);
            return new AnswerModel<T>("Data retrieved successfully", (int)response.StatusCode, data);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new AnswerModel<T>("An error occurred while retrieving the data", (int)HttpStatusCode.InternalServerError);
        }
    }

    public async Task<AnswerModel<T>> Post(T postData)
    {
        try
        {
            var json = JsonConvert.SerializeObject(postData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_baseUrl, content);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Post>(responseBody);
            return new AnswerModel<T>("Data retrieved successfully", (int)response.StatusCode, data);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new AnswerModel<T>("An error occurred while retrieving the data", (int)HttpStatusCode.InternalServerError);
        }
    }
}
