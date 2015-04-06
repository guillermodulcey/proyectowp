using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace organizate.Net
{
    public class Mongo<T>
    {
        public interface IMongo
        {
            void loadDocuments(List<T> documents);
        }

        const String URL_BASE = "https://api.mongolab.com/api/1/databases/";
        HttpClient client;

        String apiKey;
        String dbName;
        String collectionName;

        String url;

        //IMongo iMongo;

        public Mongo(String apiKey, String dbName, String collectionName) { 
            client = new HttpClient();
            this.apiKey = apiKey;
            this.dbName = dbName;
            this.collectionName = collectionName;
            url = URL_BASE + dbName + "/collections/" + collectionName + "?apiKey=" + apiKey;
        }

        public async void insertDocument(T document) {
            JsonSerializerSettings property = new JsonSerializerSettings();
            property.NullValueHandling = NullValueHandling.Ignore;

            String json = JsonConvert.SerializeObject(document, Formatting.None, property);
            HttpStringContent content = new HttpStringContent(json);
            HttpMediaTypeHeaderValue contentType = new HttpMediaTypeHeaderValue("application/json");
            content.Headers.ContentType = contentType;

            await client.PostAsync(new Uri(url), content);
        }

        public async void editDocument(T document, String documentId)
        {
            JsonSerializerSettings property = new JsonSerializerSettings();
            property.NullValueHandling = NullValueHandling.Ignore;

            String json = JsonConvert.SerializeObject(document, Formatting.None, property);
            HttpStringContent content = new HttpStringContent(json);
            HttpMediaTypeHeaderValue contentType = new HttpMediaTypeHeaderValue("application/json");
            content.Headers.ContentType = contentType;

            String urlRequest = URL_BASE + dbName + "/collections/" + collectionName + "/" + documentId+ "?apiKey=" + apiKey;
            await client.PostAsync(new Uri(urlRequest), content);
        }

        public async void findByLogin(String login, IMongo iMongo) {
            String query = "{\"Login\": "+login+" }";
            String urlRequest = URL_BASE + dbName + "/collections/" + collectionName + "?q="+query+"&apiKey=" + apiKey;
            HttpResponseMessage msg = await client.GetAsync(new Uri(url));
            String jsonArray = msg.Content.ToString();

            List<T> data = JsonConvert.DeserializeObject<List<T>>(jsonArray);
            iMongo.loadDocuments(data);
        }

        public async void findActividades(String usuario, IMongo iMongo)
        {
            String query = "{\"Usuario\": " + usuario + " }";
            String urlRequest = URL_BASE + dbName + "/collections/" + collectionName + "?q=" + query + "&apiKey=" + apiKey;
            HttpResponseMessage msg = await client.GetAsync(new Uri(url));
            String jsonArray = msg.Content.ToString();            
            
            List<T> data = JsonConvert.DeserializeObject<List<T>>(jsonArray);
            iMongo.loadDocuments(data);
        }

        public async void findActividadesFecha(String usuario, String fecha, IMongo iMongo)
        {
            String query = "{\"Usuario\": " + usuario + ", \"Fecha\": " + fecha + " }";
            String urlRequest = URL_BASE + dbName + "/collections/" + collectionName + "?q=" + query + "&apiKey=" + apiKey;
            HttpResponseMessage msg = await client.GetAsync(new Uri(url));
            String jsonArray = msg.Content.ToString();

            List<T> data = JsonConvert.DeserializeObject<List<T>>(jsonArray);
            iMongo.loadDocuments(data);
        }
    }
}
