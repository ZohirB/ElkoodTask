using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElkoodTask.Models
{
    public class BranchInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(length: 100)]
        public string Name { get; set; }
        public int BranchTypeId { get; set; }
        public BranchType BranchType { get; set; }
        public int CompanyInfoId { get; set; }
        public CompanyInfo CompanyInfo { get; set; }

        [MaxLength(length: 100)]
        public string Location { get; set; }

        public ICollection<ProductionOperation> ProductionOperations { get; set; }
        public ICollection<DistributionOperation> DistributionOperations { get; set; }

    }
}
