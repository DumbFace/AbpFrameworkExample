using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookStore.Tests
{
    public class Test : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
    }
}