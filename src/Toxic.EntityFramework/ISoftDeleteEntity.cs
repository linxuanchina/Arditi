using System;

namespace Toxic.EntityFramework
{
    public interface ISoftDeleteEntity
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}