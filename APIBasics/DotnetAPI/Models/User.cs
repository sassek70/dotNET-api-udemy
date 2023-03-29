namespace DotnetAPI.Models
{
    public partial class User  // "partial" allows for model to be added to later if needed -- typically singular
    {
        public int UserId {get; set;}
        public string FirstName {get; set;} = "";
        public string LastName {get; set;} = "";
        public string Email{get; set;} = "";
        public string Gender{get; set;} = "";
        public bool Active {get; set;}

        public UserSalary? salary {get; set;}
        // public UserJobInfo? Department {get; set;}
        // public UserJobInfo? JobTitle {get; set;}

    }

}