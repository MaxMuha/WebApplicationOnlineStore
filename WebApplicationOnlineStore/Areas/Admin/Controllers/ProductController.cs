using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using WebApplicationOnlineStore.Areas.Admin.Models;
using WebApplicationOnlineStore.Helpers;

namespace WebApplicationOnlineStore.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProducts productsRepository;
        private readonly ImagesProvider imagesProvider;
        public ProductController(IProducts productsRepository, ImagesProvider imagesProvider)
        {
            this.productsRepository = productsRepository;
            this.imagesProvider = imagesProvider;
        }

        public IActionResult Index()
        {
            var products = productsRepository.GetAll();
            return View(products.ToProductViewModels());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var imagesPaths = imagesProvider.SafeFiles(product.UploadedFiles, ImageFolders.Products);

            productsRepository.Add(product.ToProduct(imagesPaths));

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            return View(product.ToEditProductViewModel());
        }

        [HttpPost]
        public IActionResult Edit(EditProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var addedImagesPaths = imagesProvider.SafeFiles(product.UploadedFiles, ImageFolders.Products);
            product.ImagesPaths = addedImagesPaths;
            productsRepository.Update(product.ToProduct());
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            productsRepository.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
