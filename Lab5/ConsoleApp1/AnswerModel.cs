using System.Net;

public class AnswerModel<T>
{
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public List<T>?Data { get; set; }
    public Post? PostAnswer { get; set; }


    public AnswerModel()
    {
        Data = new List<T>();
    }

    public AnswerModel(string message, int statusCode)
    {
        Message = message;
        StatusCode = statusCode;
        Data = new List<T>();
    }

    public AnswerModel(string message, int statusCode, List<T> data)
    {
        Message = message;
        StatusCode = statusCode;
        Data = data;
    }

    public AnswerModel(string message, int statusCode, Post postAnswer)
    {
        Message = message;
        StatusCode = statusCode;
        PostAnswer = postAnswer;
    }

    public void SetStatusCode(HttpStatusCode httpStatusCode)
    {
        StatusCode = (int)httpStatusCode;
    }
}