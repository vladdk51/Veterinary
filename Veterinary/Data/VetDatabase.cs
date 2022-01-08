using System;
using System.Collections.Generic;
using System.Text;
using Veterinary.Models;
using SQLite;
using System.Threading.Tasks;

namespace Veterinary.Data
{
    public class VetDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public VetDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<AppointmentsList>().Wait();
            _database.CreateTableAsync<VetServices>().Wait();
            _database.CreateTableAsync<ListVetServices>().Wait();
        }

        public Task<List<AppointmentsList>> GetAppointmentsListAsync()
        {
            return _database.Table<AppointmentsList>().ToListAsync();
        }
        public Task<AppointmentsList> GetAppointmentsListAsync(int id)
        {
            return _database.Table<AppointmentsList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveAppointmentsListAsync(AppointmentsList alist)
        {
            if (alist.ID != 0)
            {
                return _database.UpdateAsync(alist);
            }
            else
            {
                return _database.InsertAsync(alist);
            }
        }
        public Task<int> DeleteAppointmentsListAsync(AppointmentsList alist)
        {
            return _database.DeleteAsync(alist);
        }

        public Task<int> SaveVetServicesAsync(VetServices service)
        {
            if (service.ID != 0)
            {
                return _database.UpdateAsync(service);
            }
            else
            {
                return _database.InsertAsync(service);
            }
        }

        public Task<int> DeleteVetServicesAsync(VetServices service)
        {
            return _database.DeleteAsync(service);
        }
        public Task<List<VetServices>> GetVetServicesAsync()
        {
            return _database.Table<VetServices>().ToListAsync();
        }

        public Task<int> SaveListVetServicesAsync(ListVetServices listv)
        {
            if (listv.ID != 0)
            {
                return _database.UpdateAsync(listv);
            }
            else
            {
                return _database.InsertAsync(listv);
            }
        }
        public Task<List<VetServices>> GetListVetServicesAsync(int vetappid)
        {
            return _database.QueryAsync<VetServices>(
            "select V.ID, V.Description from VetServices V"
            + " inner join ListVetServices LV"
            + " on V.ID = LV.VetServiceID where LV.VetAppointmentID = ?",
            vetappid);
        }
    }
}
