using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLocalDataAccessDemo.Demos;

namespace XamarinLocalDataAccessDemo.Pages
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaveSecureDataDemoPage : ContentPage
    {
        public SaveSecureDataDemoPage()
        {
            InitializeComponent();
            BindingContext = new SaveSecureDataDemoPageViewModel();
        }
    }

    class SaveSecureDataDemoPageViewModel : INotifyPropertyChanged
    {
        private ISecureDataDemo _service;
        
        public SaveSecureDataDemoPageViewModel()
        {
            _service = DependencyService.Get<ISecureDataDemo>();
            SaveCommand = new Command(Save);
            SecureData = _service.GetSecureData();
        }

        string secureData = "";
        public string SecureData
        {
            get { return secureData; }
            set { secureData = value;  OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }

        void Save()
        {
            _service.SaveSecureData(SecureData);
        }
           
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
    }
}
