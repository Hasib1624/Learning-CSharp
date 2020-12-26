using System;

/* This displays how to write a class in C# with an example Complex Number class 
 * This module covers, 
   - Getter Setter - Constructor
   - Static Method - Override Method
   - Operator Overloding
 * Naming Convention in C#
   - PascelCase for class,method,properties (member variable) names
   - camelCase  for other variables 
 */
 
public class Complex
{
    public double Re { get; set; }
    public double Im { get; set; }
    
    public Complex(double re = 0,double im = 0)
    {
        Re = re;
        Im = im;
    }
    
    // after :(colon) this is invoked the other constructor 
    // before going to function body
    public Complex(Complex c) : this(c.Re,c.Im)
    {
        
    }
    
    // Modulus of Complex Number
    public double Mod()
    {
        return Math.Sqrt(Re*Re + Im*Im);
    }
    
    // Principal Argument of Complex Number
    public double Arg()
    {
        if(Im == .0)
            return (Re >= .0) ? 0 : (Math.PI);
        if(Re == .0)
            return (Im > .0) ? (Math.PI/2) : (-Math.PI/2);
        // Quadrant 1
        if(Re > .0 && Im > 0)
            return  Math.Atan2(Im,Re);
        // Quadrant2
        if(Re < .0 && Im > 0)
            return  Math.PI - Math.Atan2(Im,-Re);
        // Quadrant 3
        if(Re < .0 && Im < 0)
            return -Math.PI + Math.Atan2(-Im,-Re);
        // Quadrant 4
        return     -Math.Atan2(-Im,Re);
    }
    
    // Conjugate of Complex Number
    public Complex Conj()
    {
        return new Complex(
             Re,
            -Im
        );
    }
    
    // override Object.ToString() as all class by default derived from Object
    // every class gets Object's methods and properties
    public override string ToString()
    {
        if(Im == .0) // smaple: 3
            return Re.ToString();
        string output = "";
        if(Re != .0)
            output = $"{Re}";
        if(Im < 0) // smaple: -3i
            output += $"-{-Im}i";
        else if(Re == .0) // smaple: 3i
            output += $"{Im}i";
        else // smaple: 3+4i
            output += $"+{Im}i";
        return output;
    }
    
    // this static method belongs to the Class and allows user to create
    // Complex number from polar form.
    public static Complex FromPolar(double r = .0,double theta = .0)
    {
        // Mathematical Explanation: Euler Formula
        // r*e^(i*theta) = r(cos(theta) + i sin(theta))
        return new Complex(
            r * Math.Cos(theta),
            r * Math.Sin(theta)
        );
    }
    
    // Operator Overloading
    // unlike C++, C# needs all overloaded operator to be static
    // thats why ++,--,+=,-=,*= etc can't be oveloaded
    public static Complex operator+(Complex c1,Complex c2)
    {
        return new Complex(
            c1.Re + c2.Re,
            c1.Im + c2.Im
        );
    }
    
    // unary- 
    public static Complex operator-(Complex c)
    {
        return new Complex(
            -c.Re,
            -c.Im
        );
    }
    
    // binary -
    public static Complex operator-(Complex c1,Complex c2)
    {
        return new Complex(
            c1.Re - c2.Re,
            c1.Im - c2.Im
        );
    }
    
    public static Complex operator*(Complex c1,Complex c2)
    {
        return new Complex(
            c1.Re*c2.Re - c1.Im*c2.Im,
            c1.Re*c2.Im + c1.Im*c2.Re
        );
    }
    
    public static Complex operator*(Complex c,double r)
    {
        return new Complex(
            c.Re*r,
            c.Im*r
        );
    }
    
    public static Complex operator*(double r,Complex c)
    {
        return new Complex(
            c.Re*r,
            c.Im*r
        );
    }
    
    public static Complex operator/(Complex c,double r)
    {
        return new Complex(
            c.Re/r,
            c.Im/r
        );
    }
    
    // used earlier defined operators and methods in Complex class
    public static Complex operator/(Complex c1,Complex c2)
    {
        // Mathematical Explanation
        // c1/c2 = c1*conj(c2)/c2*conj(c2) = c1*conj(c2)/|c2|^2
        double absC2 = c2.Mod();
        return (c1 * c2.Conj())/(absC2*absC2);
    }
   
    // used static method of Complex class
    public static Complex Exp(Complex c)
    {
        // Mathematical Explanation
        // e^(a+ib) = e^a*e^(ib)
        // so, r = e^a,theta = b
        return Complex.FromPolar(
            Math.Exp(c.Re),
            c.Im
        );
    }
    
    // == and != operator has to be overloaded together 
    // same goes to (< and >), (<= and >=)
    // if you overload one you must overload other; otherwise COMPILING ERROR!
    public static bool operator==(Complex c1,Complex c2)
    {
        // chacks for same object and null object reference
        if (ReferenceEquals(c1, c2))
            return true;
        if (ReferenceEquals(c1, null))
            return false;
        if (ReferenceEquals(c2, null))
            return false;
            
        return    c1.Re == c2.Re
               && c1.Im == c2.Im;
    }
    
    public static bool operator!=(Complex c1,Complex c2)
    {
        // chacks for same object and null object reference
        if (ReferenceEquals(c1, c2))
            return false;
        if (ReferenceEquals(c1, null))
            return true;
        if (ReferenceEquals(c2, null))
            return true;
            
        return    c1.Re != c2.Re
               || c1.Im != c2.Im;
    }
    
    // if you overload == and !=  Equals(Object obj) and GetHashCode()
    // SHOULD be overriden. Not mendetory though. It gives warning; so good practice
    public override bool Equals(Object obj)
    {
        // check for null and compare run-time types.
        if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            return false;
        return this == (Complex) obj;
    }
    
    public override int GetHashCode()
    {
        // Don't ask me why shift 2,not anything else!
        // I found this practice on various Codes including 
        // official documentations so used this
        return (Re.GetHashCode() << 2) ^ Im.GetHashCode(); 
    }
}

public class Run
{
    public static void Main(string[] args)
    {
        Complex a = new Complex(1,-1);
        Console.WriteLine(a);
        Console.WriteLine($"|a| = {a.Mod()}");
        Console.WriteLine($"Arg(a) = {a.Arg()}");
        
        Complex b = Complex.FromPolar(1,Math.PI/3);
        Console.WriteLine($"from polar (1,PI/2) = {b}");
        
        Complex c = new Complex(1,3);
        
        // Operation on Complex Number
        Console.WriteLine($"Conj({a}) = {a.Conj()}");
        Console.WriteLine($"({a}) + ({c}) = {a + c}");
        Console.WriteLine($"-({a}) = {-a}");
        Console.WriteLine($"({a}) - ({c}) = {a - c}");
        Console.WriteLine($"3({a}) = {3*a}");
        Console.WriteLine($"({a})*3 = {a*3}");
        Console.WriteLine($"({c})/3 = {c/3}");
        Console.WriteLine($"({a}) * ({c}) = {a * c}");
        Console.WriteLine($"({a}) / ({c}) = {a / c}");
        Console.WriteLine($"exp({a}) = {Complex.Exp(a)}");
        
        // Comparison on Complex Number
        Console.WriteLine($"({a}) == ({new Complex(a)}) = {a == new Complex(a)}");
        Console.WriteLine($"({a}) == ({c}) = {a == c}");
        Console.WriteLine($"({a}) != ({new Complex(a)}) = {a != new Complex(a)}");
        Console.WriteLine($"({a}) != ({c}) = {a != c}");
        // Note: its mathematically impossible to define a < or > for Complex Number
        //       Its an amazing thing! (https://youtu.be/acCGhA-n5z8)
    }
}