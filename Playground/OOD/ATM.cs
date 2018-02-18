namespace Playground.OOD
{
    /*
    Use cases:
    - Insert/Return Card
    - Take/Put money

    Non-functional requirements:
    - Can't insert/handle another card before previous is not returned
    - Can't return more money than ATM has
    
     CRC cards:
     User insert card into card reader of ATM, ATM open dialog and user enter pin. 
     ATM communicate with bank and check Pin. ATMConsole read user request and make transtaction

    Classes:
    ATM  User  Session  CarReader  CachManager  Transaction  Withdraw  Deposit  Bank  Receipt
    */

   #pragma warning disable CS0169, CS0649

    class UseCaseATM
    {
        public void Start()
        {
            ATM atm = new ATM();
            atm.Run();
        }
    }

    class ATM
    {
        enum State
        {
            PowerOn,
            UserSession,
            PowerOff
        }

        private State state;
        private CachManager cashManager = new CachManager();
        private CardReader cardReader = new CardReader();

        public void Run ()
        {
            while(true)
            {
                switch(state)
                {
                    case State.PowerOff:
                        // close everthing 
                        return;
                    case State.UserSession:
                        // if no active session
                        cardReader.Read();
                        break;
                    case State.PowerOn:
                        cashManager.Recalculate();
                        break;
                }
            }
        }
             
    }

    class CardReader
    {
        public void Read() { }
    }

    class ATMConsole
    {
        public void ReadOperation()
        {
            // create Transaction here

        }
    }

    class CachManager
    {
        int count;

        public void Recalculate()
        {
            count = 1000;
        }

        private bool CanGiveMoney(int sum)
        {
            return true;
        }

        public void Take(int sum)
        {
            if(!CanGiveMoney(sum))
            {
                throw new System.Exception();
            }

            count -= sum;
        }

        public void Add(int sum)
        {
            count += sum;
        }
    }

    abstract class ATMTransaction { }
    
    class Withdraw : ATMTransaction
    { }

    class Deposit : ATMTransaction
    { }

    class Session { }

}
