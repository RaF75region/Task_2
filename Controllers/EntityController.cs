using System;
using Task2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;

namespace Task2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityController:ControllerBase
    {
        private IRepository repository;

        public EntityController(IRepository repository){
            this.repository=repository;
        }

        [HttpPost]
        [Route("AddEntity")]
        public async Task<HttpResponseMessage> InsertDataModel(string JsonStr)
        {
            Entity? obj;
            try{
                obj=JsonSerializer.Deserialize<Entity>(JsonStr);
            }catch (JsonException ex){
                return new HttpResponseMessage(HttpStatusCode.InsufficientStorage);
            }
            if(obj is null){
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            repository.AddEntity(obj);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [HttpGet]
        [Route("GetEntity")]
        [Produces("application/json")]
        public async Task<JsonResult> GetEntity(Guid id)
        {
            Entity? obj=repository.GetEntity(id);
            if(obj is null){
                return new JsonResult("Объект не найден");
            }
            
            return new JsonResult(obj);
        }  

        [HttpGet]
        [Route("GetEntitys")]
        [Produces("application/json")]
        public async Task<JsonResult> GetEntitys()
        {            
            return new JsonResult(repository.Entitys);
        }            
    }
}
