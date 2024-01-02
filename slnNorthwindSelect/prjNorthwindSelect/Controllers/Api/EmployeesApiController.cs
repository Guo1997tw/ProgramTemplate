using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prjNorthwindSelect.Models.Dto;
using prjNorthwindSelect.Models.Entity;

namespace prjNorthwindSelect.Controllers.Api
{
    [Route("api/EmployeesApi/[action]")]
    [ApiController]
    public class EmployeesApiController : ControllerBase
    {
        private readonly NorthwindContext _northwindContext;

        public EmployeesApiController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        [HttpGet]
        public IEnumerable<EmployeeDto> GetEmployeesList()
        {
            try
            {
                var queryResult = _northwindContext.Employees.Select(e => new EmployeeDto
                {
                    LastName = e.LastName,
                }).ToList();

                return queryResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Data not found is error!");
            }
        }

        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomerList()
        {
            try
            {
                var queryResult = _northwindContext.Customers.Select(c => new CustomerDto
                {
                    CustomerId = c.CustomerId,
                }).ToList();

                return queryResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Data not found is error!");
            }
        }

        [HttpGet]
        public IEnumerable<InsertListDto> GetAllList()
        {
            return _northwindContext.Ectables.Select(ec => new InsertListDto
            {
                LastName = ec.EmployeesName,
                CustomerId = ec.CustomersName
            }).ToList();
        }

        [HttpPost]
        public bool CreateData(InsertDto insertDto)
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
                throw new Exception("Data not found is error!");
            }
        }
    }
}