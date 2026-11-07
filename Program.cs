// ### Часть 1. НОД и НОК

// Console.WriteLine($"НОД(48, 18) = {Gcd(48, 18)}, НОК = {Lcm(48, 18)}");
// Console.WriteLine($"НОД(12, 8)  = {Gcd(12, 8)},  НОК = {Lcm(12, 8)}");
// Console.WriteLine($"НОД(7, 13)  = {Gcd(7, 13)},  НОК = {Lcm(7, 13)}");
// Console.WriteLine($"НОД(100, 25) = {Gcd(100, 25)}, НОК = {Lcm(100, 25)}");

// // алгоритм останавливается, когда b становится равным 0
// // В этот момент пара чисел — (a, 0). На ноль делятся все числа, поэтому
// // наибольший общий делитель пары (a, 0) — это само a: оно делит и себя,
// // и ноль.ответ равен a
// // НОД по алгоритму Евклида: заменяем пару (a, b) на (b, a % b),
// // пока остаток не станет нулём
// int Gcd(int a, int b)
// {
//     if (b == 0)
//     {
//         return a;
//     }

//     return Gcd(b, a % b);
// }

// int Lcm(int a, int b)
// {
//     return a / Gcd(a, b) * b;
// }

// ### Часть 2. Простые числа



// foreach (int n in new[] { 1, 2, 17, 18, 97, 0, -5 })
// {
//     Console.WriteLine($"IsPrime({n}) = {IsPrime(n)}");
// }

// bool IsPrime(int number)
// {
//     if (number < 2)
//     {
//         return false;
//     }

//     for (int i = 2; i * i <= number; i++)
//     {
//         if (number % i == 0)
//         {
//             return false;
//         }
//     }

//     return true;
// }


// ### Часть 3. Частотный анализ

// int[] values = [5, 2, 5, 3, 2, 5, 4, 3, 3];

// Dictionary<int, int> counts = [];

// foreach (int number in values)
// {
//     if (counts.ContainsKey(number))
//     {
//         counts[number]++;
//     }
//     else
//     {
//         counts[number] = 1;
//     }
// }

// foreach (KeyValuePair<int, int> pair in counts)
// {
//     Console.WriteLine($"{pair.Key} → {pair.Value}");
// }

// // массив просматривается 1 раз — для всех чисел
// // Это лучше, чем отдельно считать каждое число своим циклом по всему массиву:
// // тогда при k различных числах пришлось бы n × k сравнений,
// // а здесь — всего n


// ### Часть 4. Эксперимент с Fibonacci

// int calls = 0;

// calls = 0;
// Console.WriteLine($"Fibonacci(10) = {Fibonacci(10)}, вызовов: {calls}");

// calls = 0;
// Console.WriteLine($"Fibonacci(20) = {Fibonacci(20)}, вызовов: {calls}");

// // рекурсивный вариант быстро становится медленным,
// // потому что одни и те же значения пересчитываются многократно: F(3) и F(2)
// // в дереве вызовов считаются по нескольку раз. Каждый вызов порождает ещё два,
// // поэтому число вызовов растёт: 10 → 177 вызовов,
// // 20 → 21 891 вызовов — данные выросли вдвое, а работа — более чем в сто раз.
// // Наивная рекурсия Фибоначчи: правильный результат, но много повторных вычислений
// int Fibonacci(int n)
// {
//     calls++;

//     if (n <= 1)
//     {
//         return n;
//     }
//     return Fibonacci(n - 1) + Fibonacci(n - 2);
// }

// ## Итоговая задача. Анализ числового набора

int[] data = new[] { 12, 15, 12, 7, 19, 15, 12, 8, 7, 19 };
Console.WriteLine("Данные:");
Console.WriteLine(string.Join(" ", data));

int min = FindMin(data);
int max = FindMax(data);
Console.WriteLine();
Console.WriteLine($"Минимум: {min}");
Console.WriteLine($"Максимум: {max}");

Dictionary<int, int> frequencies = CountFrequencies(data);

Console.WriteLine();
Console.WriteLine($"Количество различных значений: {frequencies.Count}");

List<int> keys = new List<int>(frequencies.Keys);
keys.Sort();

Console.WriteLine();
Console.WriteLine("Частоты:");
PrintFrequencies(frequencies, keys);

Console.WriteLine();
Console.WriteLine($"НОД({min}, {max}): {Gcd(min, max)}");

Console.WriteLine();
Console.WriteLine(IsPrime(min) ? $"{min} - простое число" : $"{min} - не простое число");
Console.WriteLine(IsPrime(max) ? $"{max} - простое число" : $"{max} - не простое число");

int FindMin(int[] array)
{
    int min = array[0];
    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] < min)
        {
            min = array[i];
        }
    }
    return min;
}

int FindMax(int[] array)
{
    int max = array[0];
    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] > max)
        {
            max = array[i];
        }
    }
    return max;
}

Dictionary<int, int> CountFrequencies(int[] array)
{
    Dictionary<int, int> result = new Dictionary<int, int>();
    
    foreach (int number in array)
    {
        if (result.ContainsKey(number))
        {
            result[number]++;
        }
        else
        {
            result[number] = 1;
        }
    }
    return result;
}

void PrintFrequencies(Dictionary<int, int> counts, List<int> sortedKeys)
{
    foreach (int key in sortedKeys)
    {
        Console.WriteLine($"{key} -> {counts[key]}");
    }
}

int Gcd(int a, int b)
{
    while (b != 0)
    {
        int temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

bool IsPrime(int number)
{
    if (number < 2)
    {
        return false;
    }
    for (int i = 2; i * i <= number; i++)
    {
        if (number % i == 0)
        {
            return false;
        }
    }
    return true;
}