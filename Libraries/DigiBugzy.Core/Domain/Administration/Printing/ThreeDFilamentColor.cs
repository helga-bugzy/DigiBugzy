using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBugzy.Core.Domain.Administration.Printing
{
    [Table(name: nameof(ThreeDFilamentColor), Schema = DatabaseConstants.Schemas.Admin)]
    public class ThreeDFilamentColor : BaseAdministrationEntity
    {
    }
}
