namespace TellarknightApp.Models
{
    public class SearchValues
    {
        public string SearchQuery { get; set; }
        public string TypeQuery { get; set; }
        public string ArchetypeQuery { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }

        public SearchValues() 
        {
            SearchQuery = string.Empty;
            TypeQuery = string.Empty;
            ArchetypeQuery = string.Empty;
            CurrentPage = 1;
            ItemsPerPage = 25;
            TotalItems = 0;
        }
    }
}