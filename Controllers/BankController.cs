using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{

    public class BankController : Controller
    {
        private static List<BankBranches> branchlist = new List<BankBranches>()
    {
        new BankBranches{  LocationName =" Kaifan", Id = 1 , Branchmanger ="Abdulla", EmployeeCount = 75,LocationURL= "https://maps.app.goo.gl/i2xcu2BxyHR152iZ8"},
        new BankBranches{  LocationName =" Abdulla Alsalem", Id = 2 , Branchmanger ="Bader", EmployeeCount = 47,LocationURL= "https://maps.app.goo.gl/fbvbF41AFJs3JZ6J7"},
        new BankBranches{  LocationName =" Faiha", Id = 3 , Branchmanger ="Fahad", EmployeeCount = 102,LocationURL= "https://maps.app.goo.gl/3ZUSNJKMzzDdpDvS8"},


    };

        public IActionResult Index()
        {
            using (var context = new BankContext())
            {
                var banks = context.BankBranches.ToList();
                return View(banks);
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
            

                

            {
                    return View(Index);
                }
            }
             public IActionResult Details(int id)
        {
            var bankBranch = branchlist.SingleOrDefault(b => b.Id == id);
            if (bankBranch == null)
            {
                return RedirectToAction("Index");
            }
            return View(bankBranch);

        }

       
            
        }
    }
    




       