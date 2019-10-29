using HelsPeople.ElasticSearch;
using HelsPeople.Model;
using HelsPeople.Repository;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelsPeople.EFRepository
{
    public class EFSearchRepository : RepositoryBase<Pacient>, ISearchRepository
    {
        private ElasticConnection elasticConnection;
        public EFSearchRepository(ApplicationContext context) : base(context)
        {
            elasticConnection = new ElasticConnection();
        }

        public IReadOnlyCollection<Pacient> Search(string query)
        {
            
            var res = _context.Pacients.ToList();

            foreach (var data in res)
            {
                var ndexResponse = elasticConnection.EsClient().IndexDocument(data);
            }

            var search = elasticConnection.EsClient().Search<Pacient>(s => s 
                  .Query(q => q
                      .MultiMatch(mm => mm
                           .Fields(f => f
                              .Field(ff => ff.FirstName)
                              .Field(ff => ff.LastName)
                              .Field(ff => ff.PhoneNumber)
                              .Field(ff => ff.MiddleName)
                              
                              
                          )
                          .Type(TextQueryType.PhrasePrefix)
                          .Query(query)
                          .MaxExpansions(50)
                      )
                      
                  )
              );
            var people = search.Documents;

            
            return people;
        }
    }
}
