namespace RegistrarService.Domain.Interfaces
{
    /// <summary>
    /// Child interface of <seealso cref="IEntity"/> with additional properities to track the entities audit trail information
    /// </summary>
    public interface IAuditableEntity
    {
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
