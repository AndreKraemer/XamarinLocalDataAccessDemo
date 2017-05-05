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
    public partial class EfCoreDemoPage : ContentPage
    {
        public EfCoreDemoPage()
        {
			InitializeComponent ();
            BindingContext = new EfCoreDemoPageViewModel();
        }

    }

    class EfCoreDemoPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Dish> Items { get; }
        bool _busy;
        private DishDbContext _db;

        public EfCoreDemoPageViewModel()
        {

            var path = DependencyService.Get<IPathService>().GetDatabasePath();
            _db = new DishDbContext(path);
            _db.Database.EnsureCreated();
            RefreshDataCommand = new Command(
                async () => await RefreshData());
            AddCommand = new Command(
                async () => await AddData());

            Items = new ObservableCollection<Dish>(_db.Dishes.ToList());
        }

        public ICommand RefreshDataCommand { get; }
        public ICommand AddCommand { get; }

        async Task RefreshData()
        {
            IsBusy = true;
            IsBusy = true;
  
            Items.Clear();
            
            foreach (var dish in _db.Dishes)
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
            await _db.Dishes.AddAsync(dish);
            await _db.SaveChangesAsync();
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
