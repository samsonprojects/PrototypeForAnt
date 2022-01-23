using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sonol.Api.Dtos;
using Sonol.Api.Models;
using Sonol.Api.Services;

namespace Sonol.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeasesScheduleController : Controller
    {
        private readonly IDataService _DataService;
        public LeasesScheduleController(IDataService DataService)
        {
            _DataService = DataService;
        }

        [HttpGet]
        public List<Root> GetRootDocument()
        {
            return GetJsonObject();
        }


        [HttpGet("GetLeaseSchedules")]
        public ResponseRootLeasesScheduleDto GetLeaseSchedules()
        {
            var RequestSchedules = GetJsonObject();
            var ResultData = new ResponseRootLeasesScheduleDto();
            ResultData.LeasesSchedules = new List<ResponseScheduleOfNoticeOfLeasesDto>();

            for(int index =0; index < RequestSchedules.Count; index++ )
            {
                //getleaseSchedule
                var CurrentLeaseSchedule = new RequestScheduleOfNoticeOfLeasesDto();
                CurrentLeaseSchedule.leasesSchedule= RequestSchedules[index].leaseschedule;
                
                //transfrom leaseschedule  to ResponseScheduleOfNoticeOfLeasesDto
                var CurrentLeaseScheduleDto = new ResponseScheduleOfNoticeOfLeasesDto();
                var CurrentResponseScheduleOfNoticeOfLeasesDto = _DataService.TransformScheduleOfNoticeOfLeasesData(CurrentLeaseSchedule);

                //resultData add leasescheduledto
                ResultData.LeasesSchedules.Add(CurrentResponseScheduleOfNoticeOfLeasesDto);

            }

            return ResultData;

        }

        [HttpGet("SearchEntryTextByColumn")]
        public EntryTextDto GetEntryTextByColumnName(string ColumnName,string Text = "")
        {
            GetLeaseSchedules();
            var EntryTextResult = _DataService.GetEntryByColumnName(ColumnName,Text);
            return EntryTextResult;
        }
         

        private List<Root> GetJsonObject()
        {
            
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = "Json";
            string fileName = "SamplesJson.json";
            string fullPath = Path.Combine(currentDirectory, path, fileName);
            using (StreamReader r = new StreamReader(fullPath))
            {
                string json = r.ReadToEnd();
                var jsonResult = JsonSerializer.Deserialize<List<Root>>(json);

                return jsonResult;
            }

        }
        
    }
}