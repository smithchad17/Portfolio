using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Portfolio.Pages
{
    public partial class CallJavascript
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        private IJSObjectReference _jsModule;

        protected override async Task OnInitializedAsync()
        {
            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts/index.js");
        }
        public async Task ShowAlertWindow() => await _jsModule.InvokeVoidAsync("showAlert", new { Name = "John", Age = 35 });
        
            
        
    }
}
