using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UsuarioModelsController : Controller
    {
        private readonly BancoContext _context;

        public UsuarioModelsController(BancoContext context)
        {
            _context = context;
        }

        // GET: UsuarioModels
        public async Task<IActionResult> Index()
        {
            var bancoContext = _context.CH_USUARIO.Include(u => u.ENDERECO);
            return View(await bancoContext.ToListAsync());
        }

        // GET: UsuarioModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.CH_USUARIO
                .Include(u => u.ENDERECO)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // GET: UsuarioModels/Create
        public IActionResult Create()
        {
            ViewData["ENDERECO_ID"] = new SelectList(_context.CH_ENDERECO, "ID", "ID");
            return View();
        }

        // POST: UsuarioModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NOME,CPF,TELEFONE,NASCIMENTO,EMAIL,ENDERECO_ID")] UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Remover a seleção de ENDERECO_ID
            return View(usuarioModel);
        }
        // GET: UsuarioModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.CH_USUARIO.FindAsync(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }
            // Remover a seleção de ENDERECO_ID
            return View(usuarioModel);
        }

        // POST: UsuarioModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NOME,CPF,TELEFONE,NASCIMENTO,EMAIL,ENDERECO_ID")] UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioModelExists(usuarioModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            // Remover a seleção de ENDERECO_ID
            return View(usuarioModel);
        }

        // GET: UsuarioModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.CH_USUARIO
                .Include(u => u.ENDERECO)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // POST: UsuarioModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioModel = await _context.CH_USUARIO.FindAsync(id);
            if (usuarioModel != null)
            {
                _context.CH_USUARIO.Remove(usuarioModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioModelExists(int id)
        {
            return _context.CH_USUARIO.Any(e => e.ID == id);
        }
    }
}
