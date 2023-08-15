using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FeatureManager : IGenericService<Feature>
    {
        //constructor method unutma!!
        IFeatureDal _featureDaL;

        public FeatureManager(IFeatureDal featureDaL)
        {
            _featureDaL = featureDaL;
        }

        public void TAdd(Feature t)
        {
            _featureDaL.Insert(t);
        }

        public void TDelete(Feature t)
        {
            _featureDaL.Delete(t);
        }

        public Feature TGetById(int id)
        {
            return _featureDaL.GetById(id);
        }

        public List<Feature> TGetList()
        {
            return _featureDaL.GetList();
        }

      

        public void TUpdate(Feature t)
        {
            _featureDaL.Update(t);
        }
    }
}
