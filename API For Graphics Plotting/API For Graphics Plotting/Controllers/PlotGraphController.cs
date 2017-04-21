using API_For_Graphics_Plotting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_For_Graphics_Plotting.Controllers
{
    public class PlotGraphController : ApiController
    {
        private GraphsCreator CreateGraph;
        // GET: api/Plot
        public IHttpActionResult Get()
        {
            CreateGraph = new GraphsCreator();
            List<Point> XYList = new List<Point>();
            XYList = CreateGraph.GetXY();
            return Ok(XYList);
        }

        // GET api/plotgraph/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/plotgraph
        public void Post([FromBody]string value)
        {
        }

        // PUT api/plotgraph/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/plotgraph/5
        public void Delete(int id)
        {
        }
    }
}
