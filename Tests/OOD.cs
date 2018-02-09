using NUnit.Framework;
using Playground.OOD;
using Playground.SD;
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
            var foodToOrder = menu.GetFoods();

            Bucket bucket = new Bucket(selectRest);
            bucket.Add(foodToOrder[0], 2);

            // build food with ingredients
            FoodBuilder foodBuild = new FoodBuilder(new Food());
            var food = foodBuild.WithSouce().WithoutSugur().Build();
            bucket.Add(food, 1);

            Order order = new Order();            
            order.Create(bucket, curUser);

            curUser.PayOrder(order);

        }

        [Test]
        public static void CallCenter()
        {
            Employee dir = new Director("Brad");            
            Employee man = new Manager("Jim", dir);
            dir.AddSubordinater(man);

            Employee sub1 = new Respondent("Alex", man);
            Employee sub2 = new Respondent("Ken", man);
            man.AddSubordinater(sub1);
            man.AddSubordinater(sub2);

            CallCenter callCenter = new Playground.OOD.CallCenter(new List<Employee>() { sub1, sub2});           
            
            Call call = new Call();
            callCenter.TakeCall(call);
            callCenter.FinishCall(call);

            Call call2 = new Call();
            callCenter.DispatchCall(call2);
            callCenter.FinishCall(call2);
        }

        [Test]
        public static void ShortUrl()
        {
            ShortUrl url = new ShortUrl();
            string urlShort = url.GetShortUrl(123123123);
            Assert.That(url.GetIdFromShortUrl(urlShort) == 123123123);
        }

        [Test]
        public static void FS()
        {
            FileSystem fs = new NTFSFileSystem();
            var fsentity = fs.Find("somepath");

            // if not found
            if(fsentity == null)
            {
                // create under root
                fs.CreateDir(null, "ee");
            }

            // repeat the same for fat32. Creating file system could be in factory
            fs = new Fat32FileSystem();
            fsentity = fs.Find("somepath");

            // if not found
            if (fsentity == null)
            {
                // create under root
                fs.CreateDir(null, "ee");
            }
        }

        [Test]
        public static void OnlineReaderSystem()
        {
            Library lib = new Library();
            lib.AddBook(new Book());
            lib.AddBook(new Book());
            lib.AddBook(new Book());

            TitleSeach titleSeach = new TitleSeach();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Author", "value");
            lib.Find(titleSeach, parameters);

            CompoundSearch seachMany = new CompoundSearch();
            seachMany.AddSeach(titleSeach);
            seachMany.AddSeach(new AuthorSeach());
            lib.Find(seachMany, parameters);
        }
    }
}
