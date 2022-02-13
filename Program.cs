using System;
using System.Collections.Generic;

namespace DesignPatterns
{

    /******* MainApp class *******/
    #region MainApp
    /// <summary>
    /// MainApp startup class for Structural
    /// Builder Design Pattern.
    /// </summary>
    public class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            /******* Section 1: Builder Design Pattern *******/
            //Create director and builders
            Console.WriteLine("\n******* Section 1: Builder Design Pattern ******");
            Director director = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();
            // Construct two products
            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();
            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();
            /******* End of section 1: Builder Design Pattern *******/


            /******* Section 2: Factory Method Design Pattern *******/
            Console.WriteLine("\n******* Section 2: Factory Method Design Pattern ******");
            // An array of creators
            Creator[] creators = new Creator[2];
            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();
            // Iterate over creators and create products
            foreach (Creator creator in creators)
            {
                FactoryProduct product = creator.FactoryMethod();
                Console.WriteLine("\nCreated {0}",
                  product.GetType().Name);
            }
            /******* End of section 2: Director and builders *******/


            /******* Section 3: Facade Design Pattern *******/
            Console.WriteLine("\n******* Section 3: Facade Design Pattern ******");
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();
            /******* End of section 3: Facade Design Pattern *******/


            /******* Section 4: Iterator Design Pattern *******/
            Console.WriteLine("\n******* Section 4: Iterator Design Pattern ******");
            // Build a collection
            Collection collection = new Collection();
            collection[0] = new Item("Item 0");
            collection[1] = new Item("Item 1");
            collection[2] = new Item("Item 2");
            collection[3] = new Item("Item 3");
            collection[4] = new Item("Item 4");
            collection[5] = new Item("Item 5");
            collection[6] = new Item("Item 6");
            collection[7] = new Item("Item 7");
            collection[8] = new Item("Item 8");
            // Create iterator
            Iterator iterator = collection.CreateIterator();
            // Skip every other item
            iterator.Step = 2;
            Console.WriteLine("\nIterating over collection:");
            for (Item item = iterator.First();
                !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(item.Name);
            }
            /******* End of section 4: Iterator Design Pattern *******/


            /******* Section 5: Constructor DI *******/
            Console.WriteLine("\n******* Section 5: Constructor DI ******");
            Dependency dependency1 = new Dependency();
            Client1 client1 = new Client1(dependency1);
            // Now do some work with client1
            client1.UseTheDependency();

            IDependency dependency2 = new Dependency();
            Client2 client2 = new Client2(dependency2);
            // Now do some work with client2
            client2.UseTheDependency();
            /******* End of section 5: Constructor DI *******/


            // Wait for user
            Console.ReadKey();
        }
    }
    #endregion
    /******* End of MainApp class *******/

    /******* Section 1: Builder Design Pattern *******/
    #region Section1
    /// <summary>
    /// The 'Director' class
    /// </summary>
    class Director
    {
        // Builder uses a complex series of steps
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }
    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }
    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    class ConcreteBuilder1 : Builder
    {
        private Product _product = new Product();
        public override void BuildPartA()
        {
            _product.Add("PartA");
        }
        public override void BuildPartB()
        {
            _product.Add("PartB");
        }
        public override Product GetResult()
        {
            return _product;
        }
    }
    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    class ConcreteBuilder2 : Builder
    {
        private Product _product = new Product();
        public override void BuildPartA()
        {
            _product.Add("PartX");
        }
        public override void BuildPartB()
        {
            _product.Add("PartY");
        }
        public override Product GetResult()
        {
            return _product;
        }
    }
    /// <summary>
    /// The 'Product' class
    /// </summary>
    class Product
    {
        private List<string> _parts = new List<string>();
        public void Add(string part)
        {
            _parts.Add(part);
        }
        public void Show()
        {
            Console.WriteLine("\nProduct Parts -------");
            foreach (string part in _parts)
                Console.WriteLine(part);
        }
    }

    #endregion
    /******* End of section 1: Director and builders *******/

    /******* Section 2: Factory Method Design Pattern *******/
    #region Section2
    /// <summary>
    /// The 'Product' abstract class
    /// </summary>
    abstract class FactoryProduct
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ConcreteProductA : FactoryProduct
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ConcreteProductB : FactoryProduct
    {
    }
    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    abstract class Creator
    {
        public abstract FactoryProduct FactoryMethod();
    }
    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class ConcreteCreatorA : Creator
    {
        public override FactoryProduct FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }
    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class ConcreteCreatorB : Creator
    {
        public override FactoryProduct FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }

    #endregion
    /******* End of section 2: Director and builders *******/

    /******* Section 3: Facade Design Pattern *******/
    #region Section3
    /// <summary>
    /// The 'Subsystem ClassA' class
    /// </summary>
    public class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine(" SubSystemOne Method");
        }
    }
    /// <summary>
    /// The 'Subsystem ClassB' class
    /// </summary>
    public class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine(" SubSystemTwo Method");
        }
    }
    /// <summary>
    /// The 'Subsystem ClassC' class
    /// </summary>
    public class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine(" SubSystemThree Method");
        }
    }
    /// <summary>
    /// The 'Subsystem ClassD' class
    /// </summary>
    public class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine(" SubSystemFour Method");
        }
    }
    /// <summary>
    /// The 'Facade' class
    /// </summary>
    public class Facade
    {
        SubSystemOne one;
        SubSystemTwo two;
        SubSystemThree three;
        SubSystemFour four;
        public Facade()
        {
            one = new SubSystemOne();
            two = new SubSystemTwo();
            three = new SubSystemThree();
            four = new SubSystemFour();
        }
        public void MethodA()
        {
            Console.WriteLine("\nMethodA() ---- ");
            one.MethodOne();
            two.MethodTwo();
            four.MethodFour();
        }
        public void MethodB()
        {
            Console.WriteLine("\nMethodB() ---- ");
            two.MethodTwo();
            three.MethodThree();
        }
    }

    #endregion
    /******* End of section 3: Facade Design Pattern *******/
    
    /******* Section 4: Iterator Design Pattern *******/
    #region Section4
    /// <summary>
    /// A collection item
    /// </summary>
    public class Item
    {
        string name;
        // Constructor
        public Item(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
        }
    }
    /// <summary>
    /// The 'Aggregate' interface
    /// </summary>
    public interface IAbstractCollection
    {
        Iterator CreateIterator();
    }
    /// <summary>
    /// The 'ConcreteAggregate' class
    /// </summary>
    public class Collection : IAbstractCollection
    {
        List<Item> items = new List<Item>();
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }
        // Gets item count
        public int Count
        {
            get { return items.Count; }
        }
        // Indexer
        public Item this[int index]
        {
            get { return items[index]; }
            set { items.Add(value); }
        }
    }
    /// <summary>
    /// The 'Iterator' interface
    /// </summary>
    public interface IAbstractIterator
    {
        Item First();
        Item Next();
        bool IsDone { get; }
        Item CurrentItem { get; }
    }
    /// <summary>
    /// The 'ConcreteIterator' class
    /// </summary>
    public class Iterator : IAbstractIterator
    {
        Collection collection;
        int current = 0;
        int step = 1;
        // Constructor
        public Iterator(Collection collection)
        {
            this.collection = collection;
        }
        // Gets first item
        public Item First()
        {
            current = 0;
            return collection[current] as Item;
        }
        // Gets next item
        public Item Next()
        {
            current += step;
            if (!IsDone)
                return collection[current] as Item;
            else
                return null;
        }
        // Gets or sets stepsize
        public int Step
        {
            get { return step; }
            set { step = value; }
        }
        // Gets current iterator item
        public Item CurrentItem
        {
            get { return collection[current] as Item; }
        }
        // Gets whether iteration is complete
        public bool IsDone
        {
            get { return current >= collection.Count; }
        }
    }
    #endregion
    /******* End of section 4: Iterator Design Pattern *******/

    /******* Section 5: Constructor DI *******/
    #region Section5

    /// <summary>
    /// Constructor injection example interface
    /// </summary>
    public interface IDependency
    {
        public void SomeMethod(String msg);
    }

    /// <summary>
    /// Constructor injection example dependency class that implements the interface
    /// </summary>
    public class Dependency : IDependency
    {
        public void SomeMethod(String msg)
        {
            Console.WriteLine("\nHi, I am SomeMethod() in " + msg);

        }
    }
    /// <summary>
    /// Constructor injection example client class WITH dependency
    /// </summary>
    public class Client1
    {
        private Dependency _dependency;
        public Client1(Dependency dependency)
        {
            _dependency = dependency;
        }

        public void UseTheDependency()
        {
            _dependency.SomeMethod("Client1");
        }
    }

    /// <summary>
    /// Constructor injection example client class WITHOUT dependency
    /// </summary>
    public class Client2
    {
        private IDependency _Idependency;
        public Client2(IDependency Idependency)
        {
            _Idependency = Idependency;
        }
        public void UseTheDependency()
        {
            _Idependency.SomeMethod("Client2");
        }
    }

    #endregion
    /******* End of section 5: Constructor DI *******/

}
