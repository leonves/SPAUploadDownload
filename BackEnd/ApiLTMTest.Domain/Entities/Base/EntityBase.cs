using System;

namespace ApiLTMTest.Domain.Entities
{
    public class EntityBase<TType>
    {
        public EntityBase()
        {
            CreationDate = DateTime.Now;
            Active = true;
        }

        public TType ID { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ModificationDate { get; set; }

        public bool Active { get; set; }
    }
}
