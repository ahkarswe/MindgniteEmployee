using System.Security.Principal;

namespace MindgniteEmployee.Models
{
    public class MindgniteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? NRC_Number { get; set; }
        public DateTime? JoinDate { get; set; }
        public int? EmployeeNo { get; set; }
        public string? Address { get; set; }
        public string City { get; set; }
    }
}
