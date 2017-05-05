using System.Collections.Generic;
using XamarinLocalDataAccessDemo.Models;

namespace XamarinLocalDataAccessDemo.Demos
{
    public interface IReadApplicationBaseDataDemo
    {
        List<Dish> GetDishes();
    }
}