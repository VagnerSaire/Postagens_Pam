using Postagens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Postagens.Services
{
    public class PostsService
    {
        string base_url = "https://jsonplaceholder.typicode.com";
        PostModel postagem;
        List<PostModel> postagens;
        JsonSerializerOptions serializerOptions;

        public PostsService() { 
        serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<PostModel>> getPosts()
        {
            Uri uri = new Uri($"{base_url}/posts");
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(uri);
            string content = await responseMessage.Content.ReadAsStringAsync();
            postagens = JsonSerializer.Deserialize<List<PostModel>>(content, serializerOptions);
            return postagens;
        }
    }
}
