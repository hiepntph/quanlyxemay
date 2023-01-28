using Graduation_API.Services.InterfaceServices;
using EF_CODEFIRST_FLUENT_API.DomainClass;
using EF_CODEFIRST_FLUENT_API.Repositories;
using EF_CODEFIRST_FLUENT_API.Repositories.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace Graduation_API.Services.ClassServices
{
    public class EmployeeService:IEmployeeService
    {
        //Đây là ví dụ thì chỉ có 4 chức năng, nhưng trong bài toán thật sẽ có thể có các chứng năng, tìm kiếm chức vụ, lọc chức vụ...., Tại đây sẽ gọi đến rất nhiều repo khác nhau để phục vụ bài toán.
        private IEmployeeRepository _iEmployeeRepository;

        public EmployeeService()
        {
            _iEmployeeRepository = new EmployeeRepository();
        }

        public Employee Login(string email, string pass)
        {
            var data = new Employee();
            var temp = _iEmployeeRepository.GetAll().FirstOrDefault(c => c.Email == email && c.Password == pass);
            if (temp != null)
            {
                return data = temp;
            }
            else
            {
                return data;
            }
        }
        public bool Create(Employee cv)
        {
            if (cv == null) return false;
            if (_iEmployeeRepository.Add(cv))
            {
                return true;
            }
            return false;
        }

        public bool Delete(Employee cv)
        {
            if (cv == null) return false;
            var temp = _iEmployeeRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp == null) return false;
            if (_iEmployeeRepository.Delete(temp))
            {
                return true;
            }
            return false;
        }

        public List<Employee> GetAll()
        {
            return _iEmployeeRepository.GetAll();
        }

        public bool Update(Employee cv)
        {
            if (cv == null) return false;
            var temp = _iEmployeeRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp == null) return false;
            temp.Employee_Name = cv.Employee_Name;
            temp.Middle_name = cv.Middle_name;
            temp.First_name = cv.First_name;
            temp.Last_name = cv.Last_name;
            temp.Sex = cv.Sex;
            temp.Date_Of_Birth = cv.Date_Of_Birth;
            temp.Phone_number = cv.Phone_number;
            temp.Address = cv.Address;
            temp.Store_Id = cv.Store_Id;
            temp.Position_Id = cv.Position_Id;
            temp.Date_Of_Join = cv.Date_Of_Join;
            temp.City = cv.City;
            temp.Country = cv.Country;
            temp.Status = cv.Status;
            if (_iEmployeeRepository.Update(temp))
            {
                return true;
            }
            return false;
        }

        public bool ChangePassword(Employee cv)
        {
            if (cv == null) return false;
            var temp = _iEmployeeRepository.GetAll().FirstOrDefault(c => c.Id == cv.Id);
            if (temp == null) return false;
            temp.Password = cv.Password;
            if (_iEmployeeRepository.Update(temp))
            {
                return true;
            }
            return false;
        }
    }
}
