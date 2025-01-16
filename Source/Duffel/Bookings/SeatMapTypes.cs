using System.Collections.Generic;

    public class SeatMap
    {
        public string Id { get; set; }
        public string SliceId { get; set; }
        public string SegmentId { get; set; }
        public List<SeatMapCabin> Cabins { get; set; }
    }

    public class SeatMapCabin
    {
        public int Deck { get; set; }
        public string CabinClass { get; set; }
        public Wings Wings { get; set; }
        public int Aisles { get; set; }
        public List<SeatMapCabinRow> Rows { get; set; }
    }

    public class Wings
    {
        public int FirstRowIndex { get; set; }
        public int LastRowIndex { get; set; }
    }

    public class SeatMapCabinRow
    {
        public List<SeatMapCabinRowSection> Sections { get; set; }
    }

    public class SeatMapCabinRowSection
    {
        public List<SeatMapCabinRowSectionElement> Elements { get; set; }
    }

    public abstract class SeatMapCabinRowSectionElement
    {
        public string Type { get; set; }
    }

    public class SeatMapCabinRowSectionElementSeat : SeatMapCabinRowSectionElement
    {
        public string Designator { get; set; }
        public string Name { get; set; }
        public List<string> Disclosures { get; set; }
        public List<SeatMapCabinRowSectionAvailableService> AvailableServices { get; set; }
    }

    public class SeatMapCabinRowSectionElementBassinet : SeatMapCabinRowSectionElement { }

    public class SeatMapCabinRowSectionElementEmpty : SeatMapCabinRowSectionElement { }

    public class SeatMapCabinRowSectionElementExitRow : SeatMapCabinRowSectionElement { }

    public class SeatMapCabinRowSectionElementLavatory : SeatMapCabinRowSectionElement { }

    public class SeatMapCabinRowSectionElementGalley : SeatMapCabinRowSectionElement { }

    public class SeatMapCabinRowSectionElementCloset : SeatMapCabinRowSectionElement { }

    public class SeatMapCabinRowSectionElementStairs : SeatMapCabinRowSectionElement { }

    public class SeatMapCabinRowSectionAvailableService
    {
        public string Id { get; set; }
        public string PassengerId { get; set; }
        public string TotalAmount { get; set; }
        public string TotalCurrency { get; set; }
    }

