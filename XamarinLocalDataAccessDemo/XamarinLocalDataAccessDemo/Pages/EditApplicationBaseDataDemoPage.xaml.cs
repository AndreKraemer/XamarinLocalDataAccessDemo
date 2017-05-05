using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLocalDataAccessDemo.Demos;
using XamarinLocalDataAccessDemo.Models;
using XamarinLocalDataAccessDemo.Services;

namespace XamarinLocalDataAccessDemo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditApplicationBaseDataDemoPage : ContentPage
    {
        public EditApplicationBaseDataDemoPage()
        {
            InitializeComponent();
            BindingContext = new EditApplicationBaseDataDemoPageViewModel();
        }

    }


    class EditApplicationBaseDataDemoPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Dish> Items { get; }


        public EditApplicationBaseDataDemoPageViewModel()
        {
            var service = DependencyService.Get<IEditApplicationBaseDataDemo>();
            service.CopyBaseDataToDocuments();


            RefreshDataCommand = new Command(RefreshData);
            AddCommand = new Command(AddData);
            Items= new ObservableCollection<Dish>(LoadDishes());
        }

        public ICommand RefreshDataCommand { get; }
        public ICommand AddCommand { get; }

        void RefreshData()
        {
            IsBusy = true;
            var dishes = LoadDishes();

            Items.Clear();
            foreach (var dish in dishes)
            {
                Items.Add(dish);
            }
            IsBusy = false;
        }

        private static List<Dish> LoadDishes()
        {
            var documentsPath = DependencyService.Get<IPathService>().GetDocumentsPath();
            var path = Path.Combine(documentsPath, "dishes.json");
            var json = File.ReadAllText(path);
            var dishes = JsonConvert.DeserializeObject<List<Dish>>(json);
            return dishes;
        }

        void AddData()
        {
            IsBusy = true;

            var dishes = LoadDishes();

            var dish = new Dish
            {
                Id = 100,
                Name = $"Ensalada Fantasia ({DateTime.Now:T})",
                Description = "Salat aus allen Zutaten, die noch übrig waren",
                Price = 1.99,
                CategoryId = 1
            };
            dishes.Insert(0, dish);


            // Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments

            var documentsPath = DependencyService.Get<IPathService>().GetDocumentsPath();
            var path = Path.Combine(documentsPath, "dishes.json");
            File.WriteAllText(path, JsonConvert.SerializeObject(dishes));

            IsBusy = false;
        }

        bool busy;
        public bool IsBusy
        {
            get { return busy; }
            set
            {
                busy = value;
                OnPropertyChanged();
                ((Command)RefreshDataCommand).ChangeCanExecute();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
