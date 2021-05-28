using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Bunit.Extensions;

namespace blazor_wasm_todo.Pages
{
    public partial class Index
    {
        [Inject] private Blazored.LocalStorage.ILocalStorageService localStorage { get; set; }
        private string value { get; set; }


        public async Task Save()
        {
            await localStorage.SetItemAsync("name", value);
            value = "";
        }

        public async Task Read()
        {
            var result = await localStorage.GetItemAsync<string>("name");
            value = result.IsNullOrEmpty() ? "" : result;
        }
    }
}