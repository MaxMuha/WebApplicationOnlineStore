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

        public async Task<IActionResult> Index()
        {
            var products = await productsRepository.GetAllAsync();
            return View(products.ToProductViewModels());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var imagesPaths = imagesProvider.SafeFiles(product.UploadedFiles, ImageFolders.Products);

            await productsRepository.AddAsync(product.ToProduct(imagesPaths));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditAsync(Guid productId)
        {
            var product = await productsRepository.TryGetByIdAsync(productId);
            return View(product.ToEditProductViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(EditProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var addedImagesPaths = imagesProvider.SafeFiles(product.UploadedFiles, ImageFolders.Products);
            product.ImagesPaths = addedImagesPaths;
            await productsRepository.UpdateAsync(product.ToProduct());
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveAsync(Guid productId)
        {
            var product = await productsRepository.TryGetByIdAsync(productId);
            await productsRepository.RemoveAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
