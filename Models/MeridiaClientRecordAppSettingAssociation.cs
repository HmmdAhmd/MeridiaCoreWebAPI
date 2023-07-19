using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class MeridiaClientRecordAppSettingAssociation
    {
        [Key]
        public int MeridiaClientRecordAppSettingAssociationId { get; set; }
        [ForeignKey("AppSetting")]
        public int AppSettingId { get; set; }
        [ForeignKey("MeridiaClientRecord")]
        public int MeridiaClientRecordId { get; set; }
        public string Value { get; set; }
        public virtual AppSetting AppSetting { get; set; }
        public virtual MeridiaClientRecord MeridiaClientRecord { get; set; }
    }
}
