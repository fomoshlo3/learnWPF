using LAP.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAP.Data.Repositories
{
    public interface IManageBookingsRepository
    {
        Task<bool> UpdateBookingAsync(Booking booking);

        Task<bool> DeleteBookingAsync(Booking booking);

        Task<bool> CreateBookingAsync(Booking booking);

        Task<IEnumerable<Booking>> GetAllBookingsAsync();

        Task<Booking> GetBookingByIdAsync(int pk);
    }

    public class ManageBookingsRepository : IManageBookingsRepository
    {
        private readonly IDbContextFactory<LAPDbContext> _dbContextFactory;
        private readonly ILogger<ManageBookingsRepository> _logger;

        public ManageBookingsRepository(IDbContextFactory<LAPDbContext> dbContextFactory, ILogger<ManageBookingsRepository> logger)
        {
            _dbContextFactory = dbContextFactory;
            _logger = logger;
        }

        public async Task<bool> CreateBookingAsync(Booking booking)
        {
            try
            {
                using (var ctx = await _dbContextFactory.CreateDbContextAsync())
                {
                    ctx.Bookings.Add(booking);
                    await ctx.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Buchungen konnten nicht abgerufen werden. {0}", ex.ToString());
                return false;
            }
        }

        public Task<bool> DeleteBookingAsync(Booking booking)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Booking> GetBookingByIdAsync(int pk)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBookingAsync(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
