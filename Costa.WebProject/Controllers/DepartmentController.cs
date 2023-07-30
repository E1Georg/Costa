using Microsoft.AspNetCore.Mvc;
using Costa.Application.Departments.Queries.GetDepartmentDetails;
using Costa.Application.Departments.Queries.GetDepartmentList;
using Costa.Application.Departments.Commands.CreateDepartment;
using Costa.Application.Departments.Commands.UpdateDepartment;
using Costa.Application.Departments.Commands.DeleteDepartment;
using Costa.WebProject.Models.Department;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Costa.WebProject.Controllers
{
    [Route("api/{controller}/{action}")]
    public class DepartmentController : BaseController
    {
        private readonly IMapper _mapper;
        public DepartmentController(IMapper mapper) => _mapper = mapper;

        public async Task<IActionResult> Index()
        {
            var query = new GetDepartmentListQuery { };
            var vm = await Mediator.Send(query);           
            return View(vm.Departments.ToList());
        }

        public async Task<IActionResult> Create()
        {
            var query = new GetDepartmentListQuery { };
            var vm = await Mediator.Send(query);

            var result = new CreateDepartmentDto();
            result.Departments = vm.Departments.Select(e => new SelectListItem { Value = e.ID.ToString(), Text = e.Name }).ToList();           
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CreateDepartmentDto createDepartmentDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<CreateDepartmentCommand>(createDepartmentDto);
                command.ID = Id; 
              
                if (!createDepartmentDto.ParentDepartmentID_string.Contains("Выберите отдел"))
                    command.ParentDepartmentID = new Guid(createDepartmentDto.ParentDepartmentID_string);               

                var departmentId = await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(createDepartmentDto);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var query = new GetDepartmentDetailsQuery { ID = id };
            var vm = await Mediator.Send(query);

            var query2 = new GetDepartmentListQuery { };
            var vm2 = await Mediator.Send(query2);

            var result = _mapper.Map<UpdateDepartmentDto>(vm);
            result.Departments = vm2.Departments.Select(e => new SelectListItem { Value = e.ID.ToString(), Text = e.Name }).ToList();
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] UpdateDepartmentDto updateDepartmentDto)
        {     
            if (ModelState.IsValid)
            {
                if (updateDepartmentDto.ParentDepartmentID_string.Contains(updateDepartmentDto.ID.ToString()))
                {
                    ModelState.AddModelError("", "Отдел не может быть вложен сам в себя");
                    return View(updateDepartmentDto);
                }              

                var command = _mapper.Map<UpdateDepartmentCommand>(updateDepartmentDto);
                               
                if (updateDepartmentDto.ParentDepartmentID_string.Contains("Выберите отдел"))
                    command.ParentDepartmentID = null;
                else if (!Guid.TryParse(updateDepartmentDto.ParentDepartmentID_string, out _))
                {                   
                    var tmp = updateDepartmentDto.Departments.Where(x => x.Text == updateDepartmentDto.ParentDepartmentID_string).First();
                    command.ParentDepartmentID = new Guid(tmp.Value);
                }
                else
                    command.ParentDepartmentID = new Guid(updateDepartmentDto.ParentDepartmentID_string);

                await Mediator.Send(command);           
                return RedirectToAction(nameof(Index));
            }
            return View(updateDepartmentDto);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var query = new GetDepartmentDetailsQuery { ID = id };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new GetDepartmentDetailsQuery { ID = id };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var command = new DeleteDepartmentCommand { ID = id };
            await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetEmployees(Guid id)
        {   
            return RedirectToAction(actionName: "GetEmployeesOfDepartment", controllerName: "Employee", new { DepartmentID = id });
        }   
    }
}
