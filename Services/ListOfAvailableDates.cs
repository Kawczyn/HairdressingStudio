using HairdressingStudio.Services.Interfaces;
using HairdressingStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.Services
{
    public class ListOfAvailableDates : IListOfAvailableDates
    {
        private readonly IStylistsWorkingHoursData _stylistWorkingHoursData;
        private readonly IHairdressingServicesData _hairdressingServicesData;
        public ListOfAvailableDates(IStylistsWorkingHoursData stylistsWorkingHoursData, IHairdressingServicesData hairdressingServicesData)
        {
            _stylistWorkingHoursData = stylistsWorkingHoursData;
            _hairdressingServicesData = hairdressingServicesData;

        }

        public List<ListOfAvailableDatesDTO> GenerateListOfAvailableDates(int stylistId, DateTime day, int hairdressingServicesId)
        {
            WeekdayGenerator weekdayGenerator = new WeekdayGenerator(day);
            var ListWorkingHours = _stylistWorkingHoursData.GetAllStylistsWorkingHours(stylistId).Where(x => x.StartDate>=weekdayGenerator.StartWeek && x.StartDate <= weekdayGenerator.EndWeek).ToList();
            var hairdressingServices = _hairdressingServicesData.GetAllHairdressingServices()
                .Where(x => x.Id == hairdressingServicesId).FirstOrDefault();

            List<ListOfAvailableDatesDTO> listOfAvailableDates = new List<ListOfAvailableDatesDTO>();
            foreach (var item in ListWorkingHours)
            {
                double serviceTime = (double)hairdressingServices.ServiceTime;
                DateTime serviceStartDate = item.StartDate;

                for (DateTime serviceEndDate = item.StartDate.AddHours(serviceTime); serviceEndDate <= item.EndDate; serviceEndDate = serviceEndDate.AddHours(serviceTime))
                {
                    listOfAvailableDates.Add(new ListOfAvailableDatesDTO
                    {
                        ServiceStartDate = serviceStartDate,
                        ServiceEndDate = serviceEndDate,
                        DayOfWeek = (int)serviceStartDate.DayOfWeek,
                        HairdressingServicesId = hairdressingServicesId,
                        StylistId = stylistId
                    });
                    serviceStartDate = serviceEndDate;
                }
            }
            return listOfAvailableDates;
        }
    }
}
