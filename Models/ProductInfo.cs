namespace ElkoodTask.Models;

public class ProductInfo
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(100)] public string Name { get; set; }

    public int ProductTypeId { get; set; }
    public ProductType ProductType { get; set; }

    public ICollection<ProductionOperation> ProductionOperations { get; set; }
    public ICollection<DistributionOperation> DistributionOperations { get; set; }
}