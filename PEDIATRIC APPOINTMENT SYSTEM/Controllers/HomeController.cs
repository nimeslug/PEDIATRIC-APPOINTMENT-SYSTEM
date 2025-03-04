using Microsoft.AspNetCore.Mvc;
using webOdev.NewFolder;
using Microsoft.EntityFrameworkCore;
using webOdev.Services;
using webOdev.Models;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    private readonly EmailService _emailService;

    public HomeController(AppDbContext context, EmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }

    public IActionResult Index()
    {
        // Session bilgilerini ViewData ile aktar�yoruz
        ViewData["Role"] = HttpContext.Session.GetString("Role");
        ViewData["Username"] = HttpContext.Session.GetString("Username");

        var schedules = _context.Schedules.ToList();
        return View(schedules);
    }

    // Departmanlar� Listele
    [HttpGet]
    public async Task<IActionResult> Departments()
    {
        var departments = await _context.Departments.ToListAsync(); // Veritaban�ndan departmanlar� �ek
        return PartialView("_Departments", departments); // _Departments.cshtml'e g�nder
    }
    [HttpPost]
    // GET: Emergency Create View
    [HttpGet]
    
    public IActionResult CreateEmergency()
    {
        if (HttpContext.Session.GetString("Role") != "Admin")
        {
            return RedirectToAction("AccessDenied", "Account");
        }
        return View(); // CreateEmergency.cshtml'i d�nd�r�r
    }

    [HttpPost]
    [Route("Home/CreateEmergency")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateEmergency(EmergencyViewModel model)
    {
        if (HttpContext.Session.GetString("Role") != "Admin")
        {
            return RedirectToAction("AccessDenied", "Account");
        }

        if (ModelState.IsValid)
        {
            var assistantEmails = _context.Assistants.Select(a => a.Email).ToList();  // Asistan e-posta adreslerini �ekiyoruz
            var doctorEmails = _context.Doctors.Select(d => d.Email).ToList();        // Doktor e-posta adreslerini �ekiyoruz

            var allEmails = assistantEmails.Concat(doctorEmails).ToList();  // Asistan ve doktorlar� birle�tiriyoruz
                                                                            // E-posta i�eri�i
            string subject = model.Title;
            string body = model.Message;

            // E-posta g�nderme i�lemi
            await _emailService.SendEmailAsync(allEmails, subject, body);
            // E-posta g�nderme i�lemleri
            TempData["SuccessMessage"] = "Acil durum bildirimleri ba�ar�yla g�nderildi!";
            return RedirectToAction("Index");
        }

        return View(model); // Model ge�ersizse ayn� sayfay� d�nd�r�r
    }




}
