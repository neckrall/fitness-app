using System;

namespace FitnessApp.CMD.Views
{
    internal abstract class BaseView
    {
        public BaseView()
        {
            Console.Clear();
            Console.ResetColor();
        }

        protected abstract void Run();
    }
}
