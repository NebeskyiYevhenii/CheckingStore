using AutoMapper;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class UserService
    {

        private readonly UserRepository _userRepository = new UserRepository();
        private readonly IMapper _mapper;
        public UserService()
        {
            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<UserBL, User>().ReverseMap();

            });

            _mapper = new Mapper(mapperCofig);
            //_resultСheckingRepository = resultСheckingRepository;

        }


        public UserBL Authorization(string Email, string Password)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Email == Email && x.Password == Password);
            return _mapper.Map<UserBL>(user);
        }
    }
}
