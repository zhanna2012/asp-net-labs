using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {

        // 1.	Newtonsoft.Json
        // Створення об'єкту типу Person
        Person person = new Person()
        {
            FirstName = "Zhanna",
            LastName = "Rudenko",
            Age = 20
        };

        // Перетворення об'єкту типу Person у формат JSON
        string json = JsonConvert.SerializeObject(person);

        // Виведення JSON-рядка на консоль
        Console.WriteLine(json);

        // Перетворення JSON-рядка у об'єкт типу Person
        Person deserializedPerson = JsonConvert.DeserializeObject<Person>(json);

        // Виведення відновленого об'єкту на консоль
        Console.WriteLine($"First Name: {deserializedPerson.FirstName}");
        Console.WriteLine($"Last Name: {deserializedPerson.LastName}");
        Console.WriteLine($"Age: {deserializedPerson.Age}");


        //3.	System.Net.Http 

        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1");

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
        }
        else
        {
            Console.WriteLine($"HTTP Error: {response.StatusCode}");
        }

        //4.	System.Data.SqlClient 
        var connectionString = "Data Source=Zhanna;Initial Catalog=HospitalDB;Integrated Security=True";

        using var connection = new SqlConnection(connectionString);

        try
        {
            connection.Open();

            var queryString = "select * from Doctor";

            using var command = new SqlCommand(queryString, connection);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["DoctorId"]} - {reader["DoctorName"]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // 5.	System.IO 


        var path = "../../../text.txt";

        // Зчитування з файлу
        using var sr = new StreamReader(path);
        var text = sr.ReadToEnd();
        Console.WriteLine($"File output: {text}");


    }
}

class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}