/**
 * DataTable implement please refer to: http://datatablesmvc.codeplex.com/ 
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserValidation.Models.POCO;
using UserValidation.Models;
using Datatables.Mvc;

namespace UserValidation.Controllers
{ 
    public class UserManagementController : Controller
    {
        private ValidationDBContext db = new ValidationDBContext();

        //
        // GET: /UserManagement/

        public ViewResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult GetData(Datatables.Mvc.DataTable dataTable)
        {
            List<List<string>> table = new List<List<string>>();
            var users = db.Users.ToList();
            foreach(User user in users)
            {
                List<string> item = new List<string>();
                item.Add(user.Name);
                item.Add(user.Login);
                item.Add(user.Password);
                item.Add(user.Enabled.ToString());
                item.Add(user.Email);

                table.Add(item);
            }
            //Do something with dataTable and fill table    
            return new DataTableResult(dataTable, table.Count, table.Count, table);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}