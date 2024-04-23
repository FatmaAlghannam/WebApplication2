//using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WebApplication2.Migrations;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{

    public class BankController : Controller
    {
        private readonly BankContext _bankContext;
        // NEW code _bankContext is the injection :we place it all in >
        public BankController(BankContext Context)
        {
            _bankContext = Context;
        }

        private static List<BankBranches> branchlist = new List<BankBranches>()
    {
        new BankBranches{  LocationName =" Kaifan", Id = 1 , Branchmanger ="Abdulla", EmployeeCount = 75,LocationURL= "https://maps.app.goo.gl/i2xcu2BxyHR152iZ8"},
        new BankBranches{  LocationName =" Abdulla Alsalem", Id = 2 , Branchmanger ="Bader", EmployeeCount = 47,LocationURL= "https://maps.app.goo.gl/fbvbF41AFJs3JZ6J7"},
        new BankBranches{  LocationName =" Faiha", Id = 3 , Branchmanger ="Fahad", EmployeeCount = 102,LocationURL= "https://maps.app.goo.gl/3ZUSNJKMzzDdpDvS8"},


    };

        public IActionResult Index()
        {
            using (_bankContext)
            {
                var viewModel =new BankDashBoardViewModel();
                viewModel.BranchList = _bankContext.BankBranches.ToList();
                viewModel.TotalBranch = _bankContext.BankBranches.Count();
                viewModel.TotalEmployee = _bankContext.BankBranches.Count();
                //ecute siqul query :
                viewModel.BranchWithMostEmployees = _bankContext.BankBranches
                    .OrderByDescending(b => b.Employees.Count)
                    .FirstOrDefault();


                return View(viewModel);

                //var banks = 
                //return View(banks);
            }
            return View(branchlist);
        }
        public IActionResult Create(string LocationName)
        {
            List<BankBranches> branchlist = new List<BankBranches>()
            {
            new BankBranches() {
                LocationName = "Kaifan",
                LocationURL="https://maps.app.goo.gl/i2xcu2BxyHR152iZ8",
                Id =3 ,
                Branchmanger ="Bader",
                EmployeeCount= 72

            }, };

            var bankBranch = branchlist.SingleOrDefault(a => a.LocationName == LocationName);
            if (bankBranch == null)
            {
                return RedirectToAction("Index");
            }
            return View(bankBranch);

        }

        // [HttpPost]
        //     public IActionResult Create(NewBranchForm model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var name = model.LocationName;
        //        var branchManager = model.Branchmanger;
        //        var id = model.Id;
        //        var location = model.LocationURL;

        //        var branch = new BankBranches();
        //        branch.LocationName = name;
        //        branch.Branchmanger = branchManager;
        //        branch.Id = id ;
        //        branch.LocationURL = location;

        //        branchlist.Add(branch);
        //        using (var context = new BankContext())
        //        {
        //            context.BankBranches.Add(branch);
        //            context.SaveChanges();
        //        }



        //        return RedirectToAction("Index");

        //    }

        //    return View("Create", model);

        //}


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(NewBranchForm form)
        {

            var locationname = form.LocationName;
            var branchmanger = form.Branchmanger;
            var locationUrl = form.LocationURL;
            var id = form.Id;
            var employeeCount = form.EmployeeCount;


            var newBank = new BankBranches();
            newBank.LocationName = locationname;
            newBank.LocationURL = locationUrl;
            newBank.Branchmanger = branchmanger;
            newBank.EmployeeCount = employeeCount;

            var DbContext = _bankContext;
            DbContext.BankBranches.Add(newBank);
            DbContext.SaveChanges();


            return RedirectToAction("Index");

        }

        public IActionResult Details(int id)
        {
            var db = _bankContext;
            var bankBranches = db.BankBranches.SingleOrDefault(b => b.Id == id);
            //var bankBranch = branchlist.SingleOrDefault(b => b.Id == id);
            if (bankBranches == null)
            {
                return RedirectToAction("Index");
            }
            return View(bankBranches);

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var db = _bankContext;
            var bankBranch = db.BankBranches.Find(id);
            if (bankBranch == null)
            {
                return RedirectToAction("Index");
            }
            var myForm = new NewBranchForm();
            myForm.LocationName = bankBranch.LocationName;
            myForm.LocationURL = bankBranch.LocationURL;
            myForm.Branchmanger = bankBranch.Branchmanger;
            myForm.EmployeeCount = bankBranch.EmployeeCount;

            return View(myForm);





        }
        [HttpPost]
        public IActionResult Edit(int id, NewBranchForm form)
        {
            if (ModelState.IsValid)
            {

                var db = _bankContext;
                var bankBranch = db.BankBranches.Find(id);
                bankBranch.LocationName = form.LocationName;
                bankBranch.LocationURL = form.LocationURL;
                bankBranch.Branchmanger = form.Branchmanger;
                bankBranch.EmployeeCount = form.EmployeeCount;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.View();
        }


        [HttpGet]
        public IActionResult AddNewEmployee(int id)
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddNewEmployee(int id, AddNewEmployee form)
        {
            if (!ModelState.IsValid)
            {
                var db = _bankContext;
                var bankBranches = db.BankBranches.Include(r => r.Employees).SingleOrDefault(v=> v.Id == id);
                var newEmployee = new Employee();


                newEmployee.Name = form.Name;
                newEmployee.Position = form.Position;
                newEmployee.CivilID = form.CivilID;
                bankBranches.Employees.Add(newEmployee);

                db.SaveChanges();

            }
            return View("Thanks");
        }



    }
}
    
    




       