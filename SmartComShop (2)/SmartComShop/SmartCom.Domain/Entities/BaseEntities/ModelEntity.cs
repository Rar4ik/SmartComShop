using System;
using SmartCom.Domain.Interfaces.BaseInterfaces;

namespace SmartCom.Domain.Entities.BaseEntities
{
    public abstract class ModelEntity : IPerson
    {
        public Guid Id { get; set; }
    }
}
