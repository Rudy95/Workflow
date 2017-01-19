namespace Workflow_Models.Models
{
    public class Department: BaseClassId
    {
        public string Name { get; set; }

        public User User { get; set; }
    }
}