using System;
using System.Text;

class IntSquareMatrix
{
    private int[,] _a;
    
    public IntSquareMatrix(int n = 2)
    {
        if(n < 2)
            throw new Exception("Invalid Dimention");
        _a = new int[n,n];
    }
    
    public IntSquareMatrix(int[,] a)
    {
        int n = a.GetLength(0);
        int m = a.GetLength(1);
        if(n < 2 || n != m)
            throw new Exception("Invalid Dimention");
        _a = a.Clone() as int[,];
    }
    
    public IntSquareMatrix(IntSquareMatrix other) : this(other._a)
    {
    }
    

    public int this[int i,int j]
    {
        get
        {
            return _a[i,j];
        }
        set
        {
            _a[i,j] = value;
        }
    }
    
    public int N
    {
        get
        {
            return _a.GetLength(0);
        }
    }
    
    public static IntSquareMatrix operator*(IntSquareMatrix m1,IntSquareMatrix m2)
    {
        int n = m1.N;
        int m = m2.N;
        if(n != m)
            throw new Exception($"Can not multiply {n}x{n} and {m}x{m} martix");
        
        IntSquareMatrix result = new IntSquareMatrix(n);
        for(int i = 0;i < n;i++)
        {
            for(int j = 0;j < n;j++)
            {
               for(int k = 0;k < n;k++){
                   result[i,j] += (m1[i,k] * m2[k,j]); 
               }
            }
        }
        return result;
    }
    public override string ToString()
    {
        StringBuilder output = new StringBuilder("");
        int n = _a.GetLength(0);
        for(int i = 0;i < n;i++)
        {
            for(int j = 0;j < n;j++)
            {
               output.Append($"{_a[i,j]} ");
            }
            output.Append("\n");
        }
        return output.ToString();
    }
    
    public static IntSquareMatrix I(int n)
    {
        IntSquareMatrix identity = new IntSquareMatrix(n);
        for(int i = 0;i < n;i++)
            identity[i,i] = 1;
        return identity;
    }
}

class Program
{
    public static void Main(string[] args) {
        int[,] a = new int [3,3]{
            {1,2,3},
            {4,5,6},
            {7,8,9}
        };
        IntSquareMatrix matrixA = new IntSquareMatrix(a);
        Console.WriteLine(BinaryExponentiation(matrixA,3));
    }
    
    public static IntSquareMatrix BinaryExponentiation(IntSquareMatrix a,int n)
    {
        if(n == 0) 
            return IntSquareMatrix.I(a.N);
        IntSquareMatrix half = BinaryExponentiation(a,n>>1);
        IntSquareMatrix full = half * half;
        if((n & 1) == 1)
            full *= a;
        return full;
    }
}