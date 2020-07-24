using System;

namespace Toxic.EntityFramework
{
    public interface IAuditEntity
    {
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}