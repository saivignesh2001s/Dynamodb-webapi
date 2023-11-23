using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Dynamodb_webapi.Models;
using System.Data;
using System.Data.SqlClient;

namespace Dynamodb_webapi.Repository
{
    public class EmpMethods : IEmpMethods
    {
        private readonly IDynamoDBContext _context;
        public EmpMethods(IDynamoDBContext context)
        {
            _context = context;
        }
        public async  Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var emp = await _context.LoadAsync<Employee>(id);
                await _context.DeleteAsync(emp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async  Task<List<Employee>> GetAllEmployees()
        {
          
          
            var employees=await _context.ScanAsync<Employee>(default).GetRemainingAsync();
             return employees;
           
        }
       

        public async Task<Employee> GetEmployeeById(int id)
        {
             var emp = await _context.LoadAsync<Employee>(id);
            return emp;
        }

        public async Task<bool> InsertEmployee(Employee employee)
        {
            try
            {
                await _context.SaveAsync(employee);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateEmployee(int id,Employee employee)
        {
            try
            {
                var emp = await _context.LoadAsync<Employee>(id);
                if (emp!=null)
                {
                    emp.ErrorMessage = employee.ErrorMessage;
                    emp.InsertDate = employee.InsertDate;
                    emp.Request = employee.Request;
                    emp.AccountNumber = employee.AccountNumber;
                    emp.id = employee.id;
                    emp.Name = employee.Name;
                    await _context.SaveAsync(emp);
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch
            {
                return false;
            }
        }
        
    }
}
