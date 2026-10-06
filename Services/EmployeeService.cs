using MyApi.DTOs;
using MyApi.Models;
using MyApi.Repositories;

namespace MyApi.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Employee> CreateAsync(CreateEmployeeDto dto)
    {
        var employee = new Employee
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Department = dto.Department,
            Salary = dto.Salary,
            JoiningDate = dto.JoiningDate,
            IsActive = true
        };

        return await _repository.CreateAsync(employee);
    }

    public async Task<Employee?> UpdateAsync(
        int id,
        UpdateEmployeeDto dto)
    {
        var employee = new Employee
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Department = dto.Department,
            Salary = dto.Salary,
            IsActive = dto.IsActive
        };

        return await _repository.UpdateAsync(id, employee);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}