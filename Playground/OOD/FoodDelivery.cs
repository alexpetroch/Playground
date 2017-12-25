using System;
using System.Collections.Generic;

#pragma warning disable CS0169, CS0649

namespace Playground.OOD
{
    public class FoodDelivery
    {
        public ISearchProvider SearchProvider;
        public List<Restaurant> SearchRestaurant(Dictionary<string, object> values)
        {
            return SearchProvider.Execute(values);
        }
    }

    public class Restaurant
    {
        private Menu _menu;
        public Menu GetMenu()
        {
            return _menu;
        }
    }

    public interface ISearchProvider
    {
        List<Restaurant> Execute(Dictionary<string, object> values);
    }

    public class RestaurantSearch : ISearchProvider
    {
        public List<Restaurant> Execute(Dictionary<string, object> values)
        {
            return new List<Restaurant>() { new Restaurant() };
        }
    }


    public class Menu
    {
        List<Food> _foods = new List<Food>() { new Food() };

        public List<Food> GetFoods()
        {
            return _foods;
        }

        public void UpdatePrice(Food food, double newPrice)
        {
            food.UpdatePrice(newPrice);
        }
    }

    public class Bucket
    {
        Dictionary<Food, int> _foodsCount = new Dictionary<Food, int>();

        public Bucket(Restaurant restaraunt)
        {

        }

        public void Add(Food food, int count)
        {
            _foodsCount.Add(food, count);
        }
    }

    public class Food
    {
        private double _price;
        public double Price => _price;
        
        public void UpdatePrice (double price)
        {
            _price = price;
        }
    }

    public class FoodBuilder
    {
        Food _food;

        public FoodBuilder(Food food)
        {
            _food = food;
        }

        public FoodBuilder WithSouce ()
        {
            _food.UpdatePrice(_food.Price * 1.2);
            return this;
        }

        public FoodBuilder WithoutSugur()
        {
            _food.UpdatePrice(_food.Price * 0.95);
            return this;
        }

        public Food Build()
        {
            return _food;
        }
    }

    public class Order
    {
        public OrderStatus _status;
        private Guid orderId;
        private User _user;

        // To track changes
        // event StatusChanged

        List<Food> _foodsToDelivery;

        public void Cancel()
        {

        } 
        
        public void Create(Bucket bucket, UserFoodDeliveryService user)
        {
            _status = OrderStatus.Created;
        }
    }

    public enum OrderStatus
    {
        Created,
        InProgress,
        UserCompleted,
        UserPayed,
        Cooking,
        InDelivery,
        Canceled,
        MoneyBack,
        Finished        
    }
        


    public class UserFoodDeliveryService
    {
        private Guid userId;

        public void PayOrder(Order order)
        {

        }
    }

}
