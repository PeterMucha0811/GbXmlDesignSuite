using GbXmlDesignSuite.Core.Base;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels.Menus
{
    public class AttributesMenuViewModel : RegionViewModelBase
    {
        private readonly IRegionManager _regionManager;

        // Campus Attributes
        public string Xmlns { get; set; }
        public bool UseSIUnitsForResults { get; set; } = true;
        public string TemperatureUnit { get; set; } = "C";
        public string LengthUnit { get; set; }
        public string AreaUnit { get; set; }
        public string VolumeUnit { get; set; }
        public string Version { get; set; }

        // Location Attributes
        public string StationId { get; set; }
        public string ZipcodeOrPostalCode { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Elevation { get; set; }
        public double CADModelAzimuth { get; set; }

        // Building Attributes
        public string BuildingType { get; set; }
        public string BuildingId { get; set; }
        public string StreetAddress { get; set; }
        public double Area { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // gbXML Statistics
        public int Surfaces { get; set; }
        public int Spaces { get; set; }
        public int Storeys { get; set; }
        public int Zones { get; set; }
        public int Openings { get; set; }
        public int Constructions { get; set; }
        public int Materials { get; set; }
        public int Layers { get; set; }
        public int WindowTypes { get; set; }




        public AttributesMenuViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _regionManager = regionManager;

            Xmlns = "http://www.gbxml.org/schema";
            UseSIUnitsForResults = true;
            TemperatureUnit = "C";
            LengthUnit = "Meters";
            AreaUnit = "SquareMeters";
            VolumeUnit = "CubicMeters";
            Version = "6.01";

            StationId = "001";
            ZipcodeOrPostalCode = "14836";
            Longitude = 42.485370;
            Latitude = -77.917300;
            Elevation = 512.0;
            CADModelAzimuth = 0;

            BuildingType = "Residential";
            BuildingId = "001";
            StreetAddress = "11162 County Raod 16, Dalton, NY";
            Area = 340.30384;
            Name = "Mucha's";
            Description = "Single Family Home";

            Surfaces = 110;
            Spaces = 23;
            Storeys = 3;
            Zones = 3;
            Openings = 7;
            Constructions = 5;
            Materials = 45;
            Layers = 33;
            WindowTypes = 18;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}