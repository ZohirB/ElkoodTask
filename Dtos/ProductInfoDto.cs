namespace ElkoodTask.Dtos
{
    public class ProductInfoDto
    {
        [MaxLength(length: 100)]
        public string Name { get; set; }
        public int ProductTypeId { get; set; }
    }
}
