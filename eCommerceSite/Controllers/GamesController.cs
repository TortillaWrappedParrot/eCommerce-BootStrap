using eCommerceSite.Data;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceSite.Controllers
{
    public class GamesController : Controller 
    {
        private readonly VideoGameContext _context;

        public GamesController(VideoGameContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            const int NumGamesToDisplayPerPage = 3;
            const int PageOffset = 1; // Need a page offset to use current page and figure out, num games to skip

            int currPage = id ?? 1; // Set currPage to id if it has a value, otherwise use 1

            int totalNumOfProducts = await _context.Games.CountAsync();
            double maxNumPages = Math.Ceiling((double)totalNumOfProducts / NumGamesToDisplayPerPage);
            int lastPage = Convert.ToInt32(maxNumPages); // Rounding pages up, to next whole page number

            List<Game> games = await (from game in _context.Games
                                      select game)
                                     .Skip(NumGamesToDisplayPerPage * (currPage - PageOffset))
                                     .Take(NumGamesToDisplayPerPage)
                                     .ToListAsync();

            return View(games);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Game g)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(g); //Prepares insert
                await _context.SaveChangesAsync(); //Executes insert

                ViewData["Message"] = $"{g.Title} was added successfully!";
                return View();
            }
            return View(g);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Game? targetGame = await _context.Games.FindAsync(id);
            
            if (targetGame == null)
            {
                return NotFound();
            }
            
            return View(targetGame);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Game gameModel)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Update(gameModel);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{gameModel.Title} was updated successfully!";
                return RedirectToAction("Index");
            }

            return View(gameModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Game? targetGame = await _context.Games.FindAsync(id);

            if (targetGame == null)
            {
                return NotFound();
            }

            return View(targetGame);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Game? gameToDelete = await _context.Games.FindAsync(id);

            if (gameToDelete != null)
            {
                _context.Games.Remove(gameToDelete);
                await _context.SaveChangesAsync();

                TempData["Message"] = gameToDelete.Title + " was deleted successfully";
                return RedirectToAction("Index");
            }

            TempData["Message"] = "This game was already deleted";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Game? targetGame = await _context.Games.FindAsync(id);

            if (targetGame == null)
            {
                return NotFound();
            }

            return View(targetGame);
        }
    }
}
