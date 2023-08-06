namespace ElkoodTask.Models
{
    public class ProductionOperation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int BranchInfoId { get; set; }
        public BranchInfo BranchInfo { get; set; }

        public int ProductInfoId { get; set; }
        public ProductInfo ProductInfo { get; set; }

        public int Quantity { get; set; }
        public int RemainingQuantity { get; set; }
        public DateTime Date { get; set; }
        public ProductionOperation()
        {
            RemainingQuantity = Quantity;
        }
    }
}
