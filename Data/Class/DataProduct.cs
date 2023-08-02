using Web_Ban_Giay_Asp_Net_Core.Data.Interface;
using Web_Ban_Giay_Asp_Net_Core.Entities.Config;

namespace Web_Ban_Giay_Asp_Net_Core.Data.Class
{
    public class DataProduct : IAddData
    {
        public string[] arr_name_products_nike = {"NIKE PEGASUS 40", "NIKE RUN SWIFT 3", "NIKE AIR MAX 90 SE",
            "NIKE AIR FORCE 1 LV8", "NIKE AIR MAX 270 SE", "NIKE GAMMA FORCE",
            "NIKE AIR FORCE 1 '07", "AIR FORCE 1", "NIKE RUN SWIFT 3",
            "NIKE AIR MAX 90", "NIKE REVOLUTION 6 NN", "NIKE PEGASUS 40",
            "NIKE STAR RUNNER 3", "NIKE QUEST 4", "NIKE AIR MAX 97"};

        public string[] arr_name_products_adidas = {"ADIDAS GALAXY 6 W", "ADIDAS ZNCHILL LIGHTMOTION", "ADIDAS RUN FALCON 3.0",
            "ADIDAS ULTRABOOST OG", "ADIDAS ULTRABOOST 20", "ADIDAS FORUM LOW CL",
            "ADIDAS ULTRA 4D", "ADIDAS NMD R1 REFINED", "ADIDAS ULTRA 4D",
            "ADIDAS ZNCHILL LIGHTMOTION", "ADIDAS ULTRA4D SUN DEVILS", "SN1997 X MARIMEKKO",
            "ADIDAS GRADAS CLOUD WHITE", "ADIDAS PUREMOTION", "ADIDAS GRAND COURT"};

        public string[] arr_name_products_jordan = {"JORDAN 1 LOW", "JORDAN 1 LOW LIGHT SMOKE GREY", "JORDAN 1 HI OG",
            "AIR JORDAN 1 HI OG", "JORDAN 1 HI ZOOM CMFT", "AIR JORDAN 1 MID",
            "JORDAN 1 BLACK WHITE RED", "NIKE AIR JORDAN 4 PINE GREEN", "AIR JORDAN 1 HI CHICAGO",
            "JORDAN 1 LOW CRAFT", "JORDAN 1 HI RETRO 85", "AIR JORDAN 1 LOW",
            "AIR JORDAN 1 LOW", "AIR JORDAN 1 LOW SE", "AIR JORDAN 1 LOW"};

        public void AddDataToTable(MyDbContext dbContext)
        {

        }
    }
}
