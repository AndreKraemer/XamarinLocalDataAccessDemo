using System;
using System.IO;
using Java.IO;
using Xamarin.Forms;
using XamarinLocalDataAccessDemo.Demos;
using XamarinLocalDataAccessDemo.Droid.Demos;
using File = System.IO.File;

[assembly:Xamarin.Forms.Dependency(typeof(EditApplicationBaseDataDemo))]
namespace XamarinLocalDataAccessDemo.Droid.Demos
{
    public class EditApplicationBaseDataDemo : IEditApplicationBaseDataDemo
    {
        public void CopyBaseDataToDocuments()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var file = Path.Combine(documentsPath, "dishes.json");
            if (!File.Exists(file))
            {
                using (var assetsStream = Forms.Context.Assets.Open("dishes.json"))
                using (var destinationStream = File.Create(file))
                {
                    assetsStream.CopyTo(destinationStream);
                }
            }
        }
    }
}