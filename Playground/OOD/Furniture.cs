using System.Collections.Generic;

namespace Playground.OOD
{  
    abstract class FurnitureMaterial : FurnitureTest
    {
        public abstract string Name
        {
            get;
        }

        public abstract bool FireTest();

        public abstract bool StressTest();
    }

    abstract class FurnitureDetail : FurnitureTest
    {
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
        public abstract string Name
        {
            get;
        }

        public abstract bool FireTest();

        public abstract bool StressTest();
    }

    class Char : FurnitureDetail
    {
        public Char(FurnitureMaterial material) : base(material)
        {
        }

        public override string Name { get => "Char"; }

        public override bool FireTest() => Material.FireTest();

        public override bool StressTest() => Material.StressTest();
    }    

    class Table : FurnitureDetail
    {
        public Table(FurnitureMaterial material) : base(material)
        {
        }

        public override string Name { get => "Table"; }

        public override bool FireTest() => Material.FireTest();

        public override bool StressTest() => Material.StressTest();
    }

    class Wooden : FurnitureMaterial
    {
        public override string Name => "Wooden";

        public override bool FireTest()
        {
            return true;
        }

        public override bool StressTest()
        {
            return true;
        }
    }

    class Metal : FurnitureMaterial
    {
        public override string Name => "MetalChar";

        public override bool FireTest()
        {
            return true;
        }

        public override bool StressTest()
        {
            return true;
        }
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

        public override bool FireTest()
        {
            foreach (var detail in _details)
            {
                detail.FireTest();
            }

            return false;
        }

        public override bool StressTest()
        {
            foreach (var detail in _details)
            {
                detail.StressTest();
            }

            return true;
        }
    }

    interface FurnitureTest
    {
        bool StressTest();

        bool FireTest();
    }


}
