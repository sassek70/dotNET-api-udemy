namespace DotnetAPI.Models
{
    public partial class UserJobInfo  // "partial" allows for model to be added to later if needed
    {
        public int UserId {get; set;}
        public string JobTitle {get; set;} = "";
        public string Department {get; set;} = "";
        // public User? User {get; set;}

    }

}