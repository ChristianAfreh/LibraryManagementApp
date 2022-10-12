using LibraryManagementApp.Data.Interfaces;
using LibraryManagementApp.Models;
using LibraryManagementApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAuthorRepository _authorRepository;

        public HomeController(IBookRepository bookRepository,
            ICustomerRepository customerRepository,
            IAuthorRepository authorRepository
            )
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
            _authorRepository = authorRepository;
        }

        public IActionResult Index()
        {

            //create home view model
            var homeVM = new HomeViewModel()
            {
                AuthorCount = _authorRepository.Count(x => true),
                BookCount = _bookRepository.Count(x => true),
                CustomerCount = _customerRepository.Count(x => true),
                LendBookCount = _bookRepository.Count(x => x.Borrower != null)
            };

            //call view
            return View(homeVM);
        }

    }
}
