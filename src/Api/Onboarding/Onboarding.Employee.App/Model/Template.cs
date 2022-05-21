namespace Onboarding.Employee.App.Model
{
    public class Template
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Step> Steps { get; set; } = new();
    }

    public class Step
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string ApprovedBy { get; set; }
    }
}
