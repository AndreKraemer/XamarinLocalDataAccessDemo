
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Xamarin.Forms;
using XamarinLocalDataAccessDemo.Demos;
using XamarinLocalDataAccessDemo.Droid.Demos;
using XamarinLocalDataAccessDemo.Models;
[assembly: Xamarin.Forms.Dependency(typeof(ReadApplicationBaseDataDemo))]
namespace XamarinLocalDataAccessDemo.Droid.Demos
{
    public class ReadApplicationBaseDataDemo : IReadApplicationBaseDataDemo
    {
        public List<Dish> GetDishes()
        {
            string json;
            using (var stream = Forms.Context.Assets.Open("dishes.json"))
            using (var reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<Dish>>(json);
        }
    }
}