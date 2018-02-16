namespace Playground.OOD
{
    /*
    Use cases:
    - Insert/Return Card
    - Take/Put money

    Non-functional requirements:
    - Can't insert/handle another card before previous is not returned
    - Can't return more money than ATM has
         
    */

    class ATM
    {
        Card activeCard;

        public void InsertCard(Card card)
        {
            if(activeCard != null)
            {
                card.Autorize(111);
                activeCard = card;
            }
        }

        public void ReturnCard()
        {
            activeCard = null;
        }
    }

    class Card
    {
        public void Autorize(int pin) { }

        public void TakeMoney() { }
        public void PutMoney() { }
    }

    class CachManager
    {
        int count;

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
}
