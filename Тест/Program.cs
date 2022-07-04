namespace Тест
{
    internal class Program
    {
        const double ProcBank = 0.08;

        private static double getProcent(double cash)
        {
            double money = 0;
            double procent = 0;
            while (money <= cash)
            {
                if (cash >= 700000 && cash <= 749999.99)
                {
                    procent = 0.2;
                    break;
                }

                if (money == 700000)
                {
                    procent = 0.2;
                    money += 50000;
                    continue;
                }

                if (money < 750000)
                {
                    money += 49999.99;
                    procent+=0.01;
                    money += 0.01;
                }
                else
                {
                    money += 49999.99;
                    procent -= 0.01;
                    money += 0.01;
                }
            }
            return Math.Round(procent, 2);
        }

        private static double getMoney(double cash, double procent, int years)
        {
            for (int i = 1; i <= years * 12; i++)
            {
                if (i % 3 == 0)
                {
                    procent += 0.005;
                }

                if (procent - ProcBank > 5)
                {
                    cash += cash * procent * 0.7;
                }
                else
                {
                    cash += cash * procent;
                }
            }
            return Math.Round(cash, 2);
        }

        private static double getMax()
        {
            double max = 0;
            double maxMoney = 0;
            double money = 0;
            double procent;
            while (money <= 1000000)
            {
                procent = getProcent(money);
                if (getMoney(money, procent, 1) > max)
                {
                    max = getMoney(money, procent, 1);
                    maxMoney = money;
                }
                money += 1;
            }
            return Math.Round(maxMoney, 2);
        }

        static void Main(string[] args)
        {
            Console.Write("Введите сумму вклада: ");
            double cash = Convert.ToDouble(Console.ReadLine());
            Console.Write("Количество лет: ");
            int years = Convert.ToInt32(Console.ReadLine());
            double procent = getProcent(cash);
            Console.WriteLine("Первоначальный вклад: {0:f2} руб.", Math.Round(cash, 2));
            Console.WriteLine("Процент: {0:0}%", procent * 100);
            if (years % 10 == 1)
            {
                Console.WriteLine("Сумма на счету через {0} год: {1} руб.", years, getMoney(cash, procent, years));
            }
            else if (years % 10 == 2 || years % 10 == 3 || years % 10 == 4)
            {
                Console.WriteLine("Сумма на счету через {0} года: {1} руб.", years, getMoney(cash, procent, years));
            }
            else
            {
                Console.WriteLine("Сумма на счету через {0} лет: {1} руб.", years, getMoney(cash, procent, years));
            }
            Console.WriteLine("Для получения максимального дохода через 1 год необходимо вложить следующую сумму: {0:f2} руб.", getMax());
        }
    }
}