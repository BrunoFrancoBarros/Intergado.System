using AutoMapper;
using Intergado.App.ViewModels;
using Intergado.Business.Model;
using Intergado.Business.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Intergado.App.Controllers
{
    public class AnimaisController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAnimalRepository _animalRepository;
        private readonly IFazendaRepository _fazendaRepository;

        public AnimaisController(IMapper mapper, IAnimalRepository animalRepository, IFazendaRepository fazendaRepository)
        {
            _mapper = mapper;
            _animalRepository = animalRepository;
            _fazendaRepository = fazendaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var animais = _mapper.Map<List<AnimalViewModel>>(await _animalRepository.GetAnimaisFazendas());
            return View(animais);
        }

        public async Task<IActionResult> Details(long id)
        {
            var animal = await GetAnimal(id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        public async Task<IActionResult> Create()
        {
            var animalViewModel = await PopularFazendas(new AnimalViewModel());

            return View(animalViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnimalViewModel AnimalViewModel)
        {
            if (!ModelState.IsValid)
            {
                AnimalViewModel = await PopularFazendas(AnimalViewModel);
                return View(AnimalViewModel);
            }

            var identifierExists = await _animalRepository.GetIdentifierExists(AnimalViewModel.Identificador);

            if (identifierExists)
            {
                ViewBag.Erro = "Já existe um animal cadastrado com esse identificador";
                AnimalViewModel = await PopularFazendas(AnimalViewModel);
                return View(AnimalViewModel);
            }

            await _animalRepository.Add(_mapper.Map<AnimalEntity>(AnimalViewModel));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(long id)
        {
            var animal = await GetAnimal(id);

            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, AnimalViewModel AnimalViewModel)
        {
            if (id != AnimalViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(AnimalViewModel);
            }

            await _animalRepository.Update(_mapper.Map<AnimalEntity>(AnimalViewModel));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(long id)
        {
            var animal = await GetAnimal(id);

            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var animal = await _animalRepository.GetById(id);

            if (animal == null)
            {
                return NotFound();
            }

            await _animalRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<AnimalViewModel> PopularFazendas(AnimalViewModel animalViewModel)
        {
            animalViewModel.Fazendas = _mapper.Map<List<FazendaViewModel>>(await _fazendaRepository.GetAll());

            return animalViewModel;
        }

        public async Task<AnimalViewModel> GetAnimal(long animalId)
        {
            var animal = _mapper.Map<AnimalViewModel>(await _animalRepository.GetAnimalFazenda(animalId));
            animal.Fazendas = _mapper.Map<List<FazendaViewModel>>(await _fazendaRepository.GetAll());
            return animal;
        }
    }
}