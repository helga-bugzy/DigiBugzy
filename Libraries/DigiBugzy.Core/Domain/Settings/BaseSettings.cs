

using DigiBugzy.Core.Domain.Administration.DigiAdmins;

namespace DigiBugzy.Core.Domain.Settings
{
   
    public class BaseSettings
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        
        public int DigiAdminId { get; set; }

        public bool AllowSettingOverrides { get; set; }

        public bool ApplyAutomationDown { get; set; }

        public bool ApplyAutomationUp { get; set; }


        [ForeignKey(nameof(DigiAdminId))]
        public DigiAdmin DigiAdmin { get; set; }
    }
}
