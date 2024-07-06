using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.DataBase;
using StudentPortal.Models;
using StudentPortal.Models.Entites;
using System.Security.Policy;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly DbContextApp dbContext;

        public StudentsController(DbContextApp dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentVM viewmodel)
        {
            var student = new Student
            {
                Name = viewmodel.Name,
                Email = viewmodel.Email,
                Id = viewmodel.Id,
                PhoneNo = viewmodel.PhoneNo,
                Subscribed = viewmodel.Subscribed
            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return View(student);
        }
        [HttpGet]
        public async Task<IActionResult> list()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await dbContext.Students.FindAsync(id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student editVM)
        {
            var student = await dbContext.Students.FindAsync(editVM.Id);
            if (student != null)
            {
                student.Name = editVM.Name;
                student.Email = editVM.Email;
                student.PhoneNo = editVM.PhoneNo;
                student.Subscribed = editVM.Subscribed;
               // await dbContext.Students.AddAsync(editVM);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
        [HttpPost]
        public async Task<IActionResult>Delete(Student deletevm)
        {
            var student= await dbContext.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x=>x.Id == deletevm.Id);
            if(student != null)
            {
                dbContext.Students.Remove(deletevm);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
    }
}
