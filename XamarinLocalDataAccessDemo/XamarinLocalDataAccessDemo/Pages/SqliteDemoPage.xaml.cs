using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLocalDataAccessDemo.Models;
using XamarinLocalDataAccessDemo.Services;

namespace XamarinLocalDataAccessDemo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SqliteDemoPage : ContentPage
    {
        public SqliteDemoPage()
        {
			InitializeComponent ();
            BindingContext = new SqliteDemoPageViewModel();
        }

    }



    class SqliteDemoPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Dish> Items { get; }
        bool _busy;
        private SqliteDataBase _db;

        public SqliteDemoPageViewModel()
        {

            var path = DependencyService.Get<IPathService>().GetDatabasePath();
            _db = new SqliteDataBase(path);
            RefreshDataCommand = new Command(
                async () => await RefreshData());
            AddCommand = new Command(
                async () => await AddData());

            var t = _db.GetDishesAsync();
            t.Wait();
            var dishes = t.Result;
            Items = new ObservableCollection<Dish>(dishes);
        }

        public ICommand RefreshDataCommand { get; }
        public ICommand AddCommand { get; }

        async Task RefreshData()
        {
            IsBusy = true;
            IsBusy = true;
            var dishes = await _db.GetDishesAsync();

            Items.Clear();
            foreach (var dish in dishes)
            {
                Items.Add(dish);
            }
            IsBusy = false;
            await Task.Delay(2000);

            IsBusy = false;
        }

        async Task AddData()
        {
            IsBusy = true;
            var dish = new Dish
            {
                Name = $"Ensalada Fantasia ({DateTime.Now:T})",
                Description = "Salat aus allen Zutaten, die noch übrig waren",
                Price = 1.99,
                CategoryId = 1
            };
            await _db.SaveDishAsync(dish);
            IsBusy = false;
        }

        public bool IsBusy
        {
            get { return _busy; }
            set
            {
                _busy = value;
                OnPropertyChanged();
                ((Command)RefreshDataCommand).ChangeCanExecute();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
