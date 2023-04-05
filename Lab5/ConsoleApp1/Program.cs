var jsonPlaceholderApiClient = new JsonPlaceholderApiClient<Post>("https://jsonplaceholder.typicode.com/posts");
var getResponse = await jsonPlaceholderApiClient.Get();
var postResponse = await jsonPlaceholderApiClient.Post(new Post { UserId = 1, Title = "My New Post1", Body = "This is the body of my new post1" });

Console.WriteLine("The result #1 is: " + getResponse.Message);
Console.WriteLine("The result #2 is: " + postResponse.Message);