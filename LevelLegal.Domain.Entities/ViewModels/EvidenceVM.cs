using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelLegal.Domain.Entities.ViewModels
{
    public class EvidenceVM
    {
        [Key]
        public int Id { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(50)]
        public string SerialNumber { get; set; }

        public int MatterId { get; set; }

        public string MatterName { get; set; }
    }
}
