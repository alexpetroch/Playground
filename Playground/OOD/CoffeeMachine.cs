using System;
using System.Collections.Generic;

namespace Playground.OOD
{
#pragma warning disable CS0169, CS0649, CS0414

    // State pattern
    // Ready state -> Select drink -> Add money -> Prepare Drink and return additional money -> Update machine resources -> Ready state
    //             <-              <- Rollback   

    public interface IState
    {
        void SelectDrink();

        void AddMoney(int count);

        void ReturnMoney();
    }

    public interface ICoffeeMachine
    {
        void SetState(IState state);
        IConsoleMenu ConsoleMenu { get;  }

        Entity SelectedEntity { get; set; }
    }

    public interface IConsoleMenu
    {
        Entity ReadEntity();
    }

    public class CoffeeMachine : ICoffeeMachine
    {
        MachineResources resources = new MachineResources();
        IState _state = null;

        private IConsoleMenu _consoleMenu = new SimpleConsoleMenu();

        public CoffeeMachine()
        {
            _state = new ReadyState(this);
        }

        public IConsoleMenu ConsoleMenu
        {
            get
            {
                return _consoleMenu;
            }
        }

        private Entity _selectedEntity;
        public Entity SelectedEntity
        {
            get { return _selectedEntity; }
            set { _selectedEntity = value; }
        }


        public List<Entity> GetAvailableResources()
        {
            return new List<Entity>();
        }

        public void AddMoney(int money)
        {
            _state.AddMoney(money);
        }

        public void ReturnMoney()
        {
            _state.ReturnMoney();
        }

        public void SelectDrink()
        {
            SelectedEntity = ConsoleMenu.ReadEntity();
            _state.SelectDrink();
        }

        public void SetState(IState state)
        {
            _state = state;
        }
    }

    public class SimpleConsoleMenu : IConsoleMenu
    {
        public Entity ReadEntity()
        {
            // let use coffee just as default
            return new Capuchino(new Coffee());
        }
    }

    public class ReadyState : IState
    {
        private ICoffeeMachine _coffeeMachine;

        public ReadyState(ICoffeeMachine coffeeMachine)
        {
            _coffeeMachine = coffeeMachine;
        }

        public void AddMoney(int count)
        {
            throw new InvalidOperationException("Please select drink");
        }

        public void ReturnMoney()
        {
            throw new InvalidOperationException("Please select drink");
        }

        public void SelectDrink()
        {
            _coffeeMachine.SetState(new AddMoneyState(_coffeeMachine));
        }
    }

    public class AddMoneyState : IState
    {
        public ICoffeeMachine _coffeeMachine;

        public AddMoneyState(ICoffeeMachine coffeeMachine)
        {
            _coffeeMachine = coffeeMachine;
        }

        private int _money = 0;

        public void AddMoney(int count)
        {
            _money += count;
            if(_money > _coffeeMachine.SelectedEntity.GetPrice())
            {
                _coffeeMachine.SetState(new ReadyState(_coffeeMachine));
            }
        }

        public void ReturnMoney()
        {
            throw new InvalidOperationException("Please select drink");
        }

        public void SelectDrink()
        {
            throw new InvalidOperationException("Entity has been selected");
        }
    }

    public class MachineResources
    {
        public int Water;
        public int Sugar;
        public int Milk;
        private List<Entity> _entities;

        public void InitEntities (List<Entity> entity)
        {
            // init 
            _entities = entity;
        }
        public void AddEntity() { }
        public void RemoveEntity() { }
        public bool CheckResources (Entity entity)
        {
            //return entity.Check();
            return true;
        }
    }
    
    public interface Entity
    {
        double GetPrice();
    }

    public class Coffee : Entity
    {
        public double GetPrice()
        {
            return 10;
        }
    }

    public class Capuchino : Entity
    {
        Entity _entiry;
        public Capuchino (Entity entiry)
        {
            _entiry = entiry;
        }
        public double GetPrice()
        {
            return _entiry.GetPrice() * 1.1;
        }
    }
}
