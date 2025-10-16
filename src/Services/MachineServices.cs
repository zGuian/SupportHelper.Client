using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SupportHelper.Blazor.Configuration.Environments;
using SupportHelper.Blazor.DTOs;
using SupportHelper.Blazor.DTOs.Machines;
using SupportHelper.Blazor.Interfaces;

namespace SupportHelper.Blazor.Services
{
    public sealed class MachineServices : IMachineServices
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClientOptions _httpClientOptions;

        public MachineServices(IHttpClientFactory httpFactory, IOptions<HttpClientOptions> httpClientOptions)
        {
            _httpClientOptions = httpClientOptions.Value;
            _httpClient = httpFactory.CreateClient("Default");
        }

        public async Task<ResponseBase<IEnumerable<MachineDto>>> RequestGetAllMachineAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/v1/Machines");
                if (!response.IsSuccessStatusCode)
                {
                    return ResponseBase<IEnumerable<MachineDto>>.ReturnFalse("Não foi possivel fazer a chamada da API");
                }
                var jsonString = await response.Content.ReadAsStringAsync();
                var page = JsonConvert.DeserializeObject<GetAllMachineDto<IEnumerable<MachineDto>>>(jsonString);
                if (page != null && page.Datas != null)
                {
                    return ResponseBase<IEnumerable<MachineDto>>.ReturnSuccess(page.Datas);
                }
                return ResponseBase<IEnumerable<MachineDto>>.ReturnFalse();
            }
            catch (Exception ex)
            {
                return ResponseBase<IEnumerable<MachineDto>>.ReturnFalse(ex.Message);
            }
        }

        public async Task<ResponseBase<MachineDto>> RequestOnlyMachineAsync(string hostname)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/v1/Machine/StatusMachine/{hostname}");
                if (!response.IsSuccessStatusCode)
                {
                    return ResponseBase<MachineDto>.ReturnFalse();
                }
                var json = await response.Content.ReadAsStringAsync();
                var machine = JsonConvert.DeserializeObject<MachineDto>(json) ?? throw new Exception();
                return ResponseBase<MachineDto>.ReturnSuccess(machine);
            }
            catch (Exception ex)
            {
                return ResponseBase<MachineDto>.ReturnFalse(ex.Message);
            }
        }

        public Task<ResponseBase<string>> RequestResetSgpClient(string hostname)
        {
            throw new NotImplementedException();
        }
    }
}
