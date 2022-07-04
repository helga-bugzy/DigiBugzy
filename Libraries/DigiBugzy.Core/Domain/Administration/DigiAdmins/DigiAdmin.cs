



namespace DigiBugzy.Core.Domain.Administration.DigiAdmins
{
    [Table(nameof(DigiAdmin), Schema = DatabaseConstants.Schemas.Admin)]
    public class DigiAdmin
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public string Name { get; set; }

        public List<Bugzer> Bugzers { get; set; }
    }
}
