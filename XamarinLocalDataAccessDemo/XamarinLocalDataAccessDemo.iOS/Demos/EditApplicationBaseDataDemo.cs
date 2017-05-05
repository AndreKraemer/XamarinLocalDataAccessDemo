using System;
using System.IO;
using Xamarin.Forms;
using XamarinLocalDataAccessDemo.Demos;
using XamarinLocalDataAccessDemo.iOS.Demos;

[assembly: Dependency(typeof(EditApplicationBaseDataDemo))]
namespace XamarinLocalDataAccessDemo.iOS.Demos
{
    public class EditApplicationBaseDataDemo : IEditApplicationBaseDataDemo
    {
        public void CopyBaseDataToDocuments()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var file = Path.Combine(documentsPath, "dishes.json");
            if (!File.Exists(file))
            {
                File.Copy("Data/dishes.json", file);
            }
        }
    }
}