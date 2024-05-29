using XploreTechnicalTest;


TemporarySuspendHistoryList listA =
    [
        new(DateTime.Parse("2024-01-01"), DateTime.Parse("2024-01-30")),
        new(DateTime.Parse("2024-03-01"), DateTime.Parse("2024-03-30"))
    ];

TemporarySuspendHistoryList listB =
    [
        new(DateTime.Parse("2024-01-01"), DateTime.Parse("2024-01-30")),
        new(DateTime.Parse("2024-03-01"), DateTime.Parse("2024-07-28"))
    ];

TemporarySuspendHistoryList listC = [];

Process(listA);


void Process(TemporarySuspendHistoryList list)
{
    DateTime earliestStartDate = list.GetEarliestStartDate();
    DateTime maxEndDate;

    Console.WriteLine($"TemporarySuspendHistoryList -> {list}");

    DateTime selectedStartDate = GetSelectedStartDateFromUser(earliestStartDate);

    maxEndDate = list.GetMaxEndDate(selectedStartDate);
    DateTime selectedEndDate = GetSelectedEndDateFromUser(maxEndDate);

    Console.WriteLine("Complete!");
    Console.WriteLine($"Start Date: {selectedStartDate.ToShortDateString()}");
    Console.WriteLine($"End Date: {selectedEndDate.ToShortDateString()}");
}

DateTime GetSelectedStartDateFromUser(DateTime earliestStartDate)
{
    DateTime selectedStartDate;

    while (true)
    {
        Console.Write($"Selected Start Date (min: {earliestStartDate.ToShortDateString()}): ");
        string? selectedStartDateString = Console.ReadLine();

        if (DateTime.TryParse(selectedStartDateString, out selectedStartDate))
        {
            if (selectedStartDate >= earliestStartDate)
                return selectedStartDate;
            else
                Console.WriteLine($"Error: Start date must be greater than or equal to the earliest start date ({earliestStartDate.ToShortDateString()})");
        }
        else
        {
            Console.WriteLine("Error: Invalid input. Please enter a valid date.");
        }
    }
}

DateTime GetSelectedEndDateFromUser(DateTime maxEndDate)
{
    DateTime selectedEndDate;

    while (true)
    {
        Console.Write($"Selected End Date (max: {maxEndDate.ToShortDateString()}): ");
        string? endDateString = Console.ReadLine();

        if (DateTime.TryParse(endDateString, out selectedEndDate))
        {
            if (selectedEndDate <= maxEndDate)
                return selectedEndDate;
            else
                Console.WriteLine($"Error: End date must be less than or equal to the maximum end date ({maxEndDate.ToShortDateString()})");
        }
        else
        {
            Console.WriteLine("Error: Invalid input. Please enter a valid date.");
        }
    }
}
