using System;
using System.Collections.Generic;
using System.Linq;
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

    class RecipeItems
    {
        public List<GridItemRecipe> ItemRecipes = new List<GridItemRecipe>();

        public RecipeItems()
        {
            //ItemRecipes = getAsync().Result;
            getAsync().Wait();
            ItemRecipes = getAsync().Result;
        }

        public async System.Threading.Tasks.Task<List<GridItemRecipe>> getAsync()
        {
            List<GridItemRecipe> x = new List<GridItemRecipe>();
            using (var client = new WebService.ServerSoapClient())
            {
                var response = await client.GetRecipesAsync();
                //response.Body.GetRecipesResult.ToList().ForEach(x =>
                //        RecipesGridView.Items.Add(
                //            new GridItemRecipe(
                //                new Uri("http://qnimate.com/wp-content/uploads/2014/03/images2.jpg"), x.Name)
                //            )
                //    );

                response.Body.GetRecipesResult.ToList().ForEach(r => x.Add(
                    new GridItemRecipe(new Uri("http://qnimate.com/wp-content/uploads/2014/03/images2.jpg"), r.Name)
                    ));
            }
            return x;
        }

    }
}