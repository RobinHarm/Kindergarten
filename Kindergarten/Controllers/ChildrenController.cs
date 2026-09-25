using Kindergarten.Data;
using Microsoft.AspNetCore.Mvc;
using Kindergarten.Core.ServiceInterface;
using Kindergarten.Models.Children;
using Kindergarten.Core.Domain;
using Kindergarten.Core.Dto;

namespace Kindergarten.Controllers
{
    public class ChildrenController : Controller
    {
        private readonly IChildrenServices _childrenService;
        private readonly KindergartenContext _context;

        public ChildrenController
            (
            IChildrenServices childrenService,
            KindergartenContext context
            )
        {
            _childrenService = childrenService;
            _context = context;
        }

        
        public IActionResult Index()
        {
            var result = _context.Childrens
                .Select(x => new ChildrenIndexViewModel
                {
                    Id = x.Id,
                    GroupName = x.GroupName,
                    ChildrenCount = x.ChildrenCount,
                KinderGartenName = x.KinderGartenName,
                    TeacherName = x.TeacherName,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                });
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChildrenCreateViewModel vm)
        {
            var dto = new ChildrenDto
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KinderGartenName = vm.KinderGartenName,
                TeacherName = vm.TeacherName,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt
            };
            var result = await _childrenService.Create(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var children = await _childrenService.DetailsAsync(id);

            if (children == null)
            {
                return NotFound();
            }

            var vm = new ChildrenDetailsViewModel();

            vm.Id = children.Id;
            vm.GroupName = children.GroupName;
            vm.ChildrenCount = children.ChildrenCount;
            vm.KinderGartenName = children.KinderGartenName;
            vm.TeacherName = children.TeacherName;
            vm.CreatedAt = children.CreatedAt;
            vm.UpdatedAt = children.UpdatedAt;
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid Id)
        {
            var children = await _childrenService.DetailsAsync(Id);

            if (children == null)
            {
                return NotFound();
            }

            var vm = new ChildrenUpdateViewModel();

            vm.Id = children.Id;
            vm.GroupName = children.GroupName;
            vm.ChildrenCount = children.ChildrenCount;
            vm.KinderGartenName = children.KinderGartenName;
            vm.TeacherName = children.TeacherName;
            vm.CreatedAt = children.CreatedAt;
            vm.UpdatedAt = children.UpdatedAt;
            
            return View(vm);
        }

        
    }
}
