using System.Collections.Generic;
using System.Linq;
using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Services
{
    public class OrganisatorRepository : IOrganisatorRepository
    {
        private List<Organisator> _organisatorList;

        public OrganisatorRepository()
        {
            InitializeData();
        }

        public IEnumerable<Organisator> All
        {
            get { return _organisatorList; }
        }

        public bool DoesOrganisatorExist(int id)
        {
            return _organisatorList.Any(organisator => organisator.OrganisatorId == id);
        }

        public Organisator Find(int id)
        {
            return _organisatorList.FirstOrDefault(organisator => organisator.OrganisatorId == id);
        }

        public void Insert(Organisator item)
        {
            _organisatorList.Add(item);
        }

        public void Update(Organisator organisator)
        {
            var selectedOrganisator = this.Find(organisator.OrganisatorId);
            var index = _organisatorList.IndexOf(selectedOrganisator);
            _organisatorList.RemoveAt(index);
            _organisatorList.Insert(index, organisator);
        }

        public void Delete(int OrganisatorId)
        {
            _organisatorList.Remove(this.Find(OrganisatorId));
        }

        private void InitializeData()
        {
            _organisatorList = new List<Organisator>();

            var organisator1 = new Organisator
            {
                OrganisatorId = 1,
                Name = "Eventix",
                Email = "administratie@eventix.nl",
                Password = "password"

            };

            var organisator2 = new Organisator
            {
                OrganisatorId = 2,
                Name = "Sziget",
                Email = "administration@szigetfestival.com",
                Password = "password"
            };


            _organisatorList.Add(organisator1);
            _organisatorList.Add(organisator2);
        }

    }
}