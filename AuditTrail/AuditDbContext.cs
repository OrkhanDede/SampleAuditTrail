using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace AuditTrail
{
    public class AuditDbContext:DbContext
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options)
            : base(options)
        {

        }
        public DbSet<AuditTrail> AuditTrails { get; set; }
    }

    public class AuditTrail
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string TableName { get; set; }
        public DateTime DateTime { get; set; }
        [Column(TypeName = "json")]
        public string OldValues { get; set; }
        [Column(TypeName = "json")]
        public string NewValues { get; set; }
        public string Uuid { get; set; }
        public string AffectedColumns { get; set; }
        public AuditType AuditType { get; set; }
    }
    public enum AuditType
    {
        Create = 1,
        Update,
        Delete
    }
    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }
        public EntityEntry Entry { get; }
        public string UserId { get; set; }
        public string TableName { get; set; }
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public AuditType AuditType { get; set; }
        public Dictionary<string, object> ChangedColumns { get; } = new Dictionary<string, object>();
        public string Uuid { get; set; }
        public AuditTrail ToAudit()
        {
            var audit = new AuditTrail();
            audit.UserId = UserId;
            audit.AuditType = AuditType;
            audit.TableName = TableName;
            audit.DateTime = DateTime.UtcNow;
            audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            audit.Uuid = Uuid;
            audit.AffectedColumns = ChangedColumns.Count == 0 ? null : JsonConvert.SerializeObject(ChangedColumns);
            return audit;
        }
    }
}
