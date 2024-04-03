using DannyDefaults.Models.ViewModels;

namespace DannyDefaults.Models.ViewModels
{
    public class DefaultListViewModel
    {
        public IEnumerable<Default_Model> Defaults_table { get; set;}
        public PaginationInfo PaginationInfo { get; set;} = new PaginationInfo();
        public string? CurrentDefaultLetter { get; set;}
    }
}