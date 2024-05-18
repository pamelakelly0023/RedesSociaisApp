using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedesSociaisApp.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;   
        }
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public bool IsDeleted { get; private set; }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}