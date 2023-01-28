using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class CustomerService : ICustomerService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private ICustomerRepository _iCustomerRepository;

        public CustomerService()
        {
            _iCustomerRepository = new CustomerRepository();
        }
        public Customer Login(string email, string pass)
        {
            var data = new Customer();
            var temp = _iCustomerRepository.GetAll().FirstOrDefault(c => c.Email == email && c.Password == pass);
            if (temp != null)
            {
                return data = temp;
            }
            else
            {
                return data;
            }
        }
        public bool Create(Customer cv)
        {
            if (cv == null) return false;
            if (_iCustomerRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Customer cv)
        {
            if (cv == null) return false;
            var temp = _iCustomerRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp != null)
            {
                _iCustomerRepository.Delete(temp);
                return true;
            }
            return false;
        }

        public List<Customer> GetAll()
        {
            return _iCustomerRepository.GetAll();
        }

        public bool Update(Customer cv)
        {
            if (cv == null) return false;
            var temp = _iCustomerRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id || c.Customer_Id == cv.Customer_Id);
            if (temp == null) return false;
            temp.Customer_Name = cv.Customer_Name;
            temp.First_name = cv.First_name;
            temp.Middle_name = cv.Middle_name;
            temp.Last_name = cv.Last_name;
            temp.Date_of_birth = cv.Date_of_birth;
            temp.Description = cv.Description;
            temp.Address = cv.Address;
            temp.City = cv.City;
            temp.Country = cv.Country;
            if (_iCustomerRepository.Update(temp))
            {
                return true;
            }
            return false;
        }

        public bool ChangePassword(Customer cv)
        {
            if (cv == null) return false;
            var temp = _iCustomerRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp == null) return false;
            temp.Password = cv.Password;
            if (_iCustomerRepository.Update(temp))
            {
                return true;
            }
            return false;
        }
    }
}
