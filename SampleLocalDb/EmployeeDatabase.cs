using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace SampleLocalDb
{
    public class EmployeeDatabase
    {
        readonly SQLiteAsyncConnection database;

        public EmployeeDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Employee>().Wait();
        }

        public Task<List<Employee>> GetEmployeesAsync()
        {
            return database.Table<Employee>().ToListAsync();
        }

        public Task<Employee> GetEmployeeAsync(int id)
        {
            return database.Table<Employee>().Where(i => i.EmpId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveEmployeeAsync(Employee employee)
        {
            if (employee.EmpId == 0)
            {
                return database.InsertAsync(employee);
            }else{
                return database.UpdateAsync(employee);
            }
        }

        public Task<int> DeleteEmployeeAsync(Employee employee)
        {
            return database.DeleteAsync(employee);
        }

    }
}
