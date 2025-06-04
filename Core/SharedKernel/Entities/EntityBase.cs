namespace Core.SharedKernel.Entity
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get;set; }
        public DateTime? UpdatedAt { get;set; }
        public DateTime? DeletedAt { get;set; }
        public bool IsDeleted { get; private set; }


        // Soft-delete: colocar na func do rep generico
        public void MarkDeleted()
        {
            if (IsDeleted) return;
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }
    }
}
