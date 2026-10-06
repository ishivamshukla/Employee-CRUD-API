using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models;

namespace MyApi.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _context.Employees
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _context.Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Employee> CreateAsync(Employee employee)
    {
        _context.Employees.Add(employee);

        await _context.SaveChangesAsync();

        return employee;
    }

    public async Task<Employee?> UpdateAsync(
        int id,
        Employee employee)
    {
        var existingEmployee = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == id);

        if (existingEmployee == null)
        {
            return null;
        }

        existingEmployee.FirstName = employee.FirstName;
        existingEmployee.LastName = employee.LastName;
        existingEmployee.Email = employee.Email;
        existingEmployee.Department = employee.Department;
        existingEmployee.Salary = employee.Salary;
        existingEmployee.IsActive = employee.IsActive;

        await _context.SaveChangesAsync();

        return existingEmployee;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == id);

        if (employee == null)
        {
            return false;
        }

        _context.Employees.Remove(employee);

        await _context.SaveChangesAsync();

        return true;
    }
}