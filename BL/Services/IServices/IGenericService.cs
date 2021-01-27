using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.IServices
{
    public interface IGenericService<T> where T : class
    {
        void Insert(T item);

        bool Delete(T item);

        T GetById(int id);

        IEnumerable<T> GetAll();

        //List<SelectListItem> GetAllItemsAsSelectListItems();

        //bool CheckOnItem(T item);
    }
}
