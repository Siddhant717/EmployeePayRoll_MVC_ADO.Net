using BusinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmpPayRollMVC.Controllers
{
    
   
    public class EmployeeController : Controller
    {
        IUserBL userBL;
        public EmployeeController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpGet]
        
        public IActionResult Index()
        {
            List<EmployeeModel> model = new List<EmployeeModel>();
            model = userBL.GetAllEmpDetails();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
        
            
            return View();
        }
        
        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                userBL.AddEmp(employeeModel);
                return RedirectToAction("Index");
            }
            return View(employeeModel);
        
        }

    
        [HttpGet]
        public IActionResult getDetailsById(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = userBL.getDetailsById(Id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);

        }
        [HttpGet]
        public IActionResult DeleteEmp(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = userBL.getDetailsById(Id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);

        }
        [HttpPost,ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
           
            userBL.DeleteEmp(Id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateEmpDetails(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = userBL.getDetailsById(Id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult UpdateEmpDetails(int? Id,EmployeeModel employeeModel)
        {
            if (Id != employeeModel.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                userBL.UpdateEmpDetails(employeeModel);
                return RedirectToAction("Index");


            }
            return View(employeeModel);
        }

    }
}
