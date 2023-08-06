namespace ElkoodTask.Models
{
    public class CompanyInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(length:100)]
        public string Name { get; set; }

        [MaxLength(length: 100)]
        public string Location { get; set; }

        public DateTime EstablishmentDate { get; set; }

        [MaxLength(length: 100)]
        public string Activity { get; set; }
    }
}
