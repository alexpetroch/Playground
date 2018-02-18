using System.Collections.Generic;

namespace Playground.OOD
{
#pragma warning disable CS0169, CS0649, CS0414

    /*
    Use cases:
    - Elevator can move from one floor to the other one
    - Elevator can idle, repair, down and up, do open, close states
    - There is algorithm which define what elevator should go to each floor
    - There is a queue of waiting floor to stop
    - ElevatorSystem put floor into waiting state
        
     Elephator      Floor     ElevatorSystem    (?? Algo to go ??)
     State          Number    has Elephators          
     FindNextStop             init floors 
     - own queue

    Rules:
        - If elevator is idle -> pick the nearest elevator and assign to floor
        - if no elevators -> puck the elevator in the same direction
    
    */

    class ElevatorUnitTest
    {
        public void Start()
        {
            ElevatorSystem elevatorSystem = new ElevatorSystem(10, 2);
            
        }
    }

    class ElevatorSystem
    {
        List<Elevator> elevators = new List<Elevator>();

        public ElevatorSystem(int floors, int elevators)
        {
            // init
        }

        public void AddForStop(Floor floor)
        {

        }

        public void FloorHandle(Floor floor)
        {

        }
    }

    class Elevator
    {
        enum State
        {
            Up,
            Down,
            Idle,
            DoorOpen,
            DoorClose
        }

        State elevatorState;

        public Floor CurrentFloor;

        public void Start()
        {
            while(true)
            {
                switch(elevatorState)
                {
                    case State.Idle:
                        // wait for notification;
                        break;
                }
            }
        }
    }

    class Floor
    {
        int number;
    }
}
