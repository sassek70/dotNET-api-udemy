namespace DotnetAPI
{
    public partial class Users  // "partial" allows for model to be added to later if needed
    {
        public int UserId {get; set;}
        public string FirstName {get; set;} = "";
        public string LastName {get; set;} = "";
        public string Email{get; set;} = "";
        public string Gender{get; set;} = "";
        public bool Active {get; set;}
    }

}