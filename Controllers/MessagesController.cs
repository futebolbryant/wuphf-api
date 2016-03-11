using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using Models;
using Services;

namespace wuphf_api.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly IAsyncRepository<Message> _messageRepository;

        public MessagesController(IAsyncRepository<Message> messageRepository)
        {
            _messageRepository = messageRepository;
        }
        
        [HttpGet]
        public async Task<List<Message>> Get()
        {
            return await _messageRepository.FindAll();
        }

        [HttpPost]
        public async Task<Message> Post([FromBody]Message message)
        {
            message.Id = Guid.NewGuid().ToString();
            message.Created = DateTime.UtcNow.Ticks;
            await _messageRepository.Save(message);
            return message;
        }

        [HttpDelete("{id}")]
        public async void Delete(String id)        
        {
            await _messageRepository.Delete(id);
        }
    }
}
