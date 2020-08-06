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

        [HttpPost]
        public async Task<IActionResult> Index(string nome)
        {
            var result = await _context.Clientes.Where(x => x.Visivel && x.Nome.Contains(nome)).ToListAsync();

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if(cliente.Data_Cadastro > DateTime.Now)
            {
                ViewBag.Erro = "Data de cadastro não pode ser maior que a data atual.";
                return View(cliente);
            }

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
            if (cliente.Data_Cadastro > DateTime.Now)
            {
                ViewBag.Erro = "Data de cadastro não pode ser maior que a data atual.";
                return View(cliente);
            }

            cliente.Visivel = true;
            _context.Clientes.Update(cliente);
            int result = await _context.SaveChangesAsync();

            if(result > 0)//caso tudo OK
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Erro = "Ocorreu um erro !";
            return View(cliente);
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
            int result = await _context.SaveChangesAsync();

            if(result > 0)//caso tudo OK
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Erro = "Ocorreu um erro !";
            return View(cliente);
        }
        
    }
}