using Cirrious.CrossCore.IoC;

namespace MovieFinder.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
            RegisterAppStart<ViewModels.FirstViewModel>();

            System.Linq.Expressions.Expression.Constant(5);
        }
    }
}