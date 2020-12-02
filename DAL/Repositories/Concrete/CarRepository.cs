﻿using DAL.Repositories.Abstract;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Concrete
{
    public class CarRepository:Repository<Car>,ICarRepository
    {
        public CarRepository(TamirhaneContext context):base(context)
        {
        }
    }
}
