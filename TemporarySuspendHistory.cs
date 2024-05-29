namespace XploreTechnicalTest
{
    public class TemporarySuspendHistory
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public TemporarySuspendHistory(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public int GetTotalDaysForCurrentYear()
        {
            DateTime lastDayOfCurrentYear = new DateTime(StartDate.Year, 12, 31);
            DateTime endDate = (EndDate < lastDayOfCurrentYear) ? EndDate : lastDayOfCurrentYear;
            return (endDate - StartDate.Date).Days + 1;
        }

        public override string ToString()
        {
            return $"{{StartDate = {StartDate.ToShortDateString()}, EndDate = {EndDate.ToShortDateString()}}}";
        }
    }
}
