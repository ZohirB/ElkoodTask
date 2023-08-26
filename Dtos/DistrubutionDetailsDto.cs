namespace ElkoodTask.Dtos;

public class DistrubutionDetailsDto
{
    public int Id { get; set; }
    public string PrimaryBranchInfoName { get; set; }
    public string SecondaryBranchInfoName { get; set; }
    public string ProductInfoName { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
}