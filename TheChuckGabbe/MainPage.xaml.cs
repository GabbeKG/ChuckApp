using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using TheChuckGabbe.Services;
using Xamarin.Forms;
using System.Windows.Input;
using TheChuckGabbe.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace TheChuckGabbe
{
    public partial class MainPage : ContentPage
    {
        public List<FavCategoryModel> FavCategories = new List<FavCategoryModel>();
        public ObservableCollection<string> Categories { get; } = new ObservableCollection<string>();
        public ObservableCollection<FavCategoryModel> fc { get; set; } = new ObservableCollection<FavCategoryModel>();

        public ICommand LoadCommand { get; }
        public ICommand GoToSearchCommand { get; }
        public ICommand GoToCategoryCommand { get; }
        
        
        
        public MainPage()
        {
            InitializeComponent();
            
        }
            protected override async void OnAppearing()
        {
            base.OnAppearing();
                await Load();

        }    
            
            

        public async Task Load()
        {
                ApiService apiService = new ApiService();      
                Categories.Clear();


            List<FavCategoryModel> favCategories = new List<FavCategoryModel>();
                var categories = await apiService.GetCategories();

                foreach (var category in categories)
                {
                    Categories.Add(category);
                }

            foreach(var item in Categories)
            {

                fc.Add(new FavCategoryModel { Category = item, IsFavourite = false });
            }
            BindingContext = this;
                CategoryList.ItemsSource = fc.Select(c =>c.Category.ToString()).ToList();
                
            
            var isFavourite = favCategories.Select(f => f.IsFavourite);
            
            
        }

        private void BtnFav_Clicked(object sender, EventArgs e)
        {
            FavCategoryModel fav = new FavCategoryModel();
            if (fav.FavImg == "Like")
            {

            
            fav.FavImg = "Fav.png";
            }
            else
            {
                fav.FavImg = "nonFav.Png";
                
            }
        }
    }
}
