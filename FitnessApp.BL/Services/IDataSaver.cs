using System.Collections.Generic;

namespace FitnessApp.BL.Services
{
    internal interface IDataSaver
    {
        void Save<T>(List<T> data) where T : class;
        List<T> Load<T>() where T : class;
    }
}
