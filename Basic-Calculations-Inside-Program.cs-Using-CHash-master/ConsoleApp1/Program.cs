
//class maxfromthreenumber
//{
//    public static void Main(String[] args)
//    {
//        Console.Write("Enter 1st Number:");
//        int a1 = int.Parse(Console.ReadLine());
//        Console.Write("Enter 2nd Number:");
//        int a2 = int.Parse(Console.ReadLine());
//        Console.Write("Enter Third Number:");
//        int a3 = int.Parse(Console.ReadLine());


//        if((a1 > a2) && (a1 > a3)) 
//        {
//            Console.WriteLine("Number " + a1 + " is Greater then " + a2 + " & " +a3);
//        }
//        else if((a2 > a1) && (a2> a3)) 
//        {
//            Console.WriteLine("Number " + a2 + " is Greater then " + a1 + " & " + a3);
//        }
//        else if((a3 > a1) && (a3 > a2))
//        {
//            Console.WriteLine("Number " +a3 + " is Greater then " + a1+ " & " + a2);
//        }
//    }
//}


//class Divisiblebythree
//{
//    public static void Main(String[] args)
//    {
//        Console.WriteLine("Enter Number: ");
//        int a1 = int.Parse(Console.ReadLine());

//        if (a1 % 3 ==0)
//        {
//            Console.WriteLine("Number is Divisible by 3"); 
//        }
//        else
//        {
//            Console.WriteLine("Number is Not Divisible by 3");
//        }
//    }
//}

//class evenorodd
//{
//    public static void Main(String[] args)
//    {
//        Console.WriteLine("Enter Number: ");
//        int a1 = int.Parse(Console.ReadLine());

//        if (a1 % 2 == 0)
//        {
//            Console.WriteLine("Number is Even");
//        }
//        else if(a1 % 2 == 1)
//        {
//            Console.WriteLine("Number is Odd");
//        }
//    }
//}


//class leapyear
//{
//    public static void Main(String[] args)
//    {
//        Console.Write("Enter year to find year is leap year or not: ");
//        int num = int.Parse(Console.ReadLine());

//        if ((num % 400 == 0) || (num % 400 != 0) && (num % 4 == 0))
//        {
//            Console.WriteLine("Entered year is a leap year");
//        }
//        else
//        {
//            Console.WriteLine("Entered year is not leap year");
//        }
//    }
//}


//class dataisnumber
//{
//    public static void Main(string[] args)
//    {
//        Console.Write("Enter a data to check whether it is number or character : ");
//        Char a  = char.Parse(Console.ReadLine());

//        if (a > '0' && a < '9')
//        {
//            Console.WriteLine("It is Number!!!");
//        }
//        else if((a >= 'A' && a <= 'Z') || (a >= 'a' && a <= 'z'))
//        {
//            Console.WriteLine("It is Character");
//        }
//    }
//}


//class PositiveOrNegative
//{
//    public static void Main(string[] args)
//    {
//        Console.WriteLine("Enter any number: ");
//        int a1 = int.Parse(Console.ReadLine());

//        if (a1 > 0)
//        {
//            Console.WriteLine("It is a Positive Number");
//        }
//        else if(a1 < 0)
//        {
//            Console.WriteLine("It is a Negative Number");
//        }
//    }
//}




//class charorvowel
//{
//    public static void Main(string[] args)
//    {
//        Console.WriteLine("Enter any alphabet from a to z: ");
//        Char ch = Char.Parse(Console.ReadLine());

//        if(ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
//        {
//            Console.WriteLine("Entered alphabet is vowel");
//        }
//        else
//        {
//            Console.WriteLine("Entered alphabet is consonant");
//        }
//    }
//}




//class uppernlowerCase
//{
//    public static void Main(string[] args)
//    {
//        Console.WriteLine("Enter any character as alphabet: ");
//        Char ch = Char.Parse(Console.ReadLine());

//        if (ch >= 'A' && ch <= 'Z')
//            Console.WriteLine("\n" + ch +
//                    " is an UpperCase character");
//        else if (ch >= 'a' && ch <= 'z')
//            Console.WriteLine("\n" + ch +
//                    " is an LowerCase character");
//        else
//            Console.WriteLine("\n" + ch +
//                    " is not an alphabetic character");
//    }
//}


//class Divisiblebyfive
//{
//    public static void Main(String[] args)
//    {
//        Console.WriteLine("Enter Number: ");
//        int a1 = int.Parse(Console.ReadLine());

//        if (a1 % 5 == 0)
//        {
//            Console.WriteLine("Hello ");
//        }
//        else
//        {
//            Console.WriteLine("Bye");
//        }
//    }
//}


class printlastdigit
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter Number: ");
        int num = int.Parse(Console.ReadLine());

        for (int i = num;  i < 0; i++)
        {
            Console.WriteLine(i);
        }
    }
}