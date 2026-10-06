using Microsoft.AspNetCore.Mvc;
using MyApi.DTOs;
using MyApi.Services;

namespace MyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }

    // GET: api/employee
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _service.GetAllAsync();

        return Ok(employees);
    }

    // GET: api/employee/1
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var employee = await _service.GetByIdAsync(id);

        if (employee == null)
        {
            return NotFound(new
            {
                message = "Employee not found"
            });
        }

        return Ok(employee);
    }

    // POST: api/employee
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateEmployeeDto dto)
    {
        var employee = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = employee.Id },
            employee
        );
    }

    // PUT: api/employee/1
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateEmployeeDto dto)
    {
        var employee = await _service.UpdateAsync(id, dto);

        if (employee == null)
        {
            return NotFound(new
            {
                message = "Employee not found"
            });
        }

        return Ok(employee);
    }

    // DELETE: api/employee/1
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound(new
            {
                message = "Employee not found"
            });
        }

        return NoContent();
    }
}
