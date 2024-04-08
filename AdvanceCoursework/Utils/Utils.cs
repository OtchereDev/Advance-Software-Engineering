
namespace AdvanceCoursework.Utils
{
    static public class Utils
    {
        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string AcceptInformation()
        {
            return Console.ReadLine().Trim();
        }

        public static Decimal AcceptDecimalInformation()
        {
            bool isValid = false;
            Decimal answer = 0;

            while (isValid != true)
            {
                string response = Console.ReadLine();
                isValid = Decimal.TryParse(response, out answer);

                if (isValid != true)
                {
                    PrintMessage("Please provide a valid answer");
                }
                else
                {
                    break;
                }
            }
            return answer;
        }

        public static float AcceptFloatInformation()
        {
            bool isValid = false;
            float answer = 0;

            while (isValid != true)
            {
                string response = Console.ReadLine();
                isValid = float.TryParse(response, out answer);

                if (isValid != true)
                {
                    PrintMessage("Please provide a valid answer");
                }
                else
                {
                    break;
                }
            }
            return answer;
        }

        public static bool AcceptBooleanInformation()
        {
            bool isValid = false;
            bool answer = false;

            while (isValid != true)
            {
                string response = Console.ReadLine();
                isValid = bool.TryParse(response, out answer);

                if (isValid != true)
                {
                    PrintMessage("Please provide a valid answer");
                }
                else
                {
                    break;
                }
            }
            return answer;
        }

        public static int AcceptIntegerInformation()
        {
            bool isValid = false;
            int answer = 0;

            while (isValid != true)
            {
                string response = Console.ReadLine();
                isValid = int.TryParse(response, out answer);

                if (isValid != true)
                {
                    PrintMessage("Please provide a valid answer");
                }
                else
                {
                    break;
                }
            }
            return answer;
        }

        public static DateTime AcceptDateInformation()
        {
            DateTime date = new DateTime();
            while (true)
            {
                string dateString = Console.ReadLine();

                if (DateTime.TryParse(dateString, out date))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter a valid date.");
                }
            }

            return date;
        }
    }
}

