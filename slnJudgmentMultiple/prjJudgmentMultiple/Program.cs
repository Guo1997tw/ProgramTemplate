namespace prjJudgmentMultiple
{
    public class Program
    {
        public static bool isEvenNumbers(int num1, int num2)
        {
            while(num1 > num2)
            {
                num1 -= num2;
            }
            return num1 == num2;
        }

        static void Main(string[] args)
        {
            int a = 12;
            int b = 3;

            var result = isEvenNumbers(a, b);

            Console.WriteLine((result) ? $"{a} 是 {b} 的倍數" : $"{a} 不是 {b} 的倍數");
        }
    }
}