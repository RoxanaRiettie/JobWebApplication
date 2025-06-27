namespace JobWebApplication.Domain
{
    public class JobPosition
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Status { get; set; } // e.g., Open, Closed, Pending
        public int RecruiterId { get; set; } // Foreign key to Recruiter
        public int DepartmentId { get; set; } // Foreign key to Department
        public double Budget { get; set; }
        public DateTime? ClosingDate { get; set; }
    }
}
