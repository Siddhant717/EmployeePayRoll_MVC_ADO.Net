using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL:IUserBL
    {
        private readonly IUserRL userRL;

        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public void AddEmp(EmployeeModel employeeModel)
        {
            try
            {
                 this.userRL.AddEmp(employeeModel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        

        public List<EmployeeModel> GetAllEmpDetails()
        {
            try
            {
              return  this.userRL.GetAllEmpDetails();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmployeeModel getDetailsById(int? Id)
        {

            try
            {
                return this.userRL.getDetailsById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteEmp(int? Id)
        {
            try
            {
                return this.userRL.DeleteEmp(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateEmpDetails(EmployeeModel employeeModel)
        {
            try
            {
                return this.userRL.UpdateEmpDetails(employeeModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  }
}
