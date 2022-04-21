﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
            var serialezedText = JsonSerializer.Serialize(liste);
            model = JsonSerializer.Deserialize<List<WordMeaningViewModel>>(serialezedText);
        
            return View(model);
        }

        // GET: WordMeaningController/Edit/5
        public ActionResult Edit(int? id)
        {
            WordMeaningViewModel model = new WordMeaningViewModel();
            if (id.HasValue && id>0)
            {
                WordMeaning wordMeaning = _repository.GetById(id.Value);
                var serializedText = JsonSerializer.Serialize(wordMeaning);
                model = JsonSerializer.Deserialize<WordMeaningViewModel>(serializedText);
            }
            return View(model);
        }

        // POST: WordMeaningController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WordMeaningViewModel model)
        {
            WordMeaning entity = new WordMeaning();

            var serialezedText = JsonSerializer.Serialize(model);
            entity = JsonSerializer.Deserialize<WordMeaning>(serialezedText);

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
    }
}