using QFA.Models;
using QFA.Repositorys;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QFA.ViewModels
{
    public class GenresViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Genre> Genres { get; set; }

        private bool busy;

        public bool IsBusy
        {
            get
            {
                return busy;
            }
            set
            {
                busy = value;
                OnPropertyChanged();
            }
        }

        public GenresViewModel()
        {
            Genres = new ObservableCollection<Genre>();

            GetGenresAsync();
        }

        async void GetGenresAsync()
        {
            if (!IsBusy)
            {
                Exception Error = null;

                try
                {
                    IsBusy = true;
                    var reposiroty = new GenreRepository();
                    var genres = await reposiroty.GenreMovieListAsync();

                    foreach (var genre in genres)
                        Genres.Add(genre);
                }
                catch (Exception ex)
                {
                    Error = ex;
                }
                finally
                {
                    IsBusy = false;
                }

                if (Error != null)
                    await Application.Current.MainPage.DisplayAlert("Falha ao conectar com o Servidor.", Error.Message, "OK");
            }

            return;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(
            [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
