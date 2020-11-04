using System;
using System.Collections.Generic;
using System.Text;

namespace TheChuckGabbe.Models
{
    public class FavCategoryModel
    {
        public string Category { get; set; }
        public bool IsFavourite { get; set; }
        
        public string FavImg {
            get
            {
                if (IsFavourite == true)
                {
                    this.FavImg = "Fav.png";
                }
                else
                {
                    this.FavImg = "nonFav.png";
                }
                return FavImg;
            }
             set
            {
                FavImg = value;
            }
            }

    }
}
