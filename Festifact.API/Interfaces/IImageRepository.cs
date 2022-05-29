using System.Collections.Generic;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Interfaces
{
    public interface IImageRepository
    {
        bool DoesImageExist(int id);
        IEnumerable<Image> All { get; }
        Image Find(int imageId);
        void Insert(Image image);
        void Update(Image image);
        void Delete(int imageId);
        
    }
}