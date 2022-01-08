﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Veterinary.Models
{
    class AppointmentsList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
