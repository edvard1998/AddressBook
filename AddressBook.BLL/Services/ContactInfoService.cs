using AddressBook.Bll.Interfaces;
using AddressBook.Bll.Models;
using AddressBook.Dal.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;

namespace AddressBook.Bll.Services
{
    public class ContactInfoService : IContactInfoService
    {
        private IMapper _mapper;

        public ContactInfoService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContactInfo, ContactInfoModel>();
                cfg.CreateMap<ContactInfoModel, ContactInfo>();
            });

            _mapper = config.CreateMapper();
        }

        public IEnumerable<ContactInfoModel> GetAllContactInfos()
        {
            using (var dbContext = new AddressBookContext())
            {
                var contactInfos = dbContext.ContactInfos.OrderBy(rec => rec.FullName);

                foreach (var contactInfo in contactInfos)
                {
                    var contactInfoModel = _mapper.Map<ContactInfo, ContactInfoModel>(contactInfo);
                    yield return contactInfoModel;
                }
            }
        }

        public ContactInfoModel GetContactInfo(int id)
        {
            using (var dbContext = new AddressBookContext())
            {
                var contactInfo = dbContext.ContactInfos.Where(rec => rec.Id == id).FirstOrDefault();
                if (contactInfo != null)
                {
                    var contactInfoModel = _mapper.Map<ContactInfo, ContactInfoModel>(contactInfo);

                    return contactInfoModel;
                }

                return null;
            }
        }

        public ContactInfoModel AddContact(ContactInfoModel contactInfoModel)
        {
            using (var dbContext = new AddressBookContext())
            {
                if (IsValid(contactInfoModel, dbContext))
                {
                    var contactInfo = _mapper.Map<ContactInfoModel, ContactInfo>(contactInfoModel);
                    dbContext.ContactInfos.Add(contactInfo);
                    dbContext.SaveChanges();
                }

                return contactInfoModel;
            }
        }

        public int UpdateContactInfo(ContactInfoModel updatedContact, int id)
        {
            using (var dbContext = new AddressBookContext())
            {
                var contactInfoEntity = dbContext.ContactInfos.Where(rec => rec.Id == id).FirstOrDefault();

                if (contactInfoEntity != null)
                {
                    if (IsValid(updatedContact, dbContext))
                    {
                        _mapper.Map<ContactInfoModel, ContactInfo>(updatedContact, contactInfoEntity);

                        dbContext.SaveChanges();
                    }
                }

                return updatedContact.Id;
            }
        }

        public void DeleteContacInfo(int id)
        {
            using (var dbContext = new AddressBookContext())
            {
                var contactInfo = dbContext.ContactInfos.Where(rec => rec.Id == id).FirstOrDefault();

                if (contactInfo != null)
                {
                    dbContext.ContactInfos.Remove(contactInfo);
                    dbContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Checks contactInfo && updatedContact is the same or not
        /// </summary>
        /// <param name="contactInfo"></param>
        /// <param name="updatedContact"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        private bool IsValid(ContactInfoModel updatedContact, AddressBookContext context)
        {
            if (string.IsNullOrWhiteSpace(updatedContact.FullName))
            {
                throw new ValidationException("Full Name cannot be empty.");
            }

            if (context.ContactInfos.Any(rec => rec.Id != updatedContact.Id && rec.EmailAddress == updatedContact.EmailAddress))
            {
                throw new ValidationException("Email already exists.");
            }

            if (context.ContactInfos.Any(rec => rec.Id != updatedContact.Id && rec.PhoneNumber == updatedContact.PhoneNumber))
            {
                throw new ValidationException("Phone Number already exists.");
            }

            return true;
        }
    }
}
