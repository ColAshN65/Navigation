using Navigation.Base;
using Navigation.Controls;
using Navigation.Example.View;
using Navigation.Example.ViewModel;
using Navigation.Factories;
using Navigation.Services.Reflective;
using Navigation.Services.Static;
using System.Reflection;

namespace Navigation.Example;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        //Your DiContainer could be here.
        var navigationService = NavigationDiContainer();

        //Inject the chosen INavigationService implementation.
        NavigationControl.NavigationService = navigationService;
        NavigationTabControl.NavigationService = navigationService;

        App app = new App(new MainWindow(), new MainWindowViewModel());
        app.Run();
    }

    public static INavigationService NavigationDiContainer()
    {
        INavigationService navigationService;

        //The service will search for matching View types in the Dictionary.
        #region Static Path

        //For static navigation, you must declare a dictionary<Type, Type>
        //where the key must be the ViewModel type and the value must be the View type.

        //This dictionary must include ALL ViewModel and View mappings in the project.
        Dictionary<Type, Type> mvvmPairs = new Dictionary<Type, Type>()
        {
            [typeof(MainWindowViewModel)] = typeof(MainWindow),
            [typeof(ControlPanelViewModel)] = typeof(ControlPanel),
            [typeof(OutputItemHViewModel)] = typeof(OutputItem),
        };

        navigationService = new StaticNavigationService(mvvmPairs);
        #endregion

        //The service will search for matching View types using reflection.
        #region Reflective Path

        //Reflective navigation requires following convention.
        //View and ViewModel types must:
        // -be in specific assemblies,
        // -be distinguished by names with a specific suffix,
        // -be distinguished by namespaces with a specific suffix;

        var navigationSettings = new ReflectiveNavigationSettings(
            "View",         //Distinction in the View namespace
            "ViewModel",    //Distinction in the ViewModel namespace
            "",             //View Suffix
            "ViewModel",    //ViewModel Suffix
            Assembly.GetAssembly(typeof(MainWindow)),
            Assembly.GetAssembly(typeof(MainWindowViewModel)));

        //Explanation:
        //If your View and ViewModels are in different assemblies,
        //for example, "YouProject.View" and "YouProject.ViewModel",
        //and their hierarchy matches, this will still work.


        //You can use the default factory to obtain an instance of ReflectiveNavigationService
        navigationService = new DefaultReflectiveNavigationFactory(navigationSettings).CreateService();

        //Or you can initialize ReflectiveNavigationService yourself using your own IPathTransformer implementation.
        navigationService = new ReflectiveNavigationService(
            navigationSettings,
            new DefaultViewNamespaceTransformer(navigationSettings),    //Your IPathTransformer implementation could be here.
            new DefaultViewNameTransformer(navigationSettings)          //Your IPathTransformer implementation could be here.
            );

        #endregion

        return navigationService;
    }
}
