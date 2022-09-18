using System.Web.Mvc;
using CrudOperationUsingDapperWihtjQueryJson.Models;
using CrudOperationUsingDapperWihtjQueryJson.Repository;

namespace CrudOperationUsingDapperWihtjQueryJson.Controllers
{
    public class HomeController : Controller
    {

        public JsonResult GetEmpDetails()
        {
            EmpRepository EmpRepo = new EmpRepository();
            return Json(EmpRepo.GetAllEmployees(),JsonRequestBehavior.AllowGet);

        }
      
        public ActionResult AddEmployee()
        {

           
            return View();
        }
        public ActionResult Edit(int?id)
        {
            EmpRepository EmpRepo = new EmpRepository();
            return View(EmpRepo.GetAllEmployees().Find(Emp => Emp.Id == id));
        }
      
        [HttpPost]
        public JsonResult AddEmployee(EmpModel EmpDet)

        {          
            try
            {
              
                EmpRepository EmpRepo = new EmpRepository();
                EmpRepo.AddEmployee(EmpDet);
                return Json("Records added Successfully.");
            
            }
            catch
            {
                return Json("An Error Has occoured while adding records..");
            }
        }

     
        [HttpPost]
        public JsonResult Delete(int id)
        {           
            EmpRepository EmpRepo = new EmpRepository();
            EmpRepo.DeleteEmployee(id);
           return Json("Records deleted successfully.", JsonRequestBehavior.AllowGet);
        }
     
        [HttpPost]     
        public JsonResult Edit(EmpModel EmpUpdateDet)
        {        
            EmpRepository EmpRepo = new EmpRepository();
            EmpRepo.UpdateEmployee(EmpUpdateDet);
            return Json("Records updated successfully.", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public PartialViewResult EmployeeDetails()
        {

            return PartialView("_EmployeeDetails");

        }
    }
}
