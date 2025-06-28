using Postagens.ViewModels;

namespace Postagens.Views;

public partial class PostView : ContentPage
{
	public PostView()
	{
		InitializeComponent();
        BindingContext = new PostViewModel();
    }
}