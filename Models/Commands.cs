using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TerminaldotNET.Models
{
    public class Command
    {
        public int Id { get; set; }
        public string Call { get; set; }
        public string Output { get; set; }
        public string? Execute { get; set; }
    }
}