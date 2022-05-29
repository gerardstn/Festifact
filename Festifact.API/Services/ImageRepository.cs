using System.Collections.Generic;
using System.Linq;
using Festifact.API.Interfaces;
using Festifact.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.API.Services
{
    public class ImageRepository : IImageRepository
    {
        private List<Image> _imageList;

        public ImageRepository()
        {
            InitializeData();
        }

        public IEnumerable<Image> All
        {
            get { return _imageList; }
        }

        public bool DoesImageExist(int id)
        {
            return _imageList.Any(image => image.ImageId == id);
        }

        public Image Find(int id)
        {
            return _imageList.FirstOrDefault(image => image.ImageId == id);
        }

        public void Insert(Image item)
        {
            _imageList.Add(item);
        }

        public void Update(Image image)
        {
            var selectedImage = this.Find(image.ImageId);
            var index = _imageList.IndexOf(selectedImage);
            _imageList.RemoveAt(index);
            _imageList.Insert(index, image);
        }

        public void Delete(int ImageId)
        {
            _imageList.Remove(this.Find(ImageId));
        }

        private void InitializeData()
        {
            _imageList = new List<Image>();

            var image1 = new Image
            {
                ImageId = 1,
                ImageData = "https://www.nme.com/wp-content/uploads/2019/08/SZIGET_0939_JF-1.jpg",
                FestivalId = 3
            };

            var image2 = new Image
            {
                ImageId = 2,
                ImageData = "https://www.reisjunk.nl/wp-content/uploads/2014/01/sziget2.jpg",
                FestivalId = 3
            };

            var image3 = new Image
            {
                ImageId = 3,
                ImageData = "https://cdn2.szigetfestival.com/c1os5c8/f851/en/media/2018/01/sziget_og_main.jpg",
                FestivalId = 3
            };

            _imageList.Add(image1);
            _imageList.Add(image2);
            _imageList.Add(image3);
        }

    }
}