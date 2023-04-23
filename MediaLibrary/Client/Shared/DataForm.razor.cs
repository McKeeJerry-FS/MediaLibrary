using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace MediaLibrary.Client.Shared
{
    public partial class DataForm<TModel>
        where TModel : MediaLibrary.Shared.Models.IModel, new()
    {
        [Inject] 
        HttpClient Http { get; set; } = null;
        [Inject]
        NavigationManager Navigation { get; set; } = null;
        [Parameter]
        [EditorRequired]
        public string ApiPath { get; set; } = String.Empty;
        [Parameter]
        [EditorRequired]
        public int Id { get; set; }
        private string _errorMessage = String.Empty;
        
        [Parameter]
        public RenderFragment<TModel> ChildContent { get; set; }

        public TModel Model { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await GetModel();
        }

        private async Task GetModel()
        {
            Model = await Http.GetFromJsonAsync<TModel>($"rest/{ApiPath}/{Id}") ?? new();
        }

        private async Task SaveItem()
        {
            HttpResponseMessage response = Id <= 0 ?
                await Http.PostAsJsonAsync($"rest/{ApiPath}", Model) :
                await Http.PutAsJsonAsync($"rest/{ApiPath}/{Id}", Model);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    if (response.Headers.TryGetValues("location", out var urls))
                    {
                        Navigation.NavigateTo(urls.First(), replace: true);
                    }
                }

                await GetModel();
            }
            else
            {
                _errorMessage = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
