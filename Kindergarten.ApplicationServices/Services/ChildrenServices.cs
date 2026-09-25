using System;
using System.Collections.Generic;
using System.Text;
using Kindergarten.Core.Domain;
using Kindergarten.Core.Dto;
using Kindergarten.Core.ServiceInterface;
using Kindergarten.Data;

namespace Kindergarten.ApplicationServices.Services
{
    public class ChildrenServices : IChildrenServices
    {
        private readonly KindergartenContext _context;

        public ChildrenServices
            (
                KindergartenContext context
            )
        {
            _context = context;
        }

        public async Task<Children> Create(ChildrenDto dto)
        {
            Children domain = new();

            domain.Id = dto.Id;
            domain.GroupName = dto.GroupName;
            domain.ChildrenCount = dto.ChildrenCount;
            domain.KinderGartenName = dto.KinderGartenName;
            domain.TeacherName = dto.TeacherName;
            domain.CreatedAt = dto.CreatedAt;
            domain.UpdatedAt = dto.UpdatedAt;

            await _context.Childrens.AddAsync(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
    }
}
