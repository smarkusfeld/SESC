using LibraryService.Application.Interfaces;
using LibraryService.Domain.Entities;
using LibraryService.Infastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Infastructure.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
