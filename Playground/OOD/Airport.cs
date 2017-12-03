using System;
using System.Collections.Generic;

#pragma warning disable CS0169, CS0649

namespace Playground.OOD
{
    class Airport
    {
        private LandingController controller;
    }

    // Weather conditions,  monitoring
    class LandingController
    {
        List<Terminal> terminals;
        Dictionary<Aircraft, Terminal> slots;

        LandingRequest AskForLanding(Aircraft aircraft)
        {
            // could be runaway is free, or put in queue -> no runaway
            Terminal termnal = slots[aircraft];
            termnal.ScheduleLanding(aircraft);
            return new LandingRequest();
        }

        LandingRequest CheckLandingRequestStatus(LandingRequest request)
        {
            // check and update request
            return request;
        }  
    }

    class LandingRequest
    {
        State state;
        Aircraft aircraft;
        public RunAway runAway;
        public int id;
        DateTime date;
    }

    class Terminal
    {
        List<RunAway> allRunAway;
        Stack<RunAway> freeForSmall = new Stack<RunAway>();
        Stack<RunAway> freeForLarge = new Stack<RunAway>();

        internal LandingRequest ScheduleLanding(Aircraft aircraft)
        {
            // check aircraft and detect appropriate runaway (detection should not be in this class)
            var runAway = freeForLarge.Pop();

            // if not free put into priority queue

            return new LandingRequest();
        }

        internal void AirCraftLeave(LandingRequest request)
        {
            // check aircraft and detect appropriate runaway (detection should not be in this class)
            freeForLarge.Push(request.runAway);
        }
    }

    class RunAway
    {

    }

    class Aircraft
    {

    }

    enum State
    {
        Queued,
        Booked,
        Closed
    }
}
