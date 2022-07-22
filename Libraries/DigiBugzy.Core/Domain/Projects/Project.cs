using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBugzy.Core.Domain.Projects
{
    [Table(name: nameof(Project), Schema = DatabaseConstants.Schemas.Catalog)]
    public class Project : BaseAdministrationEntity
    {

    }
}
