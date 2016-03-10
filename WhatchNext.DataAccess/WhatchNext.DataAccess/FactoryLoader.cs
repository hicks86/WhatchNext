using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatchNext.DataAccess
{
    public class FactoryLoader : Csla.Server.IObjectFactoryLoader
    {
        #region Properties

        public string Assembly
        {
            get;

            set;
        }

        #endregion

        #region Constructors

        public FactoryLoader()
        {
            Assembly = ConfigurationManager.AppSettings["ObjectFactoryAssembly"];
        }

        #endregion

        #region Factory Methods

        public object GetFactory(string factoryName)
        {
            return Activator.CreateInstance(GetFactoryType(factoryName));
        }

        public Type GetFactoryType(string factoryName)
        {
            var typeName = string.Format("{0}.{1},{0}", Assembly, factoryName);

            var factoryType = Type.GetType(typeName);

            if (factoryType == null)
            {
                throw new ArgumentException(string.Format("Can not find type '{0}'", typeName));
            }

            return factoryType;
        }

        #endregion
    }
}
