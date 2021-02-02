using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroSolicitacoes.Models;

namespace CadastroSolicitacoes.Controllers
{
    public class SolicitacoesController : Controller
    {
        private readonly Context _context;

        public SolicitacoesController(Context context)
        {
            _context = context;
        }

        // GET: Solicitacoes
        public async Task<IActionResult> Index()
        {
            var context = _context.Solicitacao.Include(s => s.Aluno);
            return View(await context.ToListAsync());
        }

        // GET: Solicitacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitacao = await _context.Solicitacao
                .Include(s => s.Aluno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitacao == null)
            {
                return NotFound();
            }

            return View(solicitacao);
        }

        // GET: Solicitacoes/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Nome");
            return View();
        }

        // POST: Solicitacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,DataSolicitacao,AlunoId")] Solicitacao solicitacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Nome", solicitacao.AlunoId);
            return View(solicitacao);
        }

        // GET: Solicitacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitacao = await _context.Solicitacao.FindAsync(id);
            if (solicitacao == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Nome", solicitacao.AlunoId);
            return View(solicitacao);
        }

        // POST: Solicitacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,DataSolicitacao,AlunoId")] Solicitacao solicitacao)
        {
            if (id != solicitacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitacaoExists(solicitacao.Id))
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
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Nome", solicitacao.AlunoId);
            return View(solicitacao);
        }

        // GET: Solicitacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitacao = await _context.Solicitacao
                .Include(s => s.Aluno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitacao == null)
            {
                return NotFound();
            }

            return View(solicitacao);
        }

        // POST: Solicitacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitacao = await _context.Solicitacao.FindAsync(id);
            _context.Solicitacao.Remove(solicitacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitacaoExists(int id)
        {
            return _context.Solicitacao.Any(e => e.Id == id);
        }
    }
}
