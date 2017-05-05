using System;
using XamarinLocalDataAccessDemo.Droid.Services;
using XamarinLocalDataAccessDemo.Services;

[assembly:Xamarin.Forms.Dependency(typeof(PathService))]
namespace XamarinLocalDataAccessDemo.Droid.Services
{
    public class PathService : IPathService
    {
        public string GetDocumentsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}