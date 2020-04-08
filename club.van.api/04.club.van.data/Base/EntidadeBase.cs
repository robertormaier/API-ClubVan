using System;

namespace club.van.api.data.Base
{
    public abstract class EntidadeBase 
    {
        protected EntidadeBase()
        {
            Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; set; }
    }
}
