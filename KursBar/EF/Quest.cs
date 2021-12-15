namespace KursBar.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quest")]
    public partial class Quest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? ID_User { get; set; }

        public int? Приоритет { get; set; }

        public int? НомерКабинета { get; set; }

        public int? ID_ТипПроблемы { get; set; }

        [StringLength(50)]
        public string Филиал { get; set; }

        public int? ID_Оборудования { get; set; }

        public int? СрочностьВыполнения { get; set; }

        [StringLength(50)]
        public string ОписаниеПроблемы { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ДатаПодачи { get; set; }

        public int? ID_Категоричность { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ДатаПринятия { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ДатаЗакрытия { get; set; }

        public virtual Categorical Categorical { get; set; }

        public virtual Hardware Hardware { get; set; }

        public virtual User User { get; set; }

        public virtual TypeOfProblem TypeOfProblem { get; set; }
    }
}
