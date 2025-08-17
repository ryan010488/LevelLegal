using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LevelLegal.Domain.Entities.ViewModels
{
    public class MatterVM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string? ClientName { get; set; }

        public virtual ICollection<EvidenceVM> Evidences { get; set; }

    }
}
