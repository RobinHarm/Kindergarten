using Kindergarten.Core.Domain;
using Kindergarten.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarten.Core.ServiceInterface
{
    public interface IChildrenServices
    {
        Task<Children> Create(ChildrenDto dto);
        Task<Children> DetailsAsync(Guid id);
        Task<Children> Update(ChildrenDto dto);
    }
}
