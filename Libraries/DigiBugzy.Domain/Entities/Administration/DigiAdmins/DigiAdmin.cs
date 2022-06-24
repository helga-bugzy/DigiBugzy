

namespace DigiBugzy.Domain.Entities.Administration.DigiAdmins
{
    public abstract class DigiAdmin: BaseDigiAdminEntity
    {
        public string Name { get; set; }

        public List<Bugzer> Bugzers { get; set; }
    }
}
