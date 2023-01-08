using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace CarWashFrontend.Repository
{
    public class ServiceRepository
    {
        HttpClient client;
        public ServiceRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiBaseURL"].ToString());
        }
        //Method to Get all 
        #region
        public HttpResponseMessage GetResponse(string url)
        {
            return client.GetAsync(url).Result;
        }
        #endregion
        //Method to Add 
        #region
        public HttpResponseMessage PostResponse(string url, object content)
        {
            return client.PostAsJsonAsync(url, content).Result;
        }
        #endregion
        //Method to Delete 
        #region
        public HttpResponseMessage DeleteResponse(string url, int Id)
        {
            return client.DeleteAsync(url + Id.ToString()).Result;
        }
        #endregion
        //Method to Update
        public HttpResponseMessage EditResponse(string url, object content)
        {
            return client.PutAsJsonAsync(url,content).Result;
        }
      
        //Method for Login
        #region
        public HttpResponseMessage VerifyLogin(string url, object model)
        {
            return client.PostAsJsonAsync(url, model).Result;
        }
        #endregion
    }
}


