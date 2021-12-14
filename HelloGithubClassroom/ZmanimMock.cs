using System;

namespace PDFGenerator
{ 
    public class ZmanimMock : IZmanimGetter
    {
        private readonly DateTime _juneSolstice = new DateTime(1, 6, 21);
        private readonly DateTime _juneSolsticeSunrise = new DateTime(1, 6, 21, 5, 24, 0);
        private readonly DateTime _juneSolsticeSunset = new DateTime(1, 6, 21, 20, 30, 0);

        private TimeSpan GetHalachicHours(DateTime date)
        {
            return GetSunset(date).Subtract(GetSunrise(date)) / 12;
        }

        public DateTime GetSunrise(DateTime date)
        {
            var testDate = new DateTime(1, date.Month, date.Day);
            var distance = (_juneSolstice - testDate).Days;
            var sunrise = testDate > _juneSolstice ? _juneSolsticeSunrise.AddMinutes(-distance) : _juneSolsticeSunrise.AddMinutes(distance);

            return new DateTime(date.Year, date.Month, date.Day, sunrise.Hour, sunrise.Minute, sunrise.Second);
        }

        public DateTime GetSunset(DateTime date)
        {
            var testDate = new DateTime(1, date.Month, date.Day);
            var distance = (_juneSolstice - testDate).Days;
            var sunset = testDate > _juneSolstice ? _juneSolsticeSunset.AddMinutes(distance) : _juneSolsticeSunset.AddMinutes(-distance);

            return new DateTime(date.Year, testDate.Month, testDate.Day, sunset.Hour, sunset.Minute, sunset.Second);
        }

        public DateTime GetSofShema(DateTime date)
        {
            return GetSunrise(date).Add(GetHalachicHours(date) * 3);
        }

        public DateTime GetZmanTefillah(DateTime date)
        {
            return GetSunrise(date).Add(GetHalachicHours(date) * 4);
        }

        public DateTime GetChatzot(DateTime date)
        {
            return GetSunrise(date).Add(GetHalachicHours(date) * 6);
        }

        public DateTime GetMGedolah(DateTime date)
        {
            return GetSunrise(date).Add(GetHalachicHours(date) * 6.5);
        }

        public DateTime GetMKetana(DateTime date)
        {
            return GetSunrise(date).Add(GetHalachicHours(date) * 9.5);
        }

        public DateTime GetPlag(DateTime date)
        {
            return GetSunrise(date).Add(GetHalachicHours(date) * 10.75);
        }
    }
}
