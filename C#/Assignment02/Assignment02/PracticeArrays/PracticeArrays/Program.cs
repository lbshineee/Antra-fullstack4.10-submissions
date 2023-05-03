// 1. Copying an Array
Console.WriteLine("\n\n------------------------------");
Console.WriteLine("1. Copying an Array\n");
int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

int[] arrCopy = new int[arr.Length];

int i;
for (i = 0; i < arr.Length; i++) arrCopy[i] = arr[i];

Console.WriteLine("arr: ");
for (i = 0; i < arr.Length; i++) Console.Write(arr[i] + " ");

Console.WriteLine("\narrCopy: ");
for (i = 0; i < arrCopy.Length; i++) Console.Write(arrCopy[i] + " ");

// LongestSequence();


// 2. Write a simple program that lets the user manage a list of elements.
static void ProblemTwo_array()
{
    Console.WriteLine("\n\n------------------------------");
    Console.WriteLine("2. Write a simple program that lets the user manage a list of elements.");

    List<String> list = new List<string>();
    String input;
    do
    {
        Console.WriteLine("\nEnter command (+ item, - item, or -- to clear)) (b to break):");
        input = Console.ReadLine();

        if (input.StartsWith("+")) list.Add(input.Substring(2));
        else if (input == "--") list.Clear();
        else if (input.StartsWith("-") && input != "--")
        {
            if (list.Contains(input.Substring(2))) list.Remove(input.Substring(2));
        }
        else if (input == "b") break;

        Console.WriteLine("\nCurrent list: ");
        foreach (String item in list) Console.Write(item + " ");
        Console.WriteLine();

    } while (true);
}




// 3. Write a method that calculates all prime numbers in given range and returns them as array of integers
static int[] FindPrimesInRange(int startNum, int endNum)
{
    Console.WriteLine("\n\n------------------------------");
    Console.WriteLine("3. Write a method that calculates all prime numbers in given range and returns them as array of integers. ");

    List<int> primes = new List<int>();

    for (int num = startNum; num <= endNum; num++)
    {
        bool isPrime = true;

        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        if (isPrime && num > 1)
        {
            primes.Add(num);
        }
    }

    return primes.ToArray();
}

// 4. Write a program to read an array of n integers (space separated on a single line) and an
//  integer k, rotate the array right k times and sum the obtained arrays after each rotation as shown below

static void RotateInput()
{
    Console.WriteLine("\n\n------------------------------");
    Console.WriteLine("4. Write a program to read an array of n integers and integer k, rotate the array right k times and sum the obtained arrays after each rotation.");
    string[] input = Console.ReadLine().Split(' ');
    int n = input.Length;
    int[] arr = new int[n];
    int[] sum = new int[n];

    for (int i = 0; i < n; i++)
    {
        arr[i] = int.Parse(input[i]);
    }

    int k = int.Parse(Console.ReadLine());

    for (int r = 1; r <= k; r++)
    {
        int[] rotated = new int[n];

        for (int i = 0; i < n; i++)
        {
            rotated[(i + r) % n] = arr[i];
        }

        arr = rotated;

        for (int i = 0; i < n; i++)
        {
            sum[i] += rotated[i];
        }
    }

    for (int i = 0; i < n; i++)
    {
        Console.Write(sum[i] + " ");
    }

    Console.ReadLine();
}



// 5. Write a program that finds the longest sequence of equal elements in an array of integers.
//  If several longest sequences exist, print the leftmost one.

static void LongestSequence()
{
    Console.WriteLine("\n\n------------------------------");
    Console.WriteLine("5. Write a program that finds the longest sequence of equal elements in an array of integers. If several longest sequences exist, print the leftmost one.");
    int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
    int maxLength = 1, length = 1, start = 0;

    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] == array[i - 1])
        {
            length++;
            if (length > maxLength)
            {
                maxLength = length;
                start = i - maxLength + 1;
            }
        }
        else
        {
            length = 1;
        }
    }

    for (int i = start; i < start + maxLength; i++)
    {
        Console.Write(array[i] + " ");
    }
}


// 7. Write a program that finds the most frequent number in a given sequence of numbers. In
//  case of multiple numbers with the same maximal frequency, print the leftmost of them.

static void ProblemSeven()
{
    Console.WriteLine("\n\n------------------------------");
    Console.WriteLine("7. Write a program that finds the most frequent number in a given sequence of numbers.");

    // Read the input sequence
    int[] sequence = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

    // Find the most frequent number
    Dictionary<int, int> frequency = new Dictionary<int, int>();
    int maxFrequency = 0;
    int mostFrequentNumber = sequence[0];
    for (int i = 0; i < sequence.Length; i++)
    {
        int number = sequence[i];
        if (!frequency.ContainsKey(number))
        {
            frequency[number] = 0;
        }
        frequency[number]++;
        if (frequency[number] > maxFrequency || (frequency[number] == maxFrequency && number < mostFrequentNumber))
        {
            maxFrequency = frequency[number];
            mostFrequentNumber = number;
        }
    }

    // Print the result
    Console.WriteLine("The number {0} is the most frequent (occurs {1} times)", mostFrequentNumber, maxFrequency);
}


// Practice Strings

// 1. Write a program that reads a string from the console, reverses its letters and prints the result back at the console.
//  In two ways.

// Method #1
static void ReverseString()
{
    Console.WriteLine("\n\nPractice Strings\n------------------------------");
    Console.WriteLine("1. Write a program that reads a string from the console, reverses its letters and prints the result back at the console.");
    Console.Write("Enter a string: ");
    string input = Console.ReadLine();

    char[] charArray = input.ToCharArray();
    Array.Reverse(charArray);
    string reversedString = new string(charArray);

    Console.WriteLine("Reversed string: " + reversedString);
}
// Method #2
static void ReverseString2(string[] args)
{
    Console.WriteLine("\n\n------------------------------");
    Console.WriteLine("1. Write a program that reads a string from the console, reverses its letters and prints the result back at the console.");
    Console.Write("Enter a string: ");
    string input = Console.ReadLine();

    Console.Write("Reversed string: ");
    for (int i = input.Length - 1; i >= 0; i--)
    {
        Console.Write(input[i]);
    }
    Console.WriteLine();
}



// 2. Write a program that reverses the words in a given sentence without changing the punctuation and spaces.

static void ProblemTwo()
{
    Console.WriteLine("\n\n------------------------------");
    Console.WriteLine("2. Write a program that reverses the words in a given sentence without changing the punctuation and spaces.");
    // Read the sentence from the console
    Console.WriteLine("Enter a sentence: ");
    string sentence = Console.ReadLine();

    // Define the separators between words
    char[] separators = { ' ', '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '\"', '\'', '\\', '/', '!', '?' };

    // Split the sentence into words and separators
    string[] wordsAndSeparators = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);

    // Reverse the array of words
    Array.Reverse(wordsAndSeparators);

    // Print the reversed sentence
    int i = 0;
    foreach (char c in sentence)
    {
        if (Array.IndexOf(separators, c) != -1)
        {
            Console.Write(wordsAndSeparators[i++] + c);
        }
    }
    Console.WriteLine();
}

// 3. Write a program that extracts from a given text all palindromes, 

static void ProblenThree()
{
    Console.WriteLine("\n\n------------------------------");
    Console.WriteLine("3. Write a program that extracts from a given text all palindromes.");
    string text = "Hi,exe? ABBA! Hog fully a string: ExE. Bob";
    char[] separators = { ' ', ',', '.', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?' };

    string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    var palindromes = words.Where(word => IsPalindrome(word)).Distinct().OrderBy(p => p);

    Console.WriteLine(string.Join(", ", palindromes));
}

static bool IsPalindrome(string word)
{
    string reversedWord = new string(word.Reverse().ToArray());
    return word.Equals(reversedWord, StringComparison.OrdinalIgnoreCase);
}



// 4. Write a program that parses an URL given in the following format:
//  [protocol]://[server]/[resource]

static void URLParser()
{
    Console.WriteLine("\n\n------------------------------");
    Console.WriteLine("4. Write a program that parses an URL given in a certain format:");
    Console.Write("Enter a URL: ");
    string url = Console.ReadLine();

    // Split the URL into protocol, server, and resource
    string[] parts = url.Split(new char[] { ':', '/' }, StringSplitOptions.RemoveEmptyEntries);
    string protocol = "";
    string server = "";
    string resource = "";

    // Check how many parts were extracted and assign them to the correct variables
    if (parts.Length == 1)
    {
        server = parts[0];
    }
    else if (parts.Length == 2)
    {
        protocol = parts[0];
        server = parts[1];
    }
    else if (parts.Length == 3)
    {
        protocol = parts[0];
        server = parts[1];
        resource = parts[2];
    }
    else
    {
        Console.WriteLine("Invalid URL format.");
        return;
    }

    // Print the extracted parts
    Console.WriteLine("Protocol: " + protocol);
    Console.WriteLine("Server: " + server);
    Console.WriteLine("Resource: " + resource);
}

