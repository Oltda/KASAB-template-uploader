using System.Collections.Generic;


namespace WordTemplateUploader
{

    public class ErrorClass
    {
        public Errors errors { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public string traceId { get; set; }
    }

    public class Errors
    {
        public List<string> Tribe { get; set; }
        public List<string> IsReviewedByTemplateSquad { get; set; }
        public List<string> AIP { get; set; }
     
        public List<string> System { get; set; }
        public List<string> Languages { get; set; }
        public List<string> SystAdmin { get; set; }
     

        public Errors()
        {
            this.Tribe = new List<string>();
            this.IsReviewedByTemplateSquad = new List<string>();
            this.AIP = new List<string>();
            this.System = new List<string>();
            this.Languages = new List<string>();
            this.SystAdmin = new List<string>();
        }
    }

    

}
