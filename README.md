# Navigation
##  What's the problem?
If you want to place a UserControl within another UserControl and also want to link their ViewModels, you'll run into a problem.

Suppose you have a main UserControl called Parent, and within it there can be various UserControls (Child1, Child2, Child3, etc.), and the change depends on the data received by the ParentViewModel.

You can write in ParentViewModel.cs:

```public UserControl ChildView { get; set; }```

And in Parent.xaml:

```<UserControl Content="{Binding ChildView}"/>```

But this is a bad solution, as it forces your ViewModel assembly to depend on your ViewModel assembly, even though, according to MVVM rules, it should be the other way around.
This also creates inconvenience, since the ParentViewModel is now responsible not only for the ChildViewModel, but also for the Child View.

## How can I solve this problem?

You can delegate the responsibility for initializing the required Views to a third-party service. This service will receive the ViewModel type and initialize the corresponding View instance.

Now your ParentViewModel stores only the ChildViewModel instance as a property:

```public ChildViewModel ChildVm { get; set; }```

Parent.xaml contains a NavigationControl with a ViewModel property. This property is bound to the ChildVm property in the ViewModel, and when this property changes, the NavigationControl initializes an instance of the corresponding View via the NavigationService and assigns it a DataContext.

```<NavigationControl ViewModel="{Binding ChildVm}"/>```

## How can I use this?

There are two implementations of NavigationService. You can see an example of their use in Navigation.Example.

Before starting the program, you need to initialize the service for NavigationControl.cs or NavigationTabControl.cs.
Currently, this is done through a static field in these classes. Dependency injection will be implemented in the future.

The first implementation uses a dictionary with the ViewModel type as the key and the View type as the value. To use it, you need to store all View and ViewModel relationships in this dictionary.

The second implementation uses reflection and presets. To use it, you need to follow the convention when writing code and also reflect the convention in ReflectiveNavigationSettings.
