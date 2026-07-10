namespace LawnGardenManagement.Domain.Common;

public abstract class AuditableEntity : BaseEntity
{
    public DateTimeOffset CreatedAtUtc { get; protected set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset? UpdatedAtUtc { get; protected set; }

    protected void MarkAsUpdated()
    {
        UpdatedAtUtc = DateTimeOffset.UtcNow;
    }
}