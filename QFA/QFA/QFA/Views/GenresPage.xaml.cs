using QFA.Models;
using QFA.Repositorys;
using QFA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QFA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenresPage : ContentPage
    {
        public GenresPage()
        {
            InitializeComponent();
        }

        private async void GenreSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Genre genre = (Genre)e.SelectedItem;
            
            await Navigation.PushAsync(new MoviesPage());
        }
    }
}
