namespace BulgarianTechGear.Controllers
{
    using AutoMapper;
    using Models.MobilePhone;
    using Microsoft.AspNetCore.Mvc;
    using Data;
    using BulgarianTechGear.Data.Models;
    using Models.MobilePhones;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class MobilePhoneController : Controller
    {
        private readonly BulgarianTechGearDbContext _data;
        private readonly IMapper _mapper;

        public MobilePhoneController(BulgarianTechGearDbContext data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public IActionResult All()
        {
            var phones = _data
                .MobilePhones
                .OrderByDescending(x => x.Id)
                .Select(
                    x => new MobilePhoneListingViewModel
                    {
                        Id = x.Id,
                        Model = x.Model,
                        Price = x.Price,
                        Year = x.Year,
                        Url = x.Url!,
                        MobilePhoneBrand = _data.MobilePhoneBrands
                            .Where(z => z.Id == x.Id)
                            .Select(z => z.Brand)
                            .Single()
                    }).ToList();

            return View(new AllPhonesQueryModel
            {
                Phones = phones
            });
        }

        [HttpPost]
        public IActionResult All(string searchTerm)
        {
            var phoneQuery = _data.MobilePhones.Where(x => x.Model.ToLower().Contains(searchTerm.ToLower())).ToList();

            var data = 
                _mapper.Map<List<MobilePhone>, List<MobilePhoneListingViewModel>>(phoneQuery);
            return View(new AllPhonesQueryModel
            {
                Phones = data,
                SearchTerm = searchTerm
            });
        }

        public IActionResult Add()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            var data= _data.MobilePhoneBrands.ToList();
            foreach (var mobilePhoneBrand in data)
            {
                obj.Add(new SelectListItem(mobilePhoneBrand.Brand,mobilePhoneBrand.Id.ToString()));
            }

            ViewBag.Brand = obj;
            return View();
        }


        [HttpPost]
        public IActionResult Add(AddMobilePhoneFromModel phone)
        {
            MobilePhone mobile = new MobilePhone();
            if (!_data.MobilePhoneBrands.Any(m => m.Id == phone.BrandId))
            {
                this.ModelState.AddModelError(nameof(phone.BrandId), "The brand does not exist!");
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction("All");
            }

            mobile = _mapper.Map<MobilePhone>(phone);

            _data.Add(mobile);
            _data.SaveChanges();

            return this.RedirectToAction(nameof(All));
        }

        public IEnumerable<MobilePhoneBrandViewCategory> GetPhoneBrands()
        {
            var result =_data.MobilePhoneBrands.Select(
                m => new MobilePhoneBrandViewCategory
                {
                    Id = m.Id,
                    Brand = m.Brand
                }).AsEnumerable();
            return result;
        }
    }
}
