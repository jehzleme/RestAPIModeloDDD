using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestAPIModeloDDD.Application.Dtos;
using RestAPIModeloDDD.Application.Interfaces;

namespace RestAPIModeloDDD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class ProdutoController : ControllerBase
    {
        private readonly IApplicationServiceProduto _applicationServiceProduto;

        public ProdutoController(IApplicationServiceProduto applicationServiceProduto)
        {
            _applicationServiceProduto = applicationServiceProduto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceProduto.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceProduto.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProdutoDto clienteDto)
        {
            try
            {
                if (clienteDto == null)
                    return NotFound();

                _applicationServiceProduto.Add(clienteDto);
                return Ok("Produto cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
