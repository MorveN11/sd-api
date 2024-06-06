namespace Project.DataAccess.Entities.Interfaces
{
    public interface IBaseEntityRelation<T> : IBaseEntity
        where T : class, IBaseEntity, new()
    {
        public IList<T> Relations { get; set; }
    }
}
