using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Food
    {
        private int price;
        private string name;
        private string image;
        private string barcode;
        private Category category;
        private string category1;

        public int Price { get => price; set => price = value; }
        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        internal Category Category_ { get => category; set => category = value; }
        public string Barcode { get => barcode; set => barcode = value; }

        public enum Category{
            Drink, Hamberger, Ramen, Rice, Topping, Snack, Etc
        }
        public Food(int price, string name, string image, string category, string barcode)
        {
            this.Price = price;
            this.Name = name;
            this.Image = image;
            this.Barcode = barcode;
            switch(category)
            {
                case "Drink":
                    this.category = Category.Drink;
                    break;
                case "Hamberger":
                    this.category = Category.Hamberger;
                    break;
                case "Ramen":
                    this.category = Category.Ramen;
                    break;
                case "Rice":
                    this.category = Category.Rice;
                    break;
                case "Topping":
                    this.category = Category.Topping;
                    break;
                case "Snack":
                    this.category = Category.Snack;
                    break;
                default:
                    this.category = Category.Etc;
                    break;
            }
        }
        public Food(int price, string name, string category)
        {
            this.Price = price;
            this.Name = name;
            switch (category)
            {
                case "Drink":
                    this.category = Category.Drink;
                    break;
                case "Hamberger":
                    this.category = Category.Hamberger;
                    break;
                case "Ramen":
                    this.category = Category.Ramen;
                    break;
                case "Rice":
                    this.category = Category.Rice;
                    break;
                case "Topping":
                    this.category = Category.Topping;
                    break;
                case "Snack":
                    this.category = Category.Snack;
                    break;
                default:
                    this.category = Category.Etc;
                    break;
            }
        }
        public Food()
        {
            this.Price = 0;
            this.Name = "Default Name";
            this.Category_ = Category.Etc;
            this.Image = null;
        }
    }
}
