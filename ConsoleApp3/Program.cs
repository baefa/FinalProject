using FinalProject.Context;
using FinalProject.Models;
using FinalProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (var dbContext = new FinalProjectDbContext())
            {

                try
                {
                    IDataService<Producer> producerService = new GenericDataService<Producer>(dbContext);
                    await producerService.Update(2, new Producer() { Telephone = "Azb" });
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
