using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.MessageDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public MessagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDto>>(values));
            //value--> context ile feature entitiese ulaş bu value.
            //daha sonra value değerini al resultfeturedto classı ile mapple.(liste şeklinde) göster 
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateMessageDto createMessageDto)
        {
            var value = _mapper.Map<Message>(createMessageDto);
            //fetaure sınıfını parantez içi parametreden gelen değer ile mappleme işlemini gerçekleştir.
            //value feature türüne dönüşüyor.
            _context.Messages.Add(value);
            _context.SaveChanges();
            return Ok("ekleme işlemi başarılı");

        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("silme başarılı");

        }
        [HttpGet("GetFeature")]
        public IActionResult GetMessage(int id)
        {
            var value = _context.Messages.Find(id);
            //ham entitye ulaşıp aşağıda dtoya dönüştürüyor.
            _context.SaveChanges();
            return Ok(_mapper.Map<GetByIdMessageDto>(value));
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<Message>(updateMessageDto);
            _context.Messages.Update(value);
            _context.SaveChanges();
            return Ok("güncelleme işlemi başarılı");
        }
    }
}
