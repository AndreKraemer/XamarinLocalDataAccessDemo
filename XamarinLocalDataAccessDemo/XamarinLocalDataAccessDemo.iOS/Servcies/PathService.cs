using System;
using XamarinLocalDataAccessDemo.iOS.Servcies;
using XamarinLocalDataAccessDemo.Services;

[assembly:Xamarin.Forms.Dependency(typeof(PathService))]
namespace XamarinLocalDataAccessDemo.iOS.Servcies
{
    public class PathService : IPathService
    {
        public string GetDocumentsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}