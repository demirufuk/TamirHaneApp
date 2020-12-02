using Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TamirhaneDBInitializer: DropCreateDatabaseAlways<TamirhaneContext>
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new TamirhaneContext());
        protected override void Seed(TamirhaneContext context)
        {
            User user = new User();
            user.Id = 1;
            user.Name = "Ufuk";
            user.LastName = "Demir";
            user.Telephone = "5382154546";
            user.Email = "ufuk@gmail.com";
            user.IsActive = true;
            user.CreatedDate = DateTime.Now;

            unitOfWork.UserRepository.Add(user);
            unitOfWork.Complete();

            base.Seed(context);
        }
    }
}
