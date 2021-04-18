using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace CautaRetete.Models
{
    class GridItemRecipe
    {
        public Uri ImageLocation { get; set; }
        public string Title { get; set; }

        public GridItemRecipe(Uri image, string title)
        {
            this.ImageLocation = image;
            this.Title = title;
        }

    }

    class Items
    {
        public List<GridItemRecipe> ItemRecipes = new List<GridItemRecipe>();

        public Items()
        {
            ItemRecipes = get();
        }

        public static List<GridItemRecipe> get()
        {
            List<GridItemRecipe> x = new List<GridItemRecipe>();
            for(int i = 1; i < 10; i++)
            {
                x.Add(new GridItemRecipe(new Uri("http://qnimate.com/wp-content/uploads/2014/03/images2.jpg"), "Titlu xxx" + i));
            }
            return x;
        }

    }
}