using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using WordMaster.Models;

namespace WordMaster.Controllers
{
    public class WordDefinitionController : Controller
    {
        private IWordDefinitionRepository _repository;
        public WordDefinitionController(IWordDefinitionRepository repository)
        {
            _repository = repository;
        }
        // GET: WordDefinitionController
        public ActionResult Index()
        {
            List<WordDefinitionViewModel> model = new List<WordDefinitionViewModel>();
            List<WordDefinition> liste = _repository.List();
            foreach (WordDefinition item in liste)
            {
                WordDefinitionViewModel wordDefinitionViewModel = new WordDefinitionViewModel()
                {
                    Id = item.Id,
                    LangId = item.LangId,
                    Word = item.Word
                };
                model.Add(wordDefinitionViewModel);
            }
            return View(model);
        }

        // GET: WordDefinitionController/Edit/5
        public ActionResult Edit(int? id)
        {
            WordDefinitionViewModel model = new WordDefinitionViewModel();
            if (id.HasValue && id > 0)
            {
                WordDefinition wordDefinition = _repository.GetById(id.Value);
                model.Id = wordDefinition.Id;
                model.LangId = wordDefinition.LangId;
                model.Word = wordDefinition.Word;
            }
            return View(model);
        }

        // POST: WordDefinitionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WordDefinitionViewModel model)
        {
            WordDefinition entity = new WordDefinition()
            {
                Id = model.Id,
                LangId = model.LangId,
                Word = model.Word
            };
            if (entity.Id > 0)
            {
                _repository.Update(entity);
            }
            else
            {
                _repository.Add(entity);
            }
            return RedirectToAction("Index");
        }

        // GET: WordDefinitionController/Delete/5
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: WordDefinitionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
