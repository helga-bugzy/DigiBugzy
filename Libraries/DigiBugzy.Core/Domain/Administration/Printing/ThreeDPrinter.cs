using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBugzy.Core.Domain.Administration.Printing
{
    [Table(name: nameof(ThreeDPrinter), Schema = DatabaseConstants.Schemas.Admin)]
    public class ThreeDPrinter : BaseAdministrationEntity
    {
    }
}
