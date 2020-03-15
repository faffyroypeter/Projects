using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace BankTermDepositPredictor
{
    public partial class Form1 : Form
    {

        private string urlPath = "http://7222e82a-7e2c-44f0-ad77-3eb6a9219610.centralus.azurecontainer.io/score";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Set the scoring URI and authentication key or token
            string scoringUri = urlPath;
            string authKey = string.Empty;

            // Set the data to be sent to the service.
            // In this case, we are sending two sets of data to be scored.
            InputData payload = new InputData();
            payload.data = new string[,] {
                    {
                    "57",
                    "'technician'",
                    "'married'",
                    "'high.school'",
                    "'no'",
                    "'no'",
                    "'yes'",
                    "'cellular'",
                    "'may'",
                    "371",
                    "1",
                    "999",
                    "1",
                    "'failure'",
                    "-1.8",
                    "92.89299999999999",
                    "-46.2",
                    "1.2990000000000002",
                    "5099.1"
                    }
               };
          

            // Create the HTTP client
            HttpClient client = new HttpClient();
            // Set the auth header. Only needed if the web service requires authentication.
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authKey);

            // Make the request
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, new Uri(scoringUri));
                request.Content = new StringContent(JsonConvert.SerializeObject(payload));
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.SendAsync(request).Result;
                // Display the response from the web service
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
            catch (Exception exc)
            {
                Console.Out.WriteLine(exc.Message);
            }
        }
    }
}
