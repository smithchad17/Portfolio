using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Portfolio.Pages.CallJavascriptPage
{
    public partial class CallJavascript
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        private IJSObjectReference _jsModule;

        private string _registrationResult;
        private string _detailsMessage;

        protected override async Task OnInitializedAsync()
        {
            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "././scripts/CallJSPage.js");
        }

        private async Task ExtractEmailInfo()
        {
            var emailDetails = await _jsModule.InvokeAsync<EmailDetails>("splitEmailDetails", "Please provide your email");
            if (emailDetails != null)
                _detailsMessage = $"Name: {emailDetails.Name}, Server: {emailDetails.Server}, Domain: {emailDetails.Domain}";
            else
                _detailsMessage = "Email is not provided.";
        }

        public async Task ShowAlertWindow() => await _jsModule.InvokeVoidAsync("showAlert", new { Name = "John", Age = 35 });

        public async Task RegisterEmail() => _registrationResult = await _jsModule.InvokeAsync<string>("emailRegistration", "Please provide your email");
        

    }
    public class EmailDetails
    {
        public string Name { get; set; }
        public string Server { get; set; }
        public string Domain { get; set; }
    }
}
