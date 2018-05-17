namespace LegacySessionManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SessionState")]
    public partial class SessionState
    {
        [Key]
        [StringLength(100)]
        public string SessionId { get; set; }

        [Column(TypeName = "image")]
        public byte[] SessionDictionary { get; set; }

        public DateTime LastAccessed { get; set; }
    }
}
