namespace ElkoodTask.Dtos
{
    public class BranchInfoDto
    {
        [MaxLength(length: 100)]
        public string Name { get; set; }

        public int BranchTypeId { get; set; }

        public int CompanyInfoId { get; set; }

        [MaxLength(length: 100)]
        public string Location { get; set; }
    }
}
