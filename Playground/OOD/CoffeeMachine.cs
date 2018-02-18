using System;
using System.Collections.Generic;

namespace Playground.OOD
{
#pragma warning disable CS0169, CS0649, CS0414

    // Command design patter with Factory

    public class CoffeeMachine
    {
        Transaction current;
        MachineResources resources = new MachineResources();

        public List<Entity> GetAvailableResources()
        {
            return new List<Entity>();
        }

        public void StartTransaction(Entity entityToPrepare)
        {
            if (current != null)
            {
                throw new ApplicationException("Transaction in process");
            }

            current = new Transaction();
            current.StateChanged += Current_StateChanged;       
        }

        private void Current_StateChanged(TransactionState state)
        {
            if(state == TransactionState.Cooking)
            {
                // do something
            }
            else if (state == TransactionState.Finish)
            {
                // update resources
            }
        }

        public void Rollback()
        {
            if (current == null)
            {
                throw new ApplicationException("No transaction");
            }

            int returnMoney = current.CurrentMoney;
        }
    }

    public class Transaction
    {
        public int CurrentMoney;
        public Entity entryToPrepare;
        TransactionState state;

        public delegate void TransactionEventRaiser(TransactionState state);
        public event TransactionEventRaiser StateChanged;

        public void AddMoney(int money)
        {
            CurrentMoney += money;
            if(CurrentMoney > entryToPrepare.GetPrice())
            {                
                state = TransactionState.Cooking;
                StateChanged?.Invoke(state);
            }
        }
    }

    public enum TransactionState
    {
        Init,
        MoneyInComplete,
        Cooking,
        Rollback,
        Finish
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
