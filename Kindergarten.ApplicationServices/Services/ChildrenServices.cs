using System;
using System.Collections.Generic;
using System.Text;
using Kindergarten.Core.Domain;
using Kindergarten.Core.Dto;
using Kindergarten.Core.ServiceInterface;
using Kindergarten.Data;
using Microsoft.EntityFrameworkCore;

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
            domain.CreatedAt = DateTime.Now;
            domain.UpdatedAt = dto.UpdatedAt;

            await _context.Childrens.AddAsync(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<Children> DetailsAsync(Guid id)
        {
            var result = await _context.Childrens
                .FirstOrDefaultAsync(x => x.Id == id);
            
            return result;
        }
        public async Task<Children> Update(ChildrenDto dto)
        {
            Children children = new();
            children.Id = dto.Id;
            children.GroupName = dto.GroupName;
            children.ChildrenCount = dto.ChildrenCount;
            children.KinderGartenName = dto.KinderGartenName;
            children.TeacherName = dto.TeacherName;
            children.CreatedAt = DateTime.Now;
            children.UpdatedAt = dto.UpdatedAt;

            _context.Childrens.Update(children);
            await _context.SaveChangesAsync();
            return children;
        }
    }
}
