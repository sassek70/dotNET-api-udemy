namespace DotnetAPI.Models
{
    public partial class UserSalary  // "partial" allows for model to be added to later if needed
    {
        public int UserId {get; set;}
        public decimal Salary {get; set;}
    }

}