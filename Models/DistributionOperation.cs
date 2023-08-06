namespace ElkoodTask.Models
{
    public class DistributionOperation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [InverseProperty("PrimaryBranchInfo")]
        public int PrimaryBranchInfoId { get; set; }
        public BranchInfo PrimaryBranchInfo { get; set; }
        [InverseProperty("SecondaryBranchInfo")]
        public int SecondaryBranchInfoId { get; set; }
        public BranchInfo SecondaryBranchInfo { get; set; }
        public int ProductInfoId { get; set; }
        public ProductInfo ProductInfo { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}
