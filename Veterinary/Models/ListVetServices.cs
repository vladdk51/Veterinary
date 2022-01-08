using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Veterinary.Models
{
    public class ListVetServices
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(AppointmentsList))]
        public int VetAppointmentID { get; set; }
        public int VetServiceID { get; set; }
    }
}
