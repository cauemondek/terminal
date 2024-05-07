using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TerminaldotNET.Models
{
    public class Archive
    {
        [Key]
        public string Name { get; set; }
        public string FileType { get; set; }
        public string? Output { get; set; }
        public string? Execute { get; set; }
    }
}