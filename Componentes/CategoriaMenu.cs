﻿using CarRent.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Componentes
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRepository.Categorias.OrderBy(c => c.Modelo);
            return View(categorias);
        }
    }
}
