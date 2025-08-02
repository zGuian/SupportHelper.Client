using SupportHelper.Blazor.DTOs;
using SupportHelper.Blazor.DTOs.Machines;
using SupportHelper.Blazor.Interfaces;
using SupportHelper.Blazor.ValueObjects;
using System.Text.Json;

namespace SupportHelper.Blazor.Services
{
    public sealed class MachineServices : IMachineServices
    {
        private readonly HttpClient _httpClient;

        public ResponseBase<IEnumerable<MachineDto>> RequestGetAllMachineAsync(int pageCount, int pageSize)
        {
            try
            {
                var list = new List<MachineDto>();
                for (int i = 1; i < 101; i++)
                {
                    list.Add(MachineDto.Create(true, $"M154DX00{i}", true, i.ToString(), i.ToString(), i.ToString(), [
                        NetworkBoard.Create(i.ToString(), i.ToString(), i.ToString(), i.ToString(), true)], i.ToString(), i.ToString()));
                }
                return ResponseBase<IEnumerable<MachineDto>>.ReturnSuccess(list);

                //var response = await _httpClient.GetAsync("api/v1/Machines");
                //if (!response.IsSuccessStatusCode)
                //{
                //    throw new Exception();
                //}
                //var page =  await JsonSerializer.DeserializeAsync<IEnumerable<GetAllMachineDto<MachineDto>>>(
                //    await response.Content.ReadAsStreamAsync()) ?? throw new Exception();
                //return ResponseBase<IEnumerable<MachineDto>>.ReturnSuccess(page.Select(x => x.Datas));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ResponseBase<MachineDto> RequestOnlyMachineAsync(string id)
        {
            try
            {
                return ResponseBase<MachineDto>.ReturnSuccess(MachineDto.Create(true, "M154DSX0028304", true,
                    "Guian", "TBAD", "Win11", [NetworkBoard.Create("Porta RJ45", "10.162.167.28", null, "AC-DF-12-GT-OP", true)], 
                    "10:29:20", "24/04/2025"));

                //var response = await _httpClient.GetAsync($"api/v1/Machines/{id}");
                //if (!response.IsSuccessStatusCode)
                //{
                //    throw new Exception();
                //}
                //var machine = await JsonSerializer.DeserializeAsync<MachineDto>(
                //    await response.Content.ReadAsStreamAsync()) ?? throw new Exception();
                //return ResponseBase<MachineDto>.ReturnSuccess(machine);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
