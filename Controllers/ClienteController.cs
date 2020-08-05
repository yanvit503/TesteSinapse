using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteSinapse.Data;
using TesteSinapse.Models;

namespace TesteSinapse.Controllers
{
    public class ClienteController : Controller
    {

        readonly BancoContext _context;

        public ClienteController(BancoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var result = await  _context.Clientes.Where(x => x.Visivel).ToListAsync();

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            cliente.Data_Cadastro = DateTime.Now;
            cliente.Visivel = true;

            await _context.AddAsync(cliente);
            int result = await _context.SaveChangesAsync();

            if(result > 0)//caso tudo OK
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Erro = "Ocorreu um erro !";
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
                return NotFound();            

            var result = await _context.Clientes.FindAsync(id);

            if(result == null)
                return NotFound();            

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cliente cliente)
        {
            cliente.Visivel = true;
            _context.Clientes.Update(cliente);
            _context.Entry(cliente).State = EntityState.Modified;
            int result = await _context.SaveChangesAsync();

            if(result > 0)//caso tudo OK
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Erro = "Ocorreu um erro !";
            return View();
        }

         public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
                return NotFound();            

            var result = await _context.Clientes.FindAsync(id);

            if(result == null)
                return NotFound();            

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Cliente cliente)
        {
            cliente.Visivel = false;
            _context.Clientes.Update(cliente);
            _context.Entry(cliente).State = EntityState.Modified;
            int result = await _context.SaveChangesAsync();

            if(result > 0)//caso tudo OK
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Erro = "Ocorreu um erro !";
            return View();
        }
        
    }
}