namespace DotnetAPI.DTO
{
    public partial class UserDetailsDTO  // "partial" allows for model to be added to later if needed -- typically singular
    {
        public string FirstName {get; set;} = "";
        public string LastName {get; set;} = "";
        public string Email{get; set;} = "";
        public string Gender{get; set;} = "";
        public decimal Salary {get; set;}
        public bool Active {get; set;}
    }

}