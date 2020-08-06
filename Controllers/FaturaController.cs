using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteSinapse.Data;
using TesteSinapse.Models;

namespace TesteSinapse.Controllers
{
    public class FaturaController : Controller
    {
        readonly BancoContext _context;

        public FaturaController(BancoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _context.Faturas.Include(x => x.Cliente).ToListAsync();

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int codigo)
        {
            var result = await _context.Faturas.Include(x => x.Cliente).Where(x => x.Num_Fatura.Equals(codigo)).ToListAsync();

            return View(result);
        }

        public IActionResult Create()
        {
            ViewBag.Clientes = new SelectList(_context.Clientes.Where(x => x.Visivel).ToList(),"Cod_Cliente","Nome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Fatura fatura)
        {
            if(fatura.Data_Emissao > fatura.Data_Vencimento)
            {
                ViewBag.Erro = "Data de emissão não pode ser posterior a data de vencimento.";
                ViewBag.Clientes = new SelectList(_context.Clientes.Where(x => x.Visivel).ToList(), "Cod_Cliente", "Nome");
                return View();
            }

            await _context.AddAsync(fatura);
            int result = await _context.SaveChangesAsync();

            if (result > 0)//caso tudo OK
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Erro = "Ocorreu um erro !";
            ViewBag.Clientes = new SelectList(_context.Clientes.Where(x => x.Visivel).ToList(), "Cod_Cliente", "Nome",fatura.Cod_Cliente);
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var result = await _context.Faturas.FindAsync(id);

            if (result == null)
                return NotFound();

            ViewBag.Clientes = new SelectList(_context.Clientes.Where(x => x.Visivel).ToList(), "Cod_Cliente", "Nome", result.Cod_Cliente);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Fatura fatura)
        {
            if (fatura.Data_Emissao > fatura.Data_Vencimento)
            {
                ViewBag.Erro = "Data de emissão não pode ser posterior a data de vencimento.";
                ViewBag.Clientes = new SelectList(_context.Clientes.Where(x => x.Visivel).ToList(), "Cod_Cliente", "Nome", fatura.Cod_Cliente);
                return View(fatura);
            }

            _context.Faturas.Update(fatura);
            int result = await _context.SaveChangesAsync();

            if (result > 0)//caso tudo OK
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clientes = new SelectList(_context.Clientes.Where(x => x.Visivel).ToList(), "Cod_Cliente", "Nome", fatura.Cod_Cliente);
            ViewBag.Erro = "Ocorreu um erro !";
            return View(fatura);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var result = await _context.Faturas.Include(x => x.Cliente).Where(x => x.Num_Fatura.Equals(id)).FirstOrDefaultAsync();

            if (result == null)
                return NotFound();

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Fatura fatura)
        {
            _context.Faturas.Remove(fatura);
            int result = await _context.SaveChangesAsync();

            if (result > 0)//caso tudo OK
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Erro = "Ocorreu um erro !";
            return View(fatura);
        }
    }
}
