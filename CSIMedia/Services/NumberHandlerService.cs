using CSIMedia.Dtos;
using CSIMedia.Models;
using CSIMedia.Repositories;

namespace CSIMedia.Services;

public class NumberHandlerService(NumberRepository numberRepository)
{
    public async Task<List<Number>> GetNumbersAsync()
    {
        return await numberRepository.GetNumbers();
    }

    public async Task<(bool Error, string Message)> AddNumbers(UserInputModel userInputModel)
    {
        if (string.IsNullOrWhiteSpace(userInputModel.RawUserInput))
        {
            return (true, "Please enter a list of numbers, separated by commas.");
        }

        List<int> numbers;
        try
        {
            numbers = userInputModel.RawUserInput
                .TrimEnd(',')
                .Replace(" ", "")
                .Split(',')
                .Select(int.Parse)
                .ToList();
        }
        catch
        {
            return (true, "Invalid input. Please enter a comma separated list of numbers.");
        }

        if (numbers.Count > 32)
        {
            return (true, "Too many numbers. Please enter 32 or fewer numbers.");
        }

        var timeBeforeSort = DateTimeOffset.Now;
        // Assuming use of .OrderBy and .OrderByDescending since instructions did not specify a custom solution.
        var sorted = userInputModel.Ascending ? numbers.OrderBy(n => n) : numbers.OrderByDescending(n => n);
        var timeAfterSort = DateTimeOffset.Now;
        var timeToSort = timeAfterSort - timeBeforeSort;

        await numberRepository.AddNumbers(sorted.ToArray(), userInputModel.Ascending, timeToSort);
        return (false, "Numbers added successfully.");
    }
}
