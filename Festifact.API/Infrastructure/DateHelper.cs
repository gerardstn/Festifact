namespace Festifact.API.Infrastructure
{
    public class DateHelper
    {
        public static DateTime StringToDateTime(string DateString)
        {
            string[] parts = DateString.Split('-');
            int year = Int32.Parse(parts[0]);
            int month = Int32.Parse(parts[1]);
            int day = Int32.Parse(parts[2]);

            return new DateTime(year, month, day, 00, 00, 00);
        }
    }
}
