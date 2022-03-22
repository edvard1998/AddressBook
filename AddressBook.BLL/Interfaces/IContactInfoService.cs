using AddressBook.Bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Bll.Interfaces
{
    public interface IContactInfoService
    {
        IEnumerable<ContactInfoModel> GetAllContactInfos();
        ContactInfoModel GetContactInfo(int id);
        ContactInfoModel AddContact(ContactInfoModel contactInfoModel);
        int UpdateContactInfo(ContactInfoModel contactInfoModel, int id);
        void DeleteContacInfo(int id);
    }
}
