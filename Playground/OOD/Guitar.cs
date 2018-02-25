using System.Collections.Generic;

namespace Playground.OOD
{
    /*
    Design Guitar Inventory System (Object Oriented Design).

    Functional/user cases:
     - There is inventory system which stores and provides information for guitars
     - User can search, delete or remove guitar
     - Any user can remove? yes
     - What attributes for searching: name, color. Many guitars can be returned
     - Delete guitar. Pass specific instance or id.
 
     Core object: CRC card
 
      InventorySystem   <-      Guitar
       keep collections			      								
       Add
       Remove
       Search 

      ISearch -> take list returns list
      Class specify parameters.  
         
    */

    #pragma warning disable CS0169, CS0649

    class UseCase
    {
        void Start()
        {
            var inv = new Inventory();
            inv.Add(new Guitar());

            var nameSearch = new NameSeach("test");
            inv.Search(nameSearch);

            var idSearch = new IdSeach(123);
            inv.Search(idSearch);
        }
    }


    class Guitar
    {
        string name;
        int id;
    }

    class Inventory
    {
        Dictionary<string, Guitar> guitars = new Dictionary<string, Guitar>();
        List<Guitar> guitarsArr = new List<Guitar>();
        public void Add(Guitar guitar)
        {

        }

        public bool Remove(Guitar guitar)
        {
            return true;
        }

        public List<Guitar> Search(ISearch search)
        {
            return search.Search(guitarsArr);
        }

        public List<Guitar> Search(string name)
        {
            return new List<Guitar>();
        }
    }

    interface ISearch
    {
        List<Guitar> Search(List<Guitar> items);
    }

    class NameSeach : ISearch
    {
        public NameSeach(string seachName)
        {

        }

        public List<Guitar> Search(List<Guitar> items)
        {
            return items;
        }
    }

    class IdSeach : ISearch
    {
        public IdSeach(int id)
        {

        }

        public List<Guitar> Search(List<Guitar> items)
        {
            return items;
        }
    }
}
