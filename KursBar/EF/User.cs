namespace KursBar.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Autorization = new HashSet<Autorization>();
            Quest = new HashSet<Quest>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string ФИО { get; set; }

        public int ID_Office { get; set; }

        [Required]
        [StringLength(50)]
        public string Роль { get; set; }

        [StringLength(50)]
        public string Дата_Рождения { get; set; }

        [StringLength(50)]
        public string Почта { get; set; }

        [StringLength(10)]
        public string Пол { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autorization> Autorization { get; set; }

        public virtual Office Office { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quest> Quest { get; set; }
    }
}
