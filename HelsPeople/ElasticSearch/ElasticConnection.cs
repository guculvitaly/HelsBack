using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelsPeople.ElasticSearch
{
    public class ElasticConnection
    {
        

        public ElasticClient EsClient()
        {
            var nodes = new Uri[]
            {
                new Uri("http://localhost:9200/"),
            };

            var connectionPool = new StaticConnectionPool(nodes); 
            var connectionSettings = new ConnectionSettings(connectionPool).DefaultIndex("index").DisableDirectStreaming();

          
            var elasticClient = new ElasticClient(connectionSettings);

            return elasticClient;
        }
    }
}
