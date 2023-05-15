
namespace GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels.Models
{
    public class GbXMLModel
    {
        public HouseModel House { get; set; }

        public GbXMLModel()
        {
            House = HouseModel.CreateHouseModel(10, 5, 10);
        }
    }
}
