using MyApi.DTOs;
using MyApi.Models;

namespace MyApi.Services;

public interface IEmployeeService
{
    Task<List<Employee>> GetAllAsync();

    Task<Employee?> GetByIdAsync(int id);

    Task<Employee> CreateAsync(CreateEmployeeDto dto);

    Task<Employee?> UpdateAsync(
        int id,
        UpdateEmployeeDto dto);

    Task<bool> DeleteAsync(int id);
}