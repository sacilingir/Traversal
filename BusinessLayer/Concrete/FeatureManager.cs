﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FeatureManager:IFeatureService
    {
        IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

      

        public void TAdd(Feature t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Feature t)
        {
            throw new NotImplementedException();
        }

        public Feature TGetByID(Feature t)
        {
            throw new NotImplementedException();
        }

        public Feature TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Feature> TGetList()
        {
            return _featureDal.GetList();
        }

        public void TUpdate(Feature t)
        {
            throw new NotImplementedException();
        }
    }
}
