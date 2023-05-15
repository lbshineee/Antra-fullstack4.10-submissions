using System;
namespace ApplicationCore.Entities
{
    public class Job
    {
        // PK
        public int Id { get; set; }

        public Guid JobCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public bool? IsActive { get; set; }
        public int NumberOfPositions { get; set; }
        public DateTime? ClosedOn { get; set; }
        public string? ClosedReason { get; set; }
        public DateTime? CreatedOn { get; set; }
        
    }
}

