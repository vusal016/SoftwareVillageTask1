namespace Weather.CORE.Entities.Common
{
    public class BaseEntity
    {
        protected BaseEntity() : this(Guid.NewGuid())
        {

        }
        protected BaseEntity(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id can't be empty");
            Id = id;
        }
        public Guid Id { get; init; }
    }
}
