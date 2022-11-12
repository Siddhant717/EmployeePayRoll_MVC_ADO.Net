using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        void AddEmp(EmployeeModel employeeModel);
        List<EmployeeModel> GetAllEmpDetails();

        EmployeeModel getDetailsById(int? Id);

        bool DeleteEmp(int ?Id);

        bool UpdateEmpDetails(EmployeeModel employeeModel);
    }
}
