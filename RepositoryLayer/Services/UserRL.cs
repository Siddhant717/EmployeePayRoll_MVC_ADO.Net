using CommonLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL:IUserRL
    {
        private readonly IConfiguration configuration;
        public UserRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void AddEmp(EmployeeModel employeeModel)
        {
            SqlConnection connection = new SqlConnection(configuration["ConnectionStrings:Employee"]);
            try
            {

                SqlCommand com = new SqlCommand("sp_AddEmployee", connection);
                com.CommandType = System.Data.CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@Name", employeeModel.Name);
                com.Parameters.AddWithValue("@ProfImg", employeeModel.ProfImg);
                com.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                com.Parameters.AddWithValue("@Department", employeeModel.Department);
                com.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                com.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);

                connection.Open();
                var reader = com.ExecuteNonQuery();
                connection.Close();

             
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

     

        public List<EmployeeModel> GetAllEmpDetails()
        {
            SqlConnection connection = new SqlConnection(configuration["ConnectionStrings:Employee"]);
            try
            {

                SqlCommand com = new SqlCommand("sp_getAllEmp", connection);
                com.CommandType = System.Data.CommandType.StoredProcedure;



                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                List<EmployeeModel> employees = new List<EmployeeModel>();
                while (reader.Read())
                {
                    var emp = new EmployeeModel();
                    emp.Id = reader.GetInt32(0);
                    emp.Name = reader.GetString(1);
                    emp.ProfImg = reader.GetString(2);
                    emp.Gender = reader.GetString(3);
                    emp.Department = reader.GetString(4);
                    emp.Salary = (int)reader.GetDecimal(5);
                    emp.StartDate = reader.GetDateTime(6);

                    employees.Add(emp);
                }

                connection.Close();
                return employees;


            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public EmployeeModel getDetailsById(int? Id)
        {
            SqlConnection connection = new SqlConnection(configuration["ConnectionStrings:Employee"]);
            try
            {
                EmployeeModel emp = new EmployeeModel();

                SqlCommand com = new SqlCommand("sp_getDetailsbyId", connection);
                com.CommandType = System.Data.CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@Id",Id);

                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
               
                while (reader.Read())
                {
                    emp.Id = reader.GetInt32(0);
                    emp.Name = reader.GetString(1);
                    emp.ProfImg = reader.GetString(2);
                    emp.Gender = reader.GetString(3);
                    emp.Department = reader.GetString(4);
                    emp.Salary = (int)reader.GetDecimal(5);
                    emp.StartDate = reader.GetDateTime(6);

                   
                }

                connection.Close();
                return emp;


            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool DeleteEmp(int ?Id)
        {
            SqlConnection connection = new SqlConnection(configuration["ConnectionStrings:Employee"]);
            try
            {

                SqlCommand com = new SqlCommand("sp_DeleteEmp", connection);
                com.CommandType = System.Data.CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@Id", Id);
               
                connection.Open();
                var reader = com.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool UpdateEmpDetails(EmployeeModel employeeModel)
        {
            SqlConnection connection = new SqlConnection(configuration["ConnectionStrings:Employee"]);
            try
            {

                SqlCommand com = new SqlCommand("sp_UpdateDetails", connection);
                com.CommandType = System.Data.CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@Id", employeeModel.Id);
                com.Parameters.AddWithValue("@Name", employeeModel.Name);
                com.Parameters.AddWithValue("@ProfImg", employeeModel.ProfImg);
                com.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                com.Parameters.AddWithValue("@Department", employeeModel.Department);
                com.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                com.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);

                connection.Open();
                var reader = com.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
