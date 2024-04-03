
namespace DannyDefaults.Models
{
    public class EF_Repository : I_Repository
    {
        private Default_Context _defaultContext;
        public EF_Repository(Default_Context temp)
        {
            _defaultContext = temp;
        }

        public IEnumerable<Default_Model> Defaults_table => _defaultContext.Defaults_table;
    }
}