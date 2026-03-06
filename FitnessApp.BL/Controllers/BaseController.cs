using FitnessApp.BL.Services;
using System.Collections.Generic;

namespace FitnessApp.BL.Controllers
{
    public abstract class BaseController
    {
        private readonly IDataSaver _manager = new SerializableSaver();

        protected void Save<T>(List<T> data) where T : class => _manager.Save(data);
        protected List<T> Load<T>() where T : class => _manager.Load<T>();
    }
}
