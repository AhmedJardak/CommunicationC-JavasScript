using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xam.Plugin.WebView.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            //SampleWebView.Source= "http://169.254.80.80:8080/bonita/loginservice?redirectUrl=portal%2Fhomepage&username=walter.bates&password=bpm" ;
            SampleWebView.Source = "http://169.254.80.80:3000/Home/About";
            FormsWebView.AddGlobalCallback("InvokeFunction", async (p) =>
            {

                var person = JsonConvert.DeserializeObject<Person>(p);
                await DisplayAlert("InvokeFunction", person.Name + person.Password, "OK");
                // var argument = JsonConvert.SerializeObject(person);
                //  await SampleWebView.InjectJavascriptAsync("InvokeFunctionReturnData('" + argument + "')");

            });
            SampleWebView.AddLocalCallback("InvokeFunction",async (p) =>
		    {
		       
                var person = JsonConvert.DeserializeObject<Person>(p);
		       await DisplayAlert("InvokeFunction", person.Name + person.Password, "OK");
		       // var argument = JsonConvert.SerializeObject(person);
             //  await SampleWebView.InjectJavascriptAsync("InvokeFunctionReturnData('" + argument + "')");


            });
            execute.Clicked += Execute_Clicked;     

        }

      

        private async void Execute_Clicked(object sender, EventArgs e)
        {

            // var argument=JsonConvert.SerializeObject(new Person(){Name = "Name",Password = "password"});
            //await SampleWebView.InjectJavascriptAsync("CSharpToJavaScript('" + argument + "')");
            // await SampleWebView.InjectJavascriptAsync("window.addEventListener('message',function(e){ExecuteSampleFunction();},false)");
            // await SampleWebView.InjectJavascriptAsync("document.getElementById('formframe').box= 'allow-same-origin allow-scripts allow-forms allow-pointer-lock allow-popups allow-top-navigation'");

           var message = "data:image/png;charset=utf-8;base64,iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==";
           // var message = "Message From C#";
            await SampleWebView.InjectJavascriptAsync(" var iframeEl = document.getElementById('formframe'); iframeEl.contentWindow.postMessage('"+message+"', '*');");
           
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Password { get; set; }
  
}
}
