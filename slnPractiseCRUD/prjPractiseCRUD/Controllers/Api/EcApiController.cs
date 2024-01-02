using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prjPractiseCRUD.Models.Dto;
using prjPractiseCRUD.Models.Entity;

namespace prjPractiseCRUD.Controllers.Api
{
    [Route("api/EcApi/[action]")]
    [ApiController]
    public class EcApiController : ControllerBase
    {
        private readonly NorthwindContext _northwindContext;

        public EcApiController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        [HttpGet]
        public IEnumerable<ListDto> GetList()
        {
            return _northwindContext.Ectables.Select(ec => new ListDto
            {
                Id = ec.Id,
                EmployeesName = ec.EmployeesName,
                CustomersName = ec.CustomersName,
            }).ToList();
        }

        [HttpGet("{id}")]
        public DetailDto GetById(int id)
        {
            var queryResult = _northwindContext.Ectables.FirstOrDefault(ec => ec.Id == id);

            if (queryResult != null)
            {
                var mapper = new DetailDto
                {
                    EmployeesName = queryResult.EmployeesName,
                    CustomersName = queryResult.CustomersName
                };

                return mapper;
            }
            return null;
        }

        [HttpPost]
        public bool InsertEc(InsertDto insertDto)
        {
            try
            {
                var mapper = new Ectable
                {
                    EmployeesName = insertDto.EmployeesName,
                    CustomersName = insertDto.CustomersName,
                };

                _northwindContext.Ectables.Add(mapper);
                _northwindContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Web Application Error!", ex);
            }
        }

        [HttpPut("{id}")]
        public bool EditEc(int id, EditDto editDto)
        {
            var queryIdResult = _northwindContext.Ectables.FirstOrDefault(ec => ec.Id == id);

            if (queryIdResult != null)
            {
                queryIdResult.EmployeesName = editDto.EmployeesName;
                queryIdResult.CustomersName = editDto.CustomersName;

                _northwindContext.SaveChanges();

                return true;
            }
            return false;
        }

        [HttpDelete("{id}")]
        public bool DeleteEc(int id)
        {
            var queryIdResult = _northwindContext.Ectables.FirstOrDefault(ec => ec.Id == id);

            if (queryIdResult == null) { return false; }

            try
            {
                _northwindContext.Ectables.Remove(queryIdResult);

                _northwindContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Web Application Error!", ex);
            }
        }
    }
}