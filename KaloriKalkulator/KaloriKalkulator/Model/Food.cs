using System;
using System.Collections.Generic;

namespace KaloriKalkulator
{
    public partial class Food
    {
        public Food ()
        {
            Food food = new Food ();
        }

        public int Id { get; set; }
        public string? Item { get; set; }
        public int? Calories { get; set; }
    }
}
