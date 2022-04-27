﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Newtonsoft.Json.Linq;
using WordMaster.Helpers;
using WordMaster.Models;

namespace WordMaster.Controllers
{
    public class WordMeaningController : Controller
    {
        IWordMeaningRepository _repository;
        IWordDefinitionRepository _wordDefinitionRepository;
        ILanguageRepository _languageRepository;
        public WordMeaningController(IWordMeaningRepository repository, IWordDefinitionRepository wordDefinitionRepository,
            ILanguageRepository languageRepository)
        {
            _repository = repository;
            _wordDefinitionRepository = wordDefinitionRepository;
            _languageRepository = languageRepository;
        }

        public ActionResult Index()
        {
            List<WordMeaningViewModel> model = new List<WordMeaningViewModel>();

            List<WordMeaning> liste = _repository.List();
            var serializedText = JsonSerializer.Serialize(liste);
            model = JsonSerializer.Deserialize<List<WordMeaningViewModel>>(serializedText);

            return View(model);
        }

        public IActionResult ListPartial(int defId)
        {
            List<WordMeaningViewModel> model = new List<WordMeaningViewModel>();

            List<WordMeaning> liste = _repository.ListByDefId(defId);
            var serializedText = JsonSerializer.Serialize(liste);
            model = JsonSerializer.Deserialize<List<WordMeaningViewModel>>(serializedText);

            return PartialView(model);
        }

        public ActionResult Edit(int? id)
        {
            WordMeaningViewModel model = new WordMeaningViewModel();
            if (id.HasValue && id > 0)
            {
                WordMeaning wd = _repository.GetById(id.Value);
                var serializedText = JsonSerializer.Serialize(wd);
                model = JsonSerializer.Deserialize<WordMeaningViewModel>(serializedText);
            }

            List<Language> languages = _languageRepository.List();
            //string langsText = JsonSerializer.Serialize(languages);
            //List<LanguageViewModel> Langs = JsonSerializer.Deserialize<List<LanguageViewModel>>(langsText);

            List<WordDefinition> wordDefinitions = _wordDefinitionRepository.List();
            //string wordTexts= JsonSerializer.Serialize(wordDefinitions);
            //List<WordDefinitionViewModel> wordDefs = JsonSerializer.Deserialize<List<WordDefinitionViewModel>>(wordTexts);

            model.Languages = Helper.Convert<List<LanguageViewModel>, List<Language>>(languages);
            model.WordDefinitions = Helper.Convert<List<WordDefinitionViewModel>, List<WordDefinition>>(wordDefinitions);


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WordMeaningViewModel model)
        {
            WordMeaning entity = new WordMeaning();
            var serilazedText = JsonSerializer.Serialize(model);
            entity = JsonSerializer.Deserialize<WordMeaning>(serilazedText);

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

        [HttpPost]
        public JsonResult AddNewMeaningToWord(WordMeaningViewModel model)
        {
            if (String.IsNullOrWhiteSpace(model.Meaning))
                return Json(new { success = false, message = "anlam boş olamaz" });

            WordMeaning entity = new WordMeaning();
            entity.LangId = model.LangId;
            entity.Meaning = model.Meaning;
            entity.WordDefinitionId = model.WordDefinitionId;
            _repository.Add(entity);

            return Json(new { success = true });
        }

        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteByAjax(int id)
        {
            _repository.Delete(id);
            return Json(true);
        }
    }
}
