// Task 1
using System;

class Program
{
    static void Main()
    {
        int[] A = new int[5];
        double[,] B = new double[3, 4];
        Random r = new Random();

        for (int i = 0; i < 5; i++)
            A[i] = int.Parse(Console.ReadLine());

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 4; j++)
                B[i, j] = r.Next(1, 10);

        double sum = 0, product = 1;
        double min = A[0], max = A[0];
        int even = 0;
        double columns = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Write(A[i] + " ");
            sum += A[i];
            product *= A[i];

            if (A[i] < min) min = A[i];
            if (A[i] > max) max = A[i];
            if (A[i] % 2 == 0) even += A[i];
        }

        Console.WriteLine();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write(B[i, j] + " ");
                sum += B[i, j];
                product *= B[i, j];

                if (B[i, j] < min) min = B[i, j];
                if (B[i, j] > max) max = B[i, j];
                if (j % 2 == 0) columns += B[i, j];
            }
            Console.WriteLine();
        }

        Console.WriteLine("Max: " + max);
        Console.WriteLine("Min: " + min);
        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Product: " + product);
        Console.WriteLine("Even sum: " + even);
        Console.WriteLine("Odd columns sum: " + columns);
    }
}

// Task 2
using System;

class Program
{
    static void Main()
    {
        int[,] a = new int[5, 5];
        Random r = new Random();
        int min = 101, max = -101;
        int minPos = 0, maxPos = 0;

        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
            {
                a[i, j] = r.Next(-100, 101);
                Console.Write(a[i, j] + "\t");

                int p = i * 5 + j;

                if (a[i, j] < min)
                {
                    min = a[i, j];
                    minPos = p;
                }

                if (a[i, j] > max)
                {
                    max = a[i, j];
                    maxPos = p;
                }
            }

        int sum = 0;

        for (int i = Math.Min(minPos, maxPos) + 1;
             i < Math.Max(minPos, maxPos); i++)
            sum += a[i / 5, i % 5];

        Console.WriteLine("\nSum: " + sum);
    }
}

// Task 3
using System;

class Program
{
    static void Main()
    {
        string s = Console.ReadLine();
        int key = int.Parse(Console.ReadLine());
        string result = "";

        foreach (char c in s)
        {
            if (c >= 'a' && c <= 'z')
                result += (char)('a' + (c - 'a' + key % 26 + 26) % 26);
            else if (c >= 'A' && c <= 'Z')
                result += (char)('A' + (c - 'A' + key % 26 + 26) % 26);
            else
                result += c;
        }

        Console.WriteLine(result);

        string original = "";
        foreach (char c in result)
        {
            if (c >= 'a' && c <= 'z')
                original += (char)('a' + (c - 'a' - key % 26 + 26) % 26);
            else if (c >= 'A' && c <= 'Z')
                original += (char)('A' + (c - 'A' - key % 26 + 26) % 26);
            else
                original += c;
        }

        Console.WriteLine(original);
    }
}

// Task 4
using System;

class Program
{
    static void Main()
    {
        int[,] a = new int[2, 2];
        int[,] b = new int[2, 2];

        for (int i = 0; i < 2; i++)
            for (int j = 0; j < 2; j++)
                a[i, j] = int.Parse(Console.ReadLine());

        int k = int.Parse(Console.ReadLine());

        Console.WriteLine("Multiplication by number:");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
                Console.Write(a[i, j] * k + " ");
            Console.WriteLine();
        }

        for (int i = 0; i < 2; i++)
            for (int j = 0; j < 2; j++)
                b[i, j] = int.Parse(Console.ReadLine());

        Console.WriteLine("Addition:");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
                Console.Write((a[i, j] + b[i, j]) + " ");
            Console.WriteLine();
        }

        Console.WriteLine("Product:");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
                Console.Write((a[i, 0] * b[0, j] + a[i, 1] * b[1, j]) + " ");
            Console.WriteLine();
        }
    }
}

// Task 5
using System;

class Program
{
    static void Main()
    {
        string s = Console.ReadLine();
        string[] parts = s.Split('+', '-');
        int result = int.Parse(parts[0]);
        int n = 1;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '+')
                result += int.Parse(parts[n++]);
            else if (s[i] == '-')
                result -= int.Parse(parts[n++]);
        }

        Console.WriteLine(result);
    }
}

// Task 6
using System;

class Program
{
    static void Main()
    {
        string s = Console.ReadLine();
        bool upper = true;

        for (int i = 0; i < s.Length; i++)
        {
            if (upper && char.IsLetter(s[i]))
            {
                s = s.Substring(0, i) + char.ToUpper(s[i]) + s.Substring(i + 1);
                upper = false;
            }

            if (s[i] == '.' || s[i] == '!' || s[i] == '?')
                upper = true;
        }

        Console.WriteLine(s);
    }
}

// Task 7
using System;

class Program
{
    static void Main()
    {
        string s = Console.ReadLine();
        string word = Console.ReadLine();
        string[] parts = s.Split(' ');
        int count = 0;

        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i].ToLower().Trim(',', '.', '!', '?') == word.ToLower())
            {
                parts[i] = new string('*', word.Length);
                count++;
            }
        }

        Console.WriteLine(string.Join(" ", parts));
        Console.WriteLine("Replacements: " + count);
    }
}

// Task 8
using System;

class Program
{
    static void Main(string[] args)
    {
        string s = args[0];
        int key = int.Parse(args[1]);
        string result = "";

        foreach (char c in s)
        {
            if (c >= 'a' && c <= 'z')
                result += (char)('a' + (c - 'a' + key % 26 + 26) % 26);
            else if (c >= 'A' && c <= 'Z')
                result += (char)('A' + (c - 'A' + key % 26 + 26) % 26);
            else
                result += c;
        }

        Console.WriteLine(result);
    }
}