﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    internal class Log
    {
        public Int32 Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DurataToken { get; set; }
        public string Token { get; set; }
    }
}
