using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;
using XamarinLocalDataAccessDemo.Demos;
using XamarinLocalDataAccessDemo.iOS.Demos;
using XamarinLocalDataAccessDemo.Models;

[assembly: Dependency(typeof(ReadApplicationBaseDataDemo))]
namespace XamarinLocalDataAccessDemo.iOS.Demos
{
    public class ReadApplicationBaseDataDemo : IReadApplicationBaseDataDemo
    {
        public List<Dish> GetDishes()
        {
            var json = System.IO.File.ReadAllText("Data/dishes.json");
            return JsonConvert.DeserializeObject<List<Dish>>(json);
        }
    }
}