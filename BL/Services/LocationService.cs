using AutoMapper;
using BL.Models;
using BL.Services.IServices;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class LocationService : ILocationServices
    {
        private readonly GenericRepository<Location> _locationRepository;
        private readonly IMapper _mapper;
        public LocationService(GenericRepository<Location> locationRepository)
        {
            

            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<LocationBL, Location>().ReverseMap();
                cgf.CreateMap<IEnumerable<LocationBL>, IEnumerable<Location>>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);

            _locationRepository = locationRepository;
        }




        public bool Delete(LocationBL item)
        {
            try
            {
                if (item == null)
                    throw new ArgumentException("Location is null");

                _locationRepository.Delete(_mapper.Map<Location>(item));

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Location item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocationBL> GetAll()
        {
            try
            {
                var Locations = _locationRepository.GetAll();

                return _mapper.Map<IEnumerable<LocationBL>>(Locations);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("LocationService.cs, some error:" + "\n" + ex.Message);
            }
        }

        public LocationBL GetById(int id)
        {
            try
            {
                var Location = _locationRepository.Get(x=>x.Id == id);

                return _mapper.Map<LocationBL>(Location);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("LocationService.cs, some error:" + "\n" + ex.Message);
            }

            throw new NotImplementedException();
        }

        public void Insert(LocationBL item)
        {
            try
            {
                _locationRepository.Insert(_mapper.Map<Location>(item));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("LocationService.cs, some error:" + "\n" + ex.Message);
            }
        }






        public void Insert(Location item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Location> IGenericService<Location>.GetAll()
        {
            try
            {
                var Locations = _locationRepository.GetAll();

                return Locations;//_mapper.Map<IEnumerable<LocationBL>>(Locations);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("LocationService.cs, some error:" + "\n" + ex.Message);
            }

            throw new NotImplementedException();
        }


        Location IGenericService<Location>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
