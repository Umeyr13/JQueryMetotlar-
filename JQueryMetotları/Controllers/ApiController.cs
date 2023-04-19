using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace JQueryMetotları.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api
        public ActionResult Index()
        {
            return View();
        }


        //string prompt = "Hello, my name is ChatGPT and I am a chatbot. What's your name?";
        //string modelId = "gpt-3.5-turbo";
        //string url = "https://api.openai.com/v1/completions";

        private readonly string apiKey = "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";

        public async Task<ActionResult> MesajGonder(string mesaj)
        {
            var client = new RestClient("https://api.openai.com/v1/");
            var request = new RestRequest("chat/completions", Method.Post);
            request.AddHeader("Authorization", "Bearer" + apiKey);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("engine","text-davinci-002");
            //request.AddParameter("prompt", "User: " + mesaj + "\nBot:");
            request.AddParameter("prompt", $"User: {mesaj}\nBot:");
            request.AddParameter("temperature", 0.5);
            request.AddParameter("max_tokens", 50);
            request.AddParameter("n", 1);
            request.AddParameter("stop", "\n");

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                
                var botResponse = JsonObject.Parse(response.Content)["choices"][0]["text"].ToString().Trim();
                return Json(new { response=botResponse });
            }
            else
            {
                return Json(new { response = "API Error" });
            }


            
        }

    }

  

   
}