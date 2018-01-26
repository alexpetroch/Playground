using System.Collections.Generic;

namespace Playground.OOD
{  
    interface IFireTest
    {
        bool FireTest();
    }

    class WoodenFireTest : IFireTest
    {
        public bool FireTest()
        {
            return false;
        }
    }

    class MetalFireTest : IFireTest
    {
        public bool FireTest()
        {
            return false;
        }
    }

    class CharFireTest : IFireTest
    {
        public bool FireTest()
        {
            return false;
        }
    }

    interface IStressTest
    {
        bool StressTest();
    }

    class WoodenStressTest : IStressTest
    {
        public bool StressTest()
        {
            return false;
        }
    }

    class MetalStressTest : IStressTest
    {
        public bool StressTest()
        {
            return false;
        }
    }

    class CharStressTest : IStressTest
    {
        public bool StressTest()
        {
            return false;
        }
    }   


    abstract class FurnitureMaterial
    {
        protected IStressTest _stressTest;
        protected IFireTest _fireTest;
        public FurnitureMaterial()
        {
        }

        public abstract string Name
        {
            get;
        }

        public virtual bool PerformFireTest()
        {
            if(_fireTest != null)
            {
                return _fireTest.FireTest();
            }

            return true;            
        }

        public virtual bool PerformStressTest()
        {
            if (_stressTest != null)
            {
                return _stressTest.StressTest();
            }

            return true;
        }
    }

    abstract class FurnitureDetail 
    {
        protected IStressTest _stressTest;
        protected IFireTest _fireTest;

        private FurnitureMaterial _material;
        public FurnitureMaterial Material
        {
            get
            {
                return _material;
            }
        }
        public FurnitureDetail(FurnitureMaterial material)
        {
            _material = material;
        }

        protected FurnitureDetail()
        {
        }

        public abstract string Name
        {
            get;
        }

        public virtual bool PerformFireTest()
        {
            return _material.PerformFireTest() && _fireTest.FireTest();           
        }

        public virtual bool PerformStressTest()
        {
            return _material.PerformStressTest() && _stressTest.StressTest();
        }
    }

    abstract class FurnitureDecorator : FurnitureDetail
    {
        FurnitureDetail _detail;
        public FurnitureDecorator(FurnitureDetail detail)
        {
            _detail = detail;
        }

        public override string Name { get => "Name" + _detail.Name; }
    }

    class Char : FurnitureDetail
    {

        public Char(FurnitureMaterial material) : base(material)
        {
            _fireTest = new CharFireTest();
            _stressTest = new CharStressTest();
        }

        public override string Name { get => "Char"; }       
    }    

    class Table : FurnitureDetail
    {
        public Table(FurnitureMaterial material) : base(material)
        {
        }

        public override string Name { get => "Table"; }
    }   

    class Wooden : FurnitureMaterial
    {
        public Wooden() 
        {
            _fireTest = new WoodenFireTest();
            _stressTest = new WoodenStressTest();
        }

        public override string Name => "Wooden";    
        
    }

    class Metal : FurnitureMaterial
    {
        public Metal()
        {
            _fireTest = new MetalFireTest();
            _stressTest = new MetalStressTest();
        }

        public override string Name => "MetalChar";
       
    }

    class FurnitureComposite : FurnitureDetail
    {
        public FurnitureComposite(FurnitureMaterial material) : base(material)
        {
        }

        public override string Name => "FurnitureComposite";

        private List<FurnitureDetail> _details = new List<FurnitureDetail>();

        public void Add (FurnitureDetail detail)
        {
            _details.Add(detail);
        }

        public override bool PerformFireTest()
        {
            foreach (var detail in _details)
            {
                detail.PerformFireTest();
            }

            return false;
        }

        public override bool PerformStressTest()
        {
            foreach (var detail in _details)
            {
                detail.PerformStressTest();
            }

            return true;
        }
    }
}
