using System;
using SQLite;
namespace SampleLocalDb
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int EmpId{
            get;
            set;
        }

        public string EmpName{
            get;
            set;
        }

        public string EmpDesignation{
            get;
            set;
        }

        public string Email{
            get;
            set;
        }
    }
}
