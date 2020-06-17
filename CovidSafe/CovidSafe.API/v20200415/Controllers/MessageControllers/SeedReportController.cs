﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
<<<<<<< HEAD:CovidSafe/CovidSafe.API/v20200415/Controllers/MessageControllers/SeedReportController.cs
using CovidSafe.API.v20200415.Protos;
using CovidSafe.DAL.Services;
using CovidSafe.Entities.Messages;
=======
using CovidSafe.API.v20200505.Protos;
using CovidSafe.DAL.Services;
using CovidSafe.Entities.Reports;
>>>>>>> master:CovidSafe/CovidSafe.API/v20200505/Controllers/MessageControllers/SeedReportController.cs
using CovidSafe.Entities.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

<<<<<<< HEAD:CovidSafe/CovidSafe.API/v20200415/Controllers/MessageControllers/SeedReportController.cs
namespace CovidSafe.API.v20200415.Controllers.MessageControllers
=======
namespace CovidSafe.API.v20200505.Controllers.MessageControllers
>>>>>>> master:CovidSafe/CovidSafe.API/v20200505/Controllers/MessageControllers/SeedReportController.cs
{
    /// <summary>
    /// Handles requests for infected clients volunteering <see cref="BlueToothSeed"/> identifiers
    /// </summary>
    [ApiController]
<<<<<<< HEAD:CovidSafe/CovidSafe.API/v20200415/Controllers/MessageControllers/SeedReportController.cs
    [ApiVersion("2020-04-15", Deprecated = true)]
=======
    [ApiVersion("2020-05-05")]
>>>>>>> master:CovidSafe/CovidSafe.API/v20200505/Controllers/MessageControllers/SeedReportController.cs
    [Route("api/Messages/[controller]")]
    public class SeedReportController : ControllerBase
    {
        /// <summary>
        /// AutoMapper instance for object resolution
        /// </summary>
        private readonly IMapper _map;
        /// <summary>
<<<<<<< HEAD:CovidSafe/CovidSafe.API/v20200415/Controllers/MessageControllers/SeedReportController.cs
        /// <see cref="MessageContainer"/> service layer
        /// </summary>
        private readonly IMessageService _reportService;
=======
        /// <see cref="InfectionReport"/> service layer
        /// </summary>
        private readonly IInfectionReportService _reportService;
>>>>>>> master:CovidSafe/CovidSafe.API/v20200505/Controllers/MessageControllers/SeedReportController.cs

        /// <summary>
        /// Creates a new <see cref="SeedReportController"/> instance
        /// </summary>
        /// <param name="map">AutoMapper instance</param>
<<<<<<< HEAD:CovidSafe/CovidSafe.API/v20200415/Controllers/MessageControllers/SeedReportController.cs
        /// <param name="reportService"><see cref="MessageContainer"/> service layer</param>
        public SeedReportController(IMapper map, IMessageService reportService)
=======
        /// <param name="reportService"><see cref="InfectionReport"/> service layer</param>
        public SeedReportController(IMapper map, IInfectionReportService reportService)
>>>>>>> master:CovidSafe/CovidSafe.API/v20200505/Controllers/MessageControllers/SeedReportController.cs
        {
            // Assign local values
            this._map = map;
            this._reportService = reportService;
        }

        /// <summary>
        /// Publish a <see cref="SelfReportRequest"/> for distribution among devices relevant to 
        /// <see cref="Region"/>
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
<<<<<<< HEAD:CovidSafe/CovidSafe.API/v20200415/Controllers/MessageControllers/SeedReportController.cs
        ///     PUT /api/Messages/SeedReport&amp;api-version=2020-04-15
=======
        ///     PUT /api/Messages/SeedReport&amp;api-version=2020-05-05
>>>>>>> master:CovidSafe/CovidSafe.API/v20200505/Controllers/MessageControllers/SeedReportController.cs
        ///     {
        ///         "seeds": [{
        ///             "seed": "00000000-0000-0000-0000-000000000001",
        ///             "sequenceStartTime": 1586406048649,
        ///             "sequenceEndTime": 1586408048649
        ///         }],
        ///         "region": {
        ///             "latitudePrefix": 74.12,
        ///             "longitudePrefix": -39.12,
        ///             "precision": 2
        ///         }
        ///     }
        ///
        /// </remarks>
        /// <param name="request"><see cref="SelfReportRequest"/> content</param>
        /// <param name="cancellationToken">Cancellation token (not required in API call)</param>
        /// <response code="200">Submission successful</response>
        /// <response code="400">Malformed or invalid request</response>
        [HttpPut]
        [Consumes("application/x-protobuf", "application/json")]
        [Produces("application/x-protobuf", "application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RequestValidationResult), StatusCodes.Status400BadRequest)]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public async Task<ActionResult> PutAsync(SelfReportRequest request, CancellationToken cancellationToken = default)
        {
            // Get server timestamp at request immediately
            long serverTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            try
            {
                // Parse request
                Entities.Geospatial.Region region = this._map.Map<Entities.Geospatial.Region>(request.Region);
<<<<<<< HEAD:CovidSafe/CovidSafe.API/v20200415/Controllers/MessageControllers/SeedReportController.cs
                IEnumerable<BluetoothSeedMessage> seeds = request.Seeds
                    .Select(s => this._map.Map<BluetoothSeedMessage>(s));
=======
                IEnumerable<BluetoothSeed> seeds = request.Seeds
                    .Select(s => this._map.Map<BluetoothSeed>(s));
>>>>>>> master:CovidSafe/CovidSafe.API/v20200505/Controllers/MessageControllers/SeedReportController.cs

                // Store submitted data
                await this._reportService.PublishAsync(seeds, region, serverTimestamp, cancellationToken);

                return Ok();
            }
            catch (RequestValidationFailedException ex)
            {
                // Only return validation results
                return BadRequest(ex.ValidationResult);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }
    }
}