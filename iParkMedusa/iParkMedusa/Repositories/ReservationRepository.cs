﻿using iParkMedusa.Contexts;
using iParkMedusa.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iParkMedusa.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            //return await Task.FromResult<List<Slot>>(_context.Slots.Include(s => s.Status).ToList());
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _context.Reservations.Where(s => s.Id.Equals(id)).Include(u => u.ApplicationUser).Include(p => p.Park).FirstOrDefaultAsync();
        }

        public async Task<int> DeleteReservationByIdAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            return await _context.SaveChangesAsync();
        }
    }
}