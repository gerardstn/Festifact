using System.Collections.Generic;
using System.Linq;
using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Festifact.API.Services
{
    public class VisitorRepository : IVisitorRepository
    {
        private List<Visitor> _visitorList;

        public VisitorRepository()
        {
            InitializeData();
        }

        public IEnumerable<Visitor> All
        {
            get { return _visitorList; }
        }

        public bool DoesVisitorExist(int id)
        {
            return _visitorList.Any(visitor => visitor.VisitorId == id);
        }

        public Visitor Find(int id)
        {
            return _visitorList.FirstOrDefault(visitor => visitor.VisitorId == id);
        }

        public void Insert(Visitor item)
        {
            _visitorList.Add(item);
        }

        public void Update(Visitor visitor)
        {
            var selectedVisitor = this.Find(visitor.VisitorId);
            var index = _visitorList.IndexOf(selectedVisitor);
            _visitorList.RemoveAt(index);
            _visitorList.Insert(index, visitor);
        }

        public void Delete(int VisitorId)
        {
            _visitorList.Remove(this.Find(VisitorId));
        }

        private void InitializeData()
        {
            _visitorList = new List<Visitor>();

            var visitor1 = new Visitor
            {
                VisitorId = 1,
                Email = "john.Doe@gmail.com",
                Password = "password",
                Mobile = "0612345678",
                SurName = "Doe",
                Name = "John",
                Street = "Hogeschoollaan",
                ZipCode = "4818CR",
                HouseNumber = "1",
                BirthDate = new DateTime(1991, 02, 01)

            };

            var visitor2 = new Visitor
            {
                VisitorId = 2,
                Email = "jane.doe@gmail.com",
                Password = "password",
                Mobile = "0612345678",
                SurName = "Doe",
                Name = "Jane",
                Street = "Hogeschoollaan",
                ZipCode = "4818CR",
                HouseNumber = "1",
                BirthDate = new DateTime(2000, 01, 05)


            };

            var visitor3 = new Visitor
            {
                VisitorId = 3,
                Email = "sandra.pope@gmail.com",
                Password = "password",
                Mobile = "0612345678",
                SurName = "Pope",
                Name = "Sandra",
                Street = "Hogeschoollaan",
                ZipCode = "4818CR",
                HouseNumber = "1",
                BirthDate = new DateTime(1990, 05, 08)
            };

            _visitorList.Add(visitor1);
            _visitorList.Add(visitor2);
            _visitorList.Add(visitor3);
        }

        public bool FindByEmail(string email)
        {
            return _visitorList.Any(visitor => visitor.Email == email);
        }

        public Visitor Login(string email, string password)
        {
            IEnumerable<Visitor> filteredVisitor = _visitorList;
            filteredVisitor = filteredVisitor.Where(visitor => visitor.Email.ToLower() == email.ToLower());
            filteredVisitor = filteredVisitor.Where(visitor => visitor.Password == password);
            return filteredVisitor.First();
        }


    }
}