using CautaRetete.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CautaRetete.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Recipes : Page
    {

        //WebService.ServerSoapClient ServerSoapClient = new WebService.ServerSoapClient();
        List<GridItemRecipe> gridItems = new List<GridItemRecipe>();
        List<WebService.Recipes> recipes = new List<WebService.Recipes>();

        public Recipes()
        {
            this.InitializeComponent();
            // RecipesGridView.ItemsSource = new RecipeItems().ItemRecipes;
            GetRecipes();   
        }

        public async void GetRecipes()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                using (var client = new WebService.ServerSoapClient())
                {
                    var response = await client.GetRecipesAsync();
                    response.Body.GetRecipesResult.ToList().ForEach(x =>
                            RecipesGridView.Items.Add(
                                new GridItemRecipe(
                                    new Uri("http://qnimate.com/wp-content/uploads/2014/03/images2.jpg"), x.Name)
                                )
                        );

                    response.Body.GetRecipesResult.ToList().ForEach(x => recipes.Add(x));
                }
            });
        }

        private void RecipesGridView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Here I'm calculating the number of columns I want based on
            // the width of the page
        }


        private  void RecipesGridView_Loading(FrameworkElement sender, object args)
        {
            //foreach(var recipe in recipes)
            //{
            //    RecipesGridView.Items.Add(new GridItemRecipe(
            //                    new Uri("http://qnimate.com/wp-content/uploads/2014/03/images2.jpg"), recipe.Name)
            //                );
            //}
            //RecipesGridView.ItemsSource = recipes;
            //RecipesGridView.ItemsSource = gridItems;
        }
    }
}
