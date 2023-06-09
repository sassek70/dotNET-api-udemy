using System.Text.Json.Serialization;

namespace HelloWorld.Models // <ProjectName.Folder>
{ 
        public class Computer
    {
        /* "public" lets an attribute be accessible in every instance of Computer
            
            -- ERROR: Cannot access due to protection level -> Check public/private setting on attributes & model
            
            Field: a variable of any type that is declared directly in a class or struct

            NOTE:  ADDING A ";" TO THE END OF EACH LINE CREATES A "FIELD" PUBLIC FIELDS SHOULD BE AVOIDED.
            to make a field Private, add two lines, a "getter" and a "setter":


            // DEPRECATED METHOD: 

            private string _motherboard; //creates a private field
            private string Motherboard {get{return _motherboard;} set {_motherboard = value;}} // allows for accessing & modifying the private field


            // CURRENT METHOD:

            private string Motherboard {get; set;} // Creates private field and "setter/getter" at the same time

            // 
        */

        // Use {get; set;} instead of public fields. Some libraries will ignore public fields
        // public string? Motherboard {get; set;} // adding a "?" makes it nullable. not recommended.

        //JSON property attributes can be assigned in the model, the declaration affects the property directly below it.
        [JsonPropertyName("computer_id")]
        public int ComputerId {get; set;}

        [JsonPropertyName("motherboard")]
        public string Motherboard {get; set;} = ""; //sets default value of a string if it is null

        [JsonPropertyName("cpu_cores")]
        public int? CPUCores {get; set;}

        [JsonPropertyName("has_wifi")]
        public bool HasWifi {get; set;}

        [JsonPropertyName("has_lte")]
        public bool HasLTE {get; set;}

        [JsonPropertyName("release_date")]
        public DateTime? ReleaseDate {get; set;}

        [JsonPropertyName("price")]
        public decimal Price {get; set;}

        [JsonPropertyName("video_card")]
        public string VideoCard {get; set;}


        // Alternate: Use a constructor to handle cases where a value can be null, like an empty string

        public Computer()
        {
            if (VideoCard == null)
            {
                VideoCard = "";
            }

            if (Motherboard == null)
            {
                Motherboard = "";
            }            
            if (CPUCores == null)
            {
                CPUCores = 0;
            }
        }

       
    }
}
