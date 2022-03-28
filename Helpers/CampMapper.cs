using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreCodeCamp.Data;
using CoreCodeCamp.Models;

namespace CoreCodeCamp.Helpers
{
    public class CampMapper : IMapper<CampModel, Camp>
    {
        public IEnumerable<CampModel> MapMultiple(IEnumerable<Camp> results)
        {
            IEnumerable<CampModel> models = results.Select(c =>
            {
                return new CampModel()
                {
                    Name = c.Name,
                    Moniker = c.Moniker,
                    EventDate = c.EventDate,
                    Length = c.Length
                };
            });

            return models;
        }

        public CampModel MapSingle(Camp result)
        {
            return new CampModel()
            {
                Name = result.Name,
                Moniker = result.Moniker,
                EventDate = result.EventDate,
                Length = result.Length
            };
        }

    }

}
