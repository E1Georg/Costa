using Microsoft.AspNetCore.Mvc;
using Costa.Application.Employees.Queries.GetEmployeeDetails;
using Costa.Application.Employees.Queries.GetEmployeeList;
using Costa.Application.Employees.Commands.CreateEmployee;
using Costa.Application.Employees.Commands.UpdateEmployee;
using Costa.Application.Employees.Commands.DeleteEmployee;
using Costa.Application.Departments.Queries.GetDepartmentList;
using Costa.WebProject.Models.Employee;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Costa.WebProject.Controllers
{
    [Route("api/{controller}/{action}")]
    public class EmployeeController : BaseController
    {
        private readonly IMapper _mapper;
        public EmployeeController(IMapper mapper) => _mapper = mapper;
        public async Task<IActionResult> Index()
        {    
            var vmEmployee = await Mediator.Send(new GetEmployeeListQuery { });
            var vmDepartment = await Mediator.Send(new GetDepartmentListQuery { });          
            var listDepartments = vmDepartment.Departments as List<DepartmentLookupDto>;

            foreach (var item in vmEmployee.Employees)
                item.DepartmentName = listDepartments?.Where(x => x.ID == item.DepartmentID).FirstOrDefault().Name;  

            return View(vmEmployee.Employees.ToList());
        }

        public async Task<IActionResult> Details(uint id)
        {
            var query = new GetEmployeeDetailsQuery { ID = id };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        public async Task<IActionResult> Delete(uint id)
        {
            var query = new GetEmployeeDetailsQuery { ID = id };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]      
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var command = new DeleteEmployeeCommand { ID = id };
            await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }  
        
        public async Task<IActionResult> Create()
        {
            var query = new GetDepartmentListQuery { };
            var vm = await Mediator.Send(query);

            var result = new CreateEmployeeDto();        
            result.Departments = vm.Departments.Select(e => new SelectListItem { Value = e.ID.ToString(), Text = e.Name }).ToList();
            return View(result);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CreateEmployeeDto createEmployeeDto)
        {    
            if (ModelState.IsValid)
            {   
                var command = _mapper.Map<CreateEmployeeCommand>(createEmployeeDto);
                command.ID = uint.MinValue;

                if (createEmployeeDto.ParentDepartmentID_string.Contains("Выберите отдел"))
                {
                    ModelState.AddModelError("", "Выберите отдел для сотрудника");
                    return View(createEmployeeDto);
                }
                else if (Guid.TryParse(createEmployeeDto.ParentDepartmentID_string, out var guid))
                    command.DepartmentID = guid;
                else
                {
                    var tmp = createEmployeeDto.Departments.Where(x => x.Text == createEmployeeDto.ParentDepartmentID_string).First().Value;
                    command.DepartmentID = new Guid(tmp);
                }
                
                var emloyeeId = await Mediator.Send(command);              
                return RedirectToAction(nameof(Index));
            }
            return View(createEmployeeDto);
        }

        public async Task<IActionResult> Edit(uint id)
        {
            var query = new GetEmployeeDetailsQuery { ID = id };
            var vm = await Mediator.Send(query);

            var query2 = new GetDepartmentListQuery { };
            var vm2 = await Mediator.Send(query2);

            var result = _mapper.Map<UpdateEmployeeDto>(vm);
            result.Departments = vm2.Departments.Select(e => new SelectListItem { Value = e.ID.ToString(), Text = e.Name }).ToList();
            return View(result);           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] UpdateEmployeeDto updateEmployeeDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<UpdateEmployeeCommand>(updateEmployeeDto);

                if (updateEmployeeDto.ParentDepartmentID_string.Contains("Выберите отдел"))
                {
                    ModelState.AddModelError("", "Выберите отдел для сотрудника");
                    return View(updateEmployeeDto);
                }
                else if (Guid.TryParse(updateEmployeeDto.ParentDepartmentID_string, out var guid))
                    command.DepartmentID = guid;
                else
                {
                    var tmp = updateEmployeeDto.Departments.Where(x => x.Text == updateEmployeeDto.ParentDepartmentID_string).First().Value;
                    command.DepartmentID = new Guid(tmp);
                }  
                
                await Mediator.Send(command);              
                return RedirectToAction(nameof(Index));
            }
            return View(updateEmployeeDto);
        }

        public async Task<IActionResult> GetEmployeesOfDepartment(Guid DepartmentID)
        {
            var queryEmployee = new GetEmployeeListQuery { ID = uint.MinValue, DepartmentID = DepartmentID };
            var vmEmployee = await Mediator.Send(queryEmployee);

            var queryDepartment = new GetDepartmentListQuery { };
            var vmDepartment = await Mediator.Send(queryDepartment);

            var listDepartments = vmDepartment.Departments as List<DepartmentLookupDto>;

            foreach (var item in vmEmployee.Employees)
                item.DepartmentName = listDepartments?.Where(x => x.ID == item.DepartmentID).FirstOrDefault().Name;

            return View(viewName: nameof(Index), model: vmEmployee.Employees.ToList());
        }
    }
}