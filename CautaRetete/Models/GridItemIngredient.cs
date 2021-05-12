using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CautaRetete.Models
{
    public class GridItemIngredient
    {
        public string Title { get; set; }

        public GridItemIngredient(string title)
        {
            this.Title = title;
        }
    }

    public class IngredientItems
    {
        public List<GridItemIngredient> ItemIngredients = new List<GridItemIngredient>();

        public IngredientItems()
        {
            ItemIngredients = Get();
        }

        public static List<GridItemIngredient> Get()
        {
            List<GridItemIngredient> x = new List<GridItemIngredient>();
            for (int i = 1; i < 10; i++)
            {
                x.Add(new GridItemIngredient("Titlu xxx" + i));
            }
            return x;
        }

    }
}
