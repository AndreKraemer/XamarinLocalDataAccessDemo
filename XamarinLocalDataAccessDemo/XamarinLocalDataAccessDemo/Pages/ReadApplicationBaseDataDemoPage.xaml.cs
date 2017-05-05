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
using XamarinLocalDataAccessDemo.Demos;
using XamarinLocalDataAccessDemo.Models;

namespace XamarinLocalDataAccessDemo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReadApplicationBaseDataDemoPage : ContentPage
    {
        public ReadApplicationBaseDataDemoPage()
        {
            InitializeComponent();
            BindingContext = new ReadApplicationBaseDataDemoPageViewModel();
        }
    }



    class ReadApplicationBaseDataDemoPageViewModel
    {
        public ObservableCollection<Dish> Items { get; }

        public ReadApplicationBaseDataDemoPageViewModel()
        {
            var service = DependencyService.Get<IReadApplicationBaseDataDemo>();
            var dishes = service.GetDishes();
            Items = new ObservableCollection<Dish>(dishes);
        }


    }
}
