using CommunityToolkit.Mvvm.ComponentModel;
using Postagens.Models;
using Postagens.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Postagens.ViewModels
{
    public partial class PostViewModel : ObservableObject
    {
        List<PostModel> postagens;

        [ObservableProperty]
        private string titulo;

        [ObservableProperty]
        private string corpo;

        public ICommand DisplayPostsCommand { get; private set; }
        public PostViewModel() {
        
            DisplayPostsCommand = new Command(DisplayPosts);
        }

        public async void DisplayPosts()
        {
            PostsService postsservice = new PostsService();
            postagens = await postsservice.getPosts();
            Titulo = postagens[0].Title;
            Corpo = postagens[0].Body;
        }
    }
}
