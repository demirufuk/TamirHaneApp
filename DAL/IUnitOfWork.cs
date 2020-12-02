using DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork:IDisposable
    {
         ICarRepository CarRepository { get;  }
         IAppointmentRepository AppointmentRepository { get; }
         IUserRepository UserRepository { get; }

        int Complete();
    }
}
