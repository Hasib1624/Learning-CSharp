using System;

// Naming Convention: Interface name is prefixed by 'I' (eg, IOne,ITwo..)
public interface IOne
{
    // interface CAN'T have access modifier. all ar PUBLIC by default
    void OneMethod();
    // no function body is allowed. Implementaion provided by derived class
}
public interface ITwo
{
    void TwoMethod();
}

// Naming Convention: class Name PascelCase (eg, Base,Complex,Person...)
public class Base
{
    public Base()
    {
        Console.WriteLine("Base Constructor");
    }
    
    public void NonVirtualDemo()
    {
        Console.WriteLine("In Base.NonVirtualDemo");
    }
    
    public virtual void VirtualDemo()
    {
        Console.WriteLine("In Base.VirtualDemo");
    }
}


// NOTE: any class can only derive from ONE base class (no multiple base class like C++)
//       but class can derive from MORE than one Interfaces sperated by comma
public class Derived : Base, IOne, ITwo
{
    // You can call Base constructor before going into Derived constructor
    // base keyword refers to the base object
    // this - current object
    // base - base object
    public Derived() : base()
    {
        Console.WriteLine("Derived Constructor");
    }
    
    // this generates a warning
    // Derived.NonVirtualDemo() hides inherited member Base.NonVirtualDemo().Use the new keyword if hiding was intended
    // public void NonVirtualDemo()
    // {
    //     Console.WriteLine("In Base.NonVirtualDemo");
    // }
    
    // as the previous commneted demo suggests, new is used to hide Derived.NonVirtualDemo()
    public new void NonVirtualDemo()
    {
        Console.WriteLine("In Base.NonVirtualDemo");
    }
    // Look at the Main Function to see the effect on Dynamic Polymorphism
    
    // if you want to override a virtual funftion add virtual keyword otherwise
    // Dynamic Polymorphism can't be achived. BTW compiler also warns about this.
    public override void VirtualDemo()
    {
        Console.WriteLine("----In Derived.VirtualDemo----");
        
        Console.WriteLine("Calling Base.VirtualDemo");
        
        // NOTE: You call call the any base class function with base ketword
        //       this - current object
        //       base - base object
        base.VirtualDemo();
        
        Console.WriteLine("------------------------------");
    }
    
    // must implement Interface Methods
    // IOne
    public void OneMethod()
    {
        Console.WriteLine("In Derived.OneMethod");
    }
    // ITwo
    public void TwoMethod()
    {
        
    }
}


public abstract class AbstractBase
{
    // NOTE: virtual methods can present in both normal and abstract class 
    public virtual void AbstractVirtual()
    {
        Console.WriteLine("In AbstractBase.AbstractVirtual");
    }
    
    // abstract methods can't have a body
    // derived class must override this. otherwise the derived class must also be marked abstract
    public abstract void AbstractMethod();
}

public class DerivedFromAbstract : AbstractBase
{
    // overriding virtual method is NOT mendetory
    
    // overriding abstract method is MENDETORY
    public override void AbstractMethod()
    {
        Console.WriteLine("In DerivedFromAbstract.AbstractMethod");
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Base baseObj = new Base();
        baseObj.NonVirtualDemo();
        
        // Don't get panicked seeing this. Base class reference get hold Derives class object
        // because, Derived class is Base class and more
        Base derivedObj = new Derived();
        derivedObj.NonVirtualDemo();
        // Notice: As this is non-virtual method and new is used to override
        //         eventhough derivedObj is of Derived class the function call
        //         invokes Base method! So, this does not achieve Runtime Polymorphism.
        
        // virtual method in Base class, override in Derived class
        // this invokes the correct version of the overriden function.
        // Finally we have achieved Runtime Polymorphism or Dynamic Method Dispatch
        derivedObj.VirtualDemo();
        
        // interface object can't be created
        // IOne iOneObj = new IOne(); This is NOT possibile
        // but this is fine to have reference Derived object for the same reason
        // Derived class is Base class and more
        IOne iOneDerivedObj = new Derived();
        // as interface has the the info of IOne. Only IOne methods are accessible even though Obj is Derived class 
        // iOneDerivedObj.VirtualDemo(); This is NOT possibile
        iOneDerivedObj.OneMethod(); // this is allowed ad it accesses the IOne method
        
        // abstract class object can't be created
        // AbstractBase ab = new AbstractBase(); This is NOT possibile
        // but this is fine to have reference Derived object for the same reason
        // Derived class is Base class and more
        AbstractBase obj = new DerivedFromAbstract();
        // virtual method is called
        obj.AbstractVirtual();
        // abstract method is called
        obj.AbstractMethod();
    }
}