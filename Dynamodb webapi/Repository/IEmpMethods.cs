using Dynamodb_webapi.Models;
using System.Data;

namespace Dynamodb_webapi.Repository
{
    public interface IEmpMethods
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<bool> InsertEmployee(Employee employee);
        Task<bool> UpdateEmployee(int id,Employee employee);
        Task<bool> DeleteEmployee(int id);
       
    }
}
