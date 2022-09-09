using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBugzy.Core.Domain.Finance.Budgets
{
    [Table(name:nameof(Budget), Schema = DatabaseConstants.Schemas.Finance)]
    public class Budget: BaseAdministrationEntity
    {
        public int BudgetYear { get; set; }

        public int BudgetMonth { get; set; }

        public decimal TotalIncome { get; set; }

        public decimal TotalExpenses { get; set; }

        public decimal TotalVariance { get; set; }


    }
}
