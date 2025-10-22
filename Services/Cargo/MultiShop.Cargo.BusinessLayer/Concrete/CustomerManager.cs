using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void TDelete(string id)
        {
            _customerDal.Delete(id);
        }

        public Customer TGet(string id)
        {
            return _customerDal.Get(id);
        }

        public List<Customer> TGetAll()
        {
            return _customerDal.GetAll();
        }

        public void TInsert(Customer entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            _customerDal.Insert(entity);
        }

        public void TUpdate(Customer entity)
        {
            _customerDal.Update(entity);
        }
    }
}
