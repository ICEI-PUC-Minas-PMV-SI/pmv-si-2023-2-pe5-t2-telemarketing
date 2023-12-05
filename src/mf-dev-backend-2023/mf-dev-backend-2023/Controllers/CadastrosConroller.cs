using mf_dev_backend_2023.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mf_dev_backend_2023.Controllers
{
    public class CadastrosController : Controller
    {
        private readonly AppDbContext _context;
        public CadastrosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Cadastros.ToListAsync();
            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == 0)
                return NotFound();

            var dados = await _context.Cadastros.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cadastro cadastro)
        {
            if (id != cadastro.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Cadastros.Update(cadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Cadastros.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Cadastros.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DetailsConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Cadastros.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Cadastros.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

    }
}
