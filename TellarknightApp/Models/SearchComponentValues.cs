namespace TellarknightApp.Models
{
    public class SearchComponentValues
    {
        public string SearchQuery { get; set; }
        public string TypeQuery { get; set; }
        public string ArchetypeQuery { get; set; }
        public bool Select { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public List<string> OptionsType { get; set; }

        public SearchComponentValues() 
        {
            SearchQuery = string.Empty;
            TypeQuery = string.Empty;
            ArchetypeQuery = string.Empty;
            Select = true;
            CurrentPage = 1;
            ItemsPerPage = 30;
            TotalItems = 0;

            OptionsType = new List<string>()
            {
                "Monster",
                "Spell",
                "Trap",
            };
        }
    }
}