﻿namespace SignalRApi.DAL
{
    public enum ECity
    {
        Edirne = 1,
        Istanbul = 2,
        Ankara = 3,
        Antalya = 4,
        Bursa = 5,
    }


    public class Visitor
    {
        public int VisitorID { get; set; }
        public ECity City { get; set; }
        public int CityVisitCount { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
