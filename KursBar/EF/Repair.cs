namespace KursBar.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Repair")]
    public partial class Repair
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Repair()
        {
            Hardware = new HashSet<Hardware>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? ID_Сотрудники_ИТ { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ДатаПоследнегоРемонта { get; set; }

        [StringLength(50)]
        public string КоличествоРемонтов { get; set; }

        [StringLength(50)]
        public string ПричинаРемонта { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hardware> Hardware { get; set; }

        public virtual IT_Employees IT_Employees { get; set; }
    }
}
