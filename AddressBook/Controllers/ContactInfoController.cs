using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddressBook.Bll.Interfaces;
using AddressBook.Bll.Models;
using AddressBook.Responses;
using AddressBook.Requests;
using AutoMapper;

namespace AddressBook.Controllers
{
    public class ContactInfoController : Controller
    {
        private IContactInfoService _contactInfoService;
        private IMapper _mapper;

        public ContactInfoController(IContactInfoService contactInfoService)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContactInfoModel, ContactInfoResponse>();
                cfg.CreateMap<ContactInfoRequest, ContactInfoModel>();
                cfg.CreateMap<ContactInfoModel, ContactInfoRequest>();
            });

            _mapper = config.CreateMapper();
            _contactInfoService = contactInfoService;
        }

        // GET: ContactInfo
        public ActionResult GetAllContactInfo()
        {
            var contactInfos = _contactInfoService.GetAllContactInfos().ToList();

            return View(_mapper.Map<List<ContactInfoModel>, List<ContactInfoResponse>>(contactInfos));
        }

        // GET: ContactInfo/Details/5
        public ActionResult Details(int id)
        {
            var contactInfoModel = _contactInfoService.GetContactInfo(id);

            return View(contactInfoModel);
        }

        // GET: ContactInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactInfo/Create
        [HttpPost]
        public ActionResult Create(ContactInfoRequest request)
        {
            var dbContext = _contactInfoService.GetAllContactInfos();

            try
            {
                if (ModelState.IsValid)
                {
                    var contactInfoModel = _mapper.Map<ContactInfoRequest, ContactInfoModel>(request);

                    _contactInfoService.AddContact(contactInfoModel);

                    return RedirectToAction(nameof(GetAllContactInfo));
                }
            }
            catch (Exception ex)
            {
                string key = GetKey(ex);

                ModelState.AddModelError(key, ex.Message);

                return View(request);
            }

            return View(request);
        }

        // GET: ContactInfo/Edit/5
        public ActionResult Edit(int id)
        {
            var contactInfo = _contactInfoService.GetContactInfo(id);
            var request = _mapper.Map<ContactInfoModel, ContactInfoRequest>(contactInfo);

            return View(request);
        }

        // POST: ContactInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ContactInfoRequest contactInfoRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contactInfoModel = _mapper.Map<ContactInfoRequest, ContactInfoModel>(contactInfoRequest);

                    _contactInfoService.UpdateContactInfo(contactInfoModel, id);

                    return RedirectToAction(nameof(GetAllContactInfo));
                }
            }
            catch (Exception ex)
            {
                string key = GetKey(ex);

                ModelState.AddModelError(key, ex.Message);

                return View(contactInfoRequest);
            }

            return View(contactInfoRequest);
        }

        //GET: ContactInfo/Delete/5
        public ActionResult Delete(int id)
        {
            var contactInfo = _contactInfoService.GetContactInfo(id);

            if (contactInfo == null)
            {
                throw new NullReferenceException();
            }

            _contactInfoService.DeleteContacInfo(contactInfo.Id);

            return RedirectToAction(nameof(GetAllContactInfo));
        }

        public string GetKey(Exception ex)
        {
            if (ex.Message.Contains("Email"))
            {
                return "EmailAddress";
            }
            else if (ex.Message.Contains("Full name"))
            {
                return "FullName";
            }

            return "PhoneNumber";
        }
    }
}
