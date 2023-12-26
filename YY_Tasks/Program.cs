namespace YY_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] start = Console.ReadLine().Split();
            string[] end = Console.ReadLine().Split();

            //string[] input = System.IO.File.ReadAllLines("input.txt");

            //string[] start = input[0].Split();
            //string[] end = input[1].Split();
            int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int daysInYear = 365;

            int year1 = int.Parse(start[0]);
            int month1 = int.Parse(start[1]);
            int day1 = int.Parse(start[2]);
            int hour1 = int.Parse(start[3]);
            int min1 = int.Parse(start[4]);
            int sec1 = int.Parse(start[5]);

            int year2 = int.Parse(end[0]);
            int month2 = int.Parse(end[1]);
            int day2 = int.Parse(end[2]);
            int hour2 = int.Parse(end[3]);
            int min2 = int.Parse(end[4]);
            int sec2 = int.Parse(end[5]);

            int days = 0;
            int secondsInIncompleteDay = 0;
            int secondsInDay = 86400;

            int years = year2 - year1;

            if (years > 0)
            {
                days += daysInMonth[month1 - 1] - day1;


                for (int i = month1; i < 12; i++)
                {
                    days += daysInMonth[i];
                }

                days += --years * daysInYear;

                for (int i = 0; i < month2 - 1; i++)
                {
                    days += daysInMonth[i];
                }

                days += day2;


            }

            else

            {
                for (int i = month1 - 1; i < month2 - 1; i++)
                {
                    days += daysInMonth[i];
                }

                days += day2 - day1;

            }

            int secondsFirst = sec1 + min1 * 60 + hour1 * 3600;
            int secondsLast = sec2 + min2 * 60 + hour2 * 3600;
            if (secondsFirst < secondsLast)
            {
                secondsInIncompleteDay += secondsLast - secondsFirst;
                if (secondsInIncompleteDay <= secondsInDay)
                {
                    if (secondsInIncompleteDay == secondsInDay) secondsInIncompleteDay = 0;
                    days--;
                }
            }
            else
            {
                secondsInIncompleteDay += secondsInDay - secondsFirst + secondsLast;
                if (secondsInIncompleteDay == secondsInDay)
                {
                    secondsInIncompleteDay = 0;
                }
            }

            System.Console.WriteLine(days + " " + secondsInIncompleteDay);

        }
    }
}