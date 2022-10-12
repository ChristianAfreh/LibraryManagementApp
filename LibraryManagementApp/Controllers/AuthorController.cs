using LibraryManagementApp.Data.Interfaces;
using LibraryManagementApp.Data.Model;
using LibraryManagementApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LibraryManagement.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IActionResult List()
        {
            var authors = _authorRepository.GetAllWithBooks();

            if (authors.Count() == 0) return View("Empty");

            return View(authors);
        }

        public IActionResult Update(int id)
        {
            var author = _authorRepository.GetById(id);

            if (author == null) return NotFound();

            return View(author);
        }

        [HttpPost]
        public IActionResult Update(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            _authorRepository.Update(author);

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            //var viewModel = new CreateAuthorViewModel
            //{ Referer = Request.Headers["Referer"].ToString() };

            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(authorVM);
            //}

            //_authorRepository.Create(authorVM.Author);

            //if (!String.IsNullOrEmpty(authorVM.Referer))
            //{
            //    return Redirect(authorVM.Referer);
            //}
            _authorRepository.Create(author);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var author = _authorRepository.GetById(id);

            _authorRepository.Delete(author);

            return RedirectToAction("List");
        }
    }
}