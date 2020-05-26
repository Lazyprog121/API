using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webApi.Models;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TBotController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            Hello hello = new Hello();
            string jsonHello = JsonConvert.SerializeObject(hello);

            return jsonHello;
        }


        [HttpGet("mac/{mac}")]
        public async Task<string> GetMac(string mac)
        {
            string keyMac = "at_w29Gb2QzjVe6mkhoh8lvY934dQcV2";
            string urlMac = $"https://api.macaddress.io/v1?apiKey={keyMac}&output=json&search={mac}";

            try
            {
                using (HttpClient htMac = new HttpClient())
                {
                    htMac.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await htMac.GetAsync(urlMac);
                    string jsonMac = await response.Content.ReadAsStringAsync();
                    return jsonMac;
                }
            }
            catch
            {
                Bad bad = new Bad();
                string jsonBad = JsonConvert.SerializeObject(bad);

                return jsonBad;
            }
        }


        [HttpGet("ip/{ip}")]
        public async Task<string> GetIp(string ip)
        {
            string urlIp = $"http://free.ipwhois.io/json/{ip}";

            try
            {
                using (HttpClient htIp = new HttpClient())
                {
                    htIp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await htIp.GetAsync(urlIp);
                    string jsonIp = await response.Content.ReadAsStringAsync();
                    return jsonIp;
                }
            }
            catch
            {
                Bad bad = new Bad();
                string jsonBad = JsonConvert.SerializeObject(bad);

                return jsonBad;
            }
        }


        [HttpGet("gmail/{gmail}")]
        public async Task<string> GetGmail(string gmail)
        {
            string urlGmail = $"https://api.2ip.ua/email.json?email={gmail}";

            try
            {
                using (HttpClient htGmail = new HttpClient())
                {
                    htGmail.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await htGmail.GetAsync(urlGmail);
                    string jsonGmail = await response.Content.ReadAsStringAsync();
                    return jsonGmail;
                }
            }
            catch
            {
                Bad bad = new Bad();
                string jsonBad = JsonConvert.SerializeObject(bad);

                return jsonBad;
            }
        }

        [HttpGet("macip/{mac}&{ip}")]
        public async Task<string> GetMacIP(string mac, string ip)
        {
            string keyMac = "at_w29Gb2QzjVe6mkhoh8lvY934dQcV2";
            string urlMac = $"https://api.macaddress.io/v1?apiKey={keyMac}&output=json&search={mac}";
            string urlIp = $"http://free.ipwhois.io/json/{ip}";

            try
            {
                using (HttpClient htMac = new HttpClient())
                {
                    htMac.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage responseMac = await htMac.GetAsync(urlMac);
                    HttpResponseMessage responseIp = await htMac.GetAsync(urlIp);

                    string jsonMac = await responseMac.Content.ReadAsStringAsync();
                    string jsonIp = await responseIp.Content.ReadAsStringAsync();

                    Mac m = JsonConvert.DeserializeObject<Mac>(jsonMac);
                    Ip i = JsonConvert.DeserializeObject<Ip>(jsonIp);

                    MacIp macIp = new MacIp(m, i);
                    string jsonMacIp = JsonConvert.SerializeObject(macIp);

                    return jsonMacIp;
                }
            }
            catch
            {
                Bad bad = new Bad();
                string jsonBad = JsonConvert.SerializeObject(bad);

                return jsonBad;
            }
        }
    }
}
