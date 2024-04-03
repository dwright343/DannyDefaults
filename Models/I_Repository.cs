namespace DannyDefaults.Models
{
    public interface I_Repository
    {
        IEnumerable<Default_Model> Defaults_table { get; }
    }
}
