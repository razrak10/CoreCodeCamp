using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using CoreCodeCamp.Data;
using CoreCodeCamp.Helpers;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    public class CampsController : ControllerBase
    {
        private readonly ICampRepository _campRepository;
        private readonly IMapper<CampModel, Camp> _campMapper;

        public CampsController(ICampRepository campRepository, IMapper<CampModel, Camp> campMapper)
        {
            _campRepository = campRepository;
            _campMapper = campMapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampModel>>> GetCamps()
        {
            try
            {
                Camp[] results = await _campRepository.GetAllCampsAsync();

                IEnumerable<CampModel> models = _campMapper.MapMultiple(results);

                return Ok(models);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{moniker}")]
        public async Task<ActionResult<CampModel>> GetCamp(string moniker)
        {
            try
            {
                var result = await _campRepository.GetCampAsync(moniker);

                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    CampModel model = _campMapper.MapSingle(result);

                    return model;
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
