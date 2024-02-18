using CSIMedia.Context;
using CSIMedia.Dtos;
using CSIMedia.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSIMedia.Repositories;

public class NumberRepository(DataContext context)
{
    public async Task<List<Number>> GetNumbers()
    {
        var numbers = await context.Numbers.Select(x => new Number
        {
            Id = x.Id,
            Numbers = x.Numbers,
            Ascending = x.Ascending,
            TimeTakenToSort = x.TimeTakenToSort
        }).ToListAsync();
        return numbers;
    }

    public async Task AddNumbers(int[] numbers, bool ascending, TimeSpan timeToSort)
    {
        var efNumber = new EFNumber
        {
            Numbers = numbers,
            Ascending = ascending,
            TimeTakenToSort = timeToSort
        };
        context.Numbers.Add(efNumber);
        await context.SaveChangesAsync();
    }
}
