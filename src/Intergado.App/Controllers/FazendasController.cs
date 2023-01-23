using AutoMapper;
using Intergado.App.ViewModels;
using Intergado.Business.Model;
using Intergado.Business.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Intergado.App.Controllers
{
    public class FazendasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFazendaRepository _fazendaRepository;

        public FazendasController(IMapper mapper, IFazendaRepository fazendaRepository)
        {
            _mapper = mapper;
            _fazendaRepository = fazendaRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<FazendaViewModel>>(await _fazendaRepository.GetAll()));
        }

        public async Task<IActionResult> Details(long id)
        {
            var fazenda = await _fazendaRepository.GetById(id);
            if (fazenda == null)
            {
                return NotFound();
            }

            var fazendaViewModel = _mapper.Map<FazendaViewModel>(fazenda);

            return View(fazendaViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] FazendaViewModel fazendaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(fazendaViewModel);
            }

            var fazenda = _mapper.Map<FazendaEntity>(fazendaViewModel);

            await _fazendaRepository.Add(fazenda);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(long id)
        {
            var fazenda = await _fazendaRepository.GetById(id);

            if (fazenda == null)
            {
                return NotFound();
            }

            var fazendaViewModel = _mapper.Map<FazendaViewModel>(fazenda);

            return View(fazendaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, FazendaViewModel fazendaViewModel)
        {
            if (id != fazendaViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(fazendaViewModel);
            }

            await _fazendaRepository.Update(_mapper.Map<FazendaEntity>(fazendaViewModel));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(long id)
        {
            var fazenda = await _fazendaRepository.GetById(id);

            if (fazenda == null)
            {
                return NotFound();
            }

            var fazendaViewModel = _mapper.Map<FazendaViewModel>(fazenda);

            return View(fazendaViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var fazenda = await _fazendaRepository.GetById(id);

            if (fazenda == null)
            {
                return NotFound();
            }

            await _fazendaRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}