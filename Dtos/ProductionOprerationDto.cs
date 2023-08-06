namespace ElkoodTask.Dtos
{
    public class ProductionOprerationDto
    {
        public int Id { get; set; }
        public int BranchInfoId { get; set; }
        public int ProductInfoId { get; set; }
        public int quantity { get; set; }
        public DateTime date { get; set; }
    }
}
