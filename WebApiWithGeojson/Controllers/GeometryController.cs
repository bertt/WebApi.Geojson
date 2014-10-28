using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GeoJSON.Net.Feature;

namespace WebApiWithGeojson.Controllers
{
    public class GeometryController : ApiController
    {
        public HttpResponseMessage GetFirst()
        {
            // return 2 features as geojson
            var f1 = GetFeature(52.4667, 4.75);
            var f2 = GetFeature(52.5667, 4.75);
            var features = new List<Feature>();
            features.Add(f1);
            features.Add(f2);
            var fc = new FeatureCollection(features);
            return Request.CreateResponse(HttpStatusCode.OK, fc);

        }

        private Feature GetFeature(double Latitude, double Longitude)
        {
            var point = new GeoJSON.Net.Geometry.Point(new GeoJSON.Net.Geometry.GeographicPosition(Latitude, Longitude));
            var featureProperties = new Dictionary<string, object> { { "Name", "Foo" } };
            var feature = new Feature(point, featureProperties) { Id = "1" };
            return feature;
        }

    }
}
