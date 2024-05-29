namespace XploreTechnicalTest
{
    public class TemporarySuspendHistoryList : List<TemporarySuspendHistory>
    {
        public const int MaxSuspendDays = 180;

        public DateTime GetEarliestStartDate()
        {
            var totalDays = (this.Count > 0) ? GetTotalDaysForYear(this.First().StartDate.Year) : 0;

            if (totalDays >= MaxSuspendDays)
                return this.Last().StartDate.AddYears(1);
            else
                return DateTime.Today.AddDays(1);
        }

        public DateTime GetMaxEndDate(DateTime startDate)
        {
            var totalDays = GetTotalDaysForYear(startDate.Year);

            var days = (MaxSuspendDays - totalDays);
            return startDate.AddDays(days - 1);
        }

        public new void Add(TemporarySuspendHistory item)
        {
            int totalDays = item.GetTotalDaysForCurrentYear();
            var remainingSuspendDays = Math.Max(0, MaxSuspendDays - totalDays);

            base.Add(item);
        }

        public override string ToString()
        {
            return string.Join(", ", this);
        }

        private int GetTotalDaysForYear(int year)
        {
            var items = this.Where(x => x.StartDate.Year == year);
            return items.Sum(x => x.GetTotalDaysForCurrentYear());
        }
    }
}
