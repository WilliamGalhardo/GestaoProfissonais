using GestaoProfissionais.Data;  // Importando o namespace correto
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Threading.Tasks;
using GestaoProfissionais.Models; // Importando o namespace correto do seu modelo

public class ProfissionalController : Controller
{
    private readonly AppDbContext _context;  // Corrigido para o nome correto do DbContext

    // Construtor com a injeção de dependência do AppDbContext
    public ProfissionalController(AppDbContext context)
    {
        _context = context;
    }

    // Método para exibir a página de criação de um profissional
    public IActionResult Create()
    {
        // Certifique-se de que está passando a lista de especialidades para a View
        ViewBag.Especialidades = new SelectList(_context.Especialidades, "Id", "Nome");
        return View();
    }

    // Método para criar um novo profissional (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Profissional profissional)
    {
        if (ModelState.IsValid)
        {
            _context.Add(profissional);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Profissional cadastrado com sucesso!";
            return RedirectToAction(nameof(Index)); // Redireciona para a lista de profissionais
        }
        // Em caso de erro, repassa as especialidades para o formulário
        ViewBag.Especialidades = new SelectList(_context.Especialidades, "Id", "Nome", profissional.EspecialidadeId);
        return View(profissional);
    }

    // Método para editar um profissional existente
    public IActionResult Edit(Guid id)
    {
        var profissional = _context.Profissionais
            .Include(p => p.Especialidade) // Carregar especialidade junto
            .FirstOrDefault(p => p.Id == id);

        if (profissional == null)
        {
            return NotFound();
        }

        // Passa as especialidades para o dropdown na view
        ViewBag.Especialidades = new SelectList(_context.Especialidades, "Id", "Nome", profissional.EspecialidadeId);
        return View(profissional);
    }

    // Método para editar um profissional (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, Profissional profissional)
    {
        if (id != profissional.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(profissional);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Profissional atualizado com sucesso!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfissionalExists(profissional.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index)); // Redireciona para a lista de profissionais
        }

        // Se houve erro, passa as especialidades para o formulário
        ViewBag.Especialidades = new SelectList(_context.Especialidades, "Id", "Nome", profissional.EspecialidadeId);
        return View(profissional);
    }

    // Método auxiliar para verificar se o profissional existe
    private bool ProfissionalExists(Guid id)
    {
        return _context.Profissionais.Any(e => e.Id == id);
    }

    // Método para exibir a lista de profissionais
    public IActionResult Index()
    {
        var profissionais = _context.Profissionais.Include(p => p.Especialidade).ToList();
        return View(profissionais);
    }
}
