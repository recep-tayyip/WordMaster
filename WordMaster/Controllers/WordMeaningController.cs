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
    public class WordMeaningController : Controller
    {
        private IWordMeaningRepository _repository;
        public WordMeaningController(IWordMeaningRepository repository)
        {
            _repository = repository;
        }

        // GET: WordMeaningController
        public ActionResult Index()
        {
            List<WordMeaningViewModel> model = new List<WordMeaningViewModel>();
            List<WordMeaning> liste = _repository.List();
            foreach (WordMeaning item in liste)
            {
                WordMeaningViewModel wordMeaningViewModel = new WordMeaningViewModel()
                {
                    Id = item.Id,
                    LangId = item.LangId,
                    Meaning = item.Meaning,
                    WordDefinitionId = item.WordDefinitionId
                };
                model.Add(wordMeaningViewModel);
            }
            return View(model);
        }

        // GET: WordMeaningController/Edit/5
        public ActionResult Edit(int? id)
        {
            WordMeaningViewModel model = new WordMeaningViewModel();
            if (id.HasValue && id>0)
            {
                WordMeaning wordMeaning = _repository.GetById(id.Value);
                model.Id = wordMeaning.Id;
                model.LangId = wordMeaning.LangId;
                model.WordDefinitionId = wordMeaning.WordDefinitionId;
                model.Meaning = wordMeaning.Meaning;
            }
            return View(model);
        }

        // POST: WordMeaningController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WordMeaningViewModel model)
        {
            WordMeaning entity = new WordMeaning()
            {
                Id = model.Id,
                LangId = model.LangId,
                WordDefinitionId = model.WordDefinitionId,
                Meaning =model.Meaning
            };
            if (entity.Id>0)
            {
                _repository.Update(entity);
            }
            else
            {
                _repository.Add(entity);
            }
            return RedirectToAction("Index");
        }

        // GET: WordMeaningController/Delete/5
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: WordMeaningController/Delete/5
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
