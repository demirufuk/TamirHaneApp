using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Abstract;
using DAL.Repositories.Concrete;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private TamirhaneContext _tamirhaneContext;
        public UnitOfWork(TamirhaneContext context)
        {
            _tamirhaneContext = context;
            UserRepository = new UserRepository(_tamirhaneContext);
            CarRepository = new CarRepository(_tamirhaneContext);
            AppointmentRepository = new AppointmentRepository(_tamirhaneContext);
        }
        public ICarRepository CarRepository { get; private set; }

        public IAppointmentRepository AppointmentRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public int Complete()
        {
            return _tamirhaneContext.SaveChanges();
        }

        public void Dispose()
        {
            _tamirhaneContext.Dispose();
        }
    }
}
