using System;
using System.ComponentModel.DataAnnotations;

namespace LIBs.Domain.Base
{
    public abstract class BaseModel
    {
        [Key]
        public Guid Codigo { get; set; }
    }
}