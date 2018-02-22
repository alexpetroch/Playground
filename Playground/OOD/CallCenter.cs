using System;
using System.Collections.Generic;

#pragma warning disable CS0169, CS0649

namespace Playground.OOD
{

    /*
     Command pattern: Declare interface with execute method. Create concreate command and pass instances to real object
     ICommand -> ConcreateCommand(someInstance) -> concreateCommand.execute() {someInsatnce.DoSomething ()}
         
    */

    public class CallCenter
    {
        public List<Employee> avalEmpl = new List<Employee>();
        public Queue<Employee> free = new Queue<Employee>();

        public CallCenter(List<Employee> emp)
        {
            avalEmpl = emp;
            for(int i = 0; i < emp.Count; i++)
            {
                free.Enqueue(emp[i]);
            }
        }

        public void TakeCall (Call call)
        {
            // get person based on escalation priority
            // assign to call
            Random random = new Random();
            var employeeToHandle = avalEmpl[random.Next(avalEmpl.Count - 1)];
            while(employeeToHandle != null && employeeToHandle.OnCall)
            {
                employeeToHandle = employeeToHandle.Boss;
            }

            MakeCallCommand command = new MakeCallCommand(call, employeeToHandle);
            command.Execute();
        }

        public void DispatchCall(Call call)
        {
            var employeeToHandle = free.Dequeue();
            MakeCallCommand command = new MakeCallCommand(call, employeeToHandle);
            command.Execute();            
        }

        public void FinishCall(Call call)
        {
            // store additional information and close the call
            FinishCallCommand command = new FinishCallCommand(call);
            command.Execute();
            free.Enqueue(call.HandlingPerson);           
        }
    }

    interface ICommand
    {
        void Execute();
    }

    class MakeCallCommand : ICommand
    {
        private Call _call;
        private Employee _employer;
        public MakeCallCommand(Call call, Employee employer)
        {
            _call = call;
            _employer = employer;
        }
        public void Execute()
        {       
            _call.AssignTo(_employer);
        }
    }

    class FinishCallCommand : ICommand
    {
        private Call _call;
        private Employee _employer;
        public FinishCallCommand(Call call)
        {
            _call = call;
        }
        public void Execute()
        {
            _call.Finish();
        }
    }

    public class Employee
    {
        public string Name;
        public Employee Boss;
        public List<Employee> Subordinates;

        public Employee (string name, Employee boss)
        {
            Name = name;
            Boss = boss;
            Subordinates = new List<Employee>();
        }

        public void AddSubordinater(Employee employee)
        {
            Subordinates.Add(employee);
        }

        public bool OnCall;
    }

    public class Respondent : Employee
    {
        public Respondent(string name, Employee boss) : base(name, boss)
        {
        }
    }

    public class Manager : Employee
    {
        public Manager(string name, Employee boss) : base(name, boss)
        {
        }
    }

    public class Director : Employee
    {
        public Director(string name) : base(name, null)
        {
        }
    }

    public class Call
    {
        private Employee _handlingPerson;
        public Employee HandlingPerson => _handlingPerson;
        public DateTime StartDate;
        public bool IsActive;

        public void AssignTo(Employee handler)
        {
            _handlingPerson = handler;
            _handlingPerson.OnCall = true;
        }

        public void Finish()
        {
            _handlingPerson.OnCall = false;
        }
    }
}
