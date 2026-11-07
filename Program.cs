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



foreach (int n in new[] { 1, 2, 17, 18, 97, 0, -5 })
{
    Console.WriteLine($"IsPrime({n}) = {IsPrime(n)}");
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
