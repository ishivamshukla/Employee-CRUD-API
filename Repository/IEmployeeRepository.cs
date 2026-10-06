using MyApi.Models;

namespace MyApi.Repositories;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllAsync();

    Task<Employee?> GetByIdAsync(int id);

    Task<Employee> CreateAsync(Employee employee);

    Task<Employee?> UpdateAsync(int id, Employee employee);

    Task<bool> DeleteAsync(int id);
}