using System;
using ErrorOr;
using LifeLink.Contracts.Parameter.Responses;
using LifeLink.Models;
using LifeLink.Services.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace LifeLink.Controllers;

[Route("parameter")]
public class ParameterController(IParameterService parameterService) : ApiController 
{
    private readonly IParameterService _parameterService = parameterService;

    [HttpGet("getAllGroupKeys")]
    public IActionResult GetAllGroupKeys() 
    {
        ErrorOr<List<string>> getAllGroupKeyResult = _parameterService.GetAllGroupKeys();

        return getAllGroupKeyResult.Match(
            groupKeys => {
                    return Ok(new KeyResponse(Count: groupKeys.Count, Items: groupKeys));
                },
            errors => Problem(errors));      
    }

    [HttpGet("getAllParameterKeys")]
    public IActionResult GetAllParameterKeys() 
    {
        ErrorOr<List<string>> getAllParameterKeyResult = _parameterService.GetAllParameterKeys();

        return getAllParameterKeyResult.Match(
            parameterKeys => {
                    return Ok(new KeyResponse(Count: parameterKeys.Count, Items: parameterKeys));
                },
            errors => Problem(errors));      
    }

    [HttpGet("getParametersByGroupKey/{GK}")]
    public IActionResult GetParametersByGroupKey(string GK) 
    {
        ErrorOr<List<Parameter>> getAllParametersByGroupKeyResult = _parameterService.GetParameterByGK(GK);

        return getAllParametersByGroupKeyResult.Match(
            parameters => {
                    var list = parameters.Select(MapParameterToResponse).ToList();
                    return Ok(new ParameterListResponse(Count: parameters.Count, Items: list));
                },
            errors => Problem(errors));      
    }

        [HttpGet("getParametersByParameterKey/{PK}")]
    public IActionResult GetParametersByParameterKey(string PK) 
    {
        ErrorOr<List<Parameter>> getAllParametersByParameterKeyResult = _parameterService.GetParameterByPK(PK);

        return getAllParametersByParameterKeyResult.Match(
            parameters => {
                    var list = parameters.Select(MapParameterToResponse).ToList();
                    return Ok(new ParameterListResponse(Count: parameters.Count, Items: list));
                },
            errors => Problem(errors));      
    }

       private static ParameterResponse MapParameterToResponse(Parameter parameter)
    {
        var response = new ParameterResponse(
            parameter.Id,
            parameter.CreatorId,
            parameter.CreateTime,
            parameter.ModifierId,
            parameter.ModifyTime,
            parameter.GroupKey,
            parameter.ParameterKey,
            parameter.Value,
            parameter.ExtraValue
        );

        return response;
    }
}