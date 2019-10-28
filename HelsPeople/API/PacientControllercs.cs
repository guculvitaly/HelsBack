using HelsPeople.EFRepository;
using HelsPeople.ElasticSearch;
using HelsPeople.Model;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelsPeople.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientControllercs : ControllerBase
    {
        private IPacientRepository repository;
        private ElasticConnection elasticConnection;
        public PacientControllercs(IPacientRepository _repository)
        {
            repository = _repository;
            elasticConnection = new ElasticConnection();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result =  repository.FindAll().Where(x => x.Active == true);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pacient model)
        {


            if (model != null)
            {
                await repository.Create(model);
            }

             

            return Ok();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] Pacient model)
        {
            if (model == null)
            {
                return NotFound();
            }

             model.Id = Id;
             await repository.Update(model);
            return Ok(model);
        }

        [HttpPut("delete/{id}")]
        public async Task<IActionResult> Delete(int Id, [FromBody] Pacient model)
        {
            if (model == null)
            {
                return NotFound();
            }

            model.Id = Id;
            await repository.Update(model);
            return Ok();
        }

        [HttpGet("_search/{text}")]
        public async Task<IActionResult> Search(string text)
        {


            var list = repository.FindAll().ToList();


            foreach (var data in list)
            {
                var ndexResponse = elasticConnection.EsClient().IndexDocument(data);
            }

           
          var  mSearchResponse = elasticConnection.EsClient().Search<Pacient>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.FirstName)
                        .Query(text)
                    ) || q
                    .Match(m => m
                        .Field(f => f.LastName)
                        .Query(text)
                    ) || q
                    .Match(v => v
                    .Field(f => f.PhoneNumber)
                    .Query(text))

                    

                )
            );



            var people = mSearchResponse.Documents;

            return Ok(people);
        }
    }
}
