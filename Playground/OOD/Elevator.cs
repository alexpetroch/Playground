using System;
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
    - Each floor has button which fire request to get elevator
    - Each elevator has a set of buttons which can be turn on to assign elevator to specific floor
        
     Elephator      Floor     ElevatorSystem    FloorButton
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
            List<Elevator> elevators = new List<Elevator>();
            elevators.Add(new Elevator());
            elevators.Add(new Elevator());

            List<FloorButton> buttons = new List<FloorButton>();
            buttons.Add(new FloorButton(new Floor(1)));

            ElevatorSystem elevatorSystem = new ElevatorSystem(elevators, buttons);
            
        }
    }

    class ElevatorSystem
    {
        Queue<Elevator> freeElevators = new Queue<Elevator>();
        List<Elevator> elevators = new List<Elevator>();

        public ElevatorSystem(List<Elevator> elevators, List<FloorButton> floorButtons )
        {
            // init
            if(floorButtons != null)
            {
                foreach(FloorButton florButton in  floorButtons)
                {
                    florButton.OnNewRequest += FlorButton_OnNewRequest;
                }
            }

        }

        private void FlorButton_OnNewRequest(object sender, Request e)
        {
            if(freeElevators.Count > 0)
            {
                Elevator elevator = freeElevators.Dequeue();
                elevator.GoToFloor(e.Floor);
            }
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

        // User press button or Elevator system assign floor to elevator
        public void GoToFloor(Floor floor)
        {
            if(CurrentFloor.Number < floor.Number)
            {
                elevatorState = State.Up;
            }

            else if (CurrentFloor.Number > floor.Number)
            {
                elevatorState = State.Down;
            }
        }
    }

    class Floor
    {
        public Floor(int number)
        {
            Number = number;
        }

        public int Number;
    }

    class FloorButton
    {

        public event EventHandler<Request> OnNewRequest;
        private Floor _floor;

        public FloorButton(Floor floor)
        {
            _floor = floor;
        }

        public void Push()
        {
            var newReq = OnNewRequest;
            if (newReq != null)
            {
                newReq(this, new Request(_floor));
            }
        }

    }

    class Request
    {
        public Request(Floor floor)
        {
            Floor = floor;
        }

        public Floor Floor;
    }   


}
