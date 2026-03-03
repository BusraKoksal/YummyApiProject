using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.FeaturesDtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiProjeKampi.WebApi.Entities;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FeaturesController : ControllerBase

    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public FeaturesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
            //value--> context ile feature entitiese ulaş bu value.
            //daha sonra value değerini al resultfeturedto classı ile mapple.(liste şeklinde) göster 
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            //fetaure sınıfını parantez içi parametreden gelen değer ile mappleme işlemini gerçekleştir.
            //value feature türüne dönüşüyor.
            _context.Features.Add(value);
            _context.SaveChanges();
            return Ok("ekleme işlemi başarılı");
        
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id) 
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("silme başarılı");

        }
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id) 
        {
            var value= _context.Features.Find(id);
            //ham entitye ulaşıp aşağıda dtoya dönüştürüyor.
            _context.SaveChanges();
            return Ok(_mapper.Map<GetByIdFeatureDto>(value));
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var value =_mapper.Map<Feature>(updateFeatureDto);
            _context.Features.Update(value);
            _context.SaveChanges();
            return Ok("güncelleme işlemi başarılı");
        }
    }
}