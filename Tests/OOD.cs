using NUnit.Framework;
using Playground.OOD;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    [Category("OOD")]
    public class OOD
    {
        [Test]
        public static void FoodDelivery()
        {
            UserFoodDeliveryService curUser = new UserFoodDeliveryService();

            FoodDelivery delivery = new FoodDelivery();
            delivery.SearchProvider = new RestaurantSearch();
            var dict = new Dictionary<string, object>();
            dict.Add("rating", 9);
            dict.Add("title", "SomeValue");
            dict.Add("location", "SomeLocation");

            var restaraunts = delivery.SearchRestaurant(dict);
            var selectRest = restaraunts[0];

            var menu = selectRest.GetMenu();
            var foodToOrder = menu.GetFoods()[0];

            Bucket bucket = new Bucket(selectRest);
            bucket.Add(foodToOrder, 2);

            // build food with ingredients
            FoodBuilder foodBuild = new FoodBuilder(new Food());
            var food = foodBuild.WithSouce().WithoutSugur().Build();
            bucket.Add(food, 1);

            Order order = new Order();            
            order.Create(bucket, curUser);

            curUser.PayOrder(order);

        }
    }
}
