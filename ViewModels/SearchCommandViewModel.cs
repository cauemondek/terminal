using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TerminaldotNET.ViewModels
{
    public class SearchCommandViewModel
    {
        [Required]
        public string Call { get; set; }
    }
}