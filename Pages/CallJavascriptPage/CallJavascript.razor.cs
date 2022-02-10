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

        protected override async Task OnInitializedAsync()
        {
            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "././scripts/index.js");
        }
        public async Task ShowAlertWindow() => await _jsModule.InvokeVoidAsync("showAlert", new { Name = "John", Age = 35 });

        public async Task RegisterEmail() => _registrationResult = await _jsModule.InvokeAsync<string>("emailRegistration", "Please provide your email");
        
            
        
    }
}
