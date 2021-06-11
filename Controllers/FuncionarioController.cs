using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoDaniel02.Context;
using TrabalhoDaniel02.Models;

namespace TrabalhoDaniel02.Controllers
{
    [Authorize]
    public class FuncionarioController : Controller
    {
        private readonly Contexto _contexto; 

        public FuncionarioController(Contexto contexto) { _contexto = contexto; }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Funcionarios.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome","Email")] Funcionario funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contexto.Funcionarios.Add(funcionario);
                    await _contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(ex.Message, "Erro ao cadastrar");
            }

            return View(funcionario);
        }

        public  async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _contexto.Funcionarios.FirstOrDefaultAsync(a => a.id == id));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dados = await _contexto.Funcionarios.FirstOrDefaultAsync(t => t.id == id);
            if (dados == null)
            {
                return NotFound();
            }

            return View(dados);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Funcionarios.Update(funcionario);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(funcionario);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(await _contexto.Funcionarios.FirstOrDefaultAsync(tete => tete.id == id));
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirma(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dados = await _contexto.Funcionarios.FirstOrDefaultAsync(j => j.id == id);

            if(dados == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _contexto.Funcionarios.Remove(dados);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
