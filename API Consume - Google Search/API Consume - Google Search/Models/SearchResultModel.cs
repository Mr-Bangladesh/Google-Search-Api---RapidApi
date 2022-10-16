using System.Collections.Generic;

namespace API_Consume___Google_Search.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class AdditionalLink
    {
        public string Text { get; set; }
        public string Href { get; set; }
    }

    public class Cite
    {
        public string Domain { get; set; }
        public string Span { get; set; }
    }

    public class Result
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public List<AdditionalLink> AdditionalLinks { get; set; }
        public Cite Cite { get; set; }
        public string GReviewStars { get; set; }
    }

    public class SearchResultModel
    {
        public List<Result> Results { get; set; }
        public List<object> ImageResults { get; set; }
        public int Total { get; set; }
        public List<object> Answers { get; set; }
        public double Ts { get; set; }
        public object DeviceType { get; set; }
    }


}
