using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using OratorjuMSSPService.Entities;

namespace OratorjuMSSPService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OratorjuMSSP" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OratorjuMSSP.svc or OratorjuMSSP.svc.cs at the Solution Explorer and start debugging.
    public class OratorjuMSSP : IOratorjuMSSP
    {
        public void DoWork()
        {
        }

        public List<Reading> getReadingsFrom(string date)
        {
            return Utils.getReadingsFrom(date);
        }

        public List<Thought> getThoughtsFrom(string date)
        {
            return UtilsThought.getThoughtsFrom(date);
        }

        public string JSONData(string id)
        {
            return "You requested product " + id;
        }
    }
}
