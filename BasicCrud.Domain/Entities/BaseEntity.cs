namespace BasicCrud.Domain.Entities
{
    public class BaseEntity
    {
        public DateTime? CreatedDate { get; set; }

        public string? CreatedByUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedByUserId { get; set; }

        public DateTime? DeletedDate { get; set; }

        public string? DeletedByUserId { get; set; }
    }
}
