using FormulaCalculation.Interfaces;
using FormulaCalculation.Services;
using Ninject.Modules;
using Ninject;

namespace FormulaCalculation
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IJSON>().To<JSON>();
            Bind<ICalculator>().To<Calculator>();
        }
    }
}
