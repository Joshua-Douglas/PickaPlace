using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;

namespace PickaPlace
{
    class MapHelper
    {
        private MapControl fMap;
        public MapHelper(MapControl aMap)
        {
            fMap = aMap;
            fMap.MapServiceToken = "H0f4DvKp7xN8IPSykRBC~meIYzGRkcnxb14iVEVbIdQ~An-bH2h05-4L8s3QX_ImQjM0gvje-VHSBUIJoHJfrBjRLtMOQPhtfYgx8Z7U44fs";
        }
        public void SetInitialMapView()
        {
            fMap.Center = new Geopoint(new BasicGeoposition { Latitude = 34.150440, Longitude = -118.099550 });
            fMap.ZoomLevel = 20;
            fMap.Style = MapStyle.AerialWithRoads;
        }
    }
}
