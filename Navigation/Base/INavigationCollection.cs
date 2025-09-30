using Navigation.Helpers.Events;
using System.ComponentModel;

namespace Navigation.Base;

public interface INavigationCollection
{
    event ItemChangedEventHandler<INotifyPropertyChanged> ItemAdded;
    event ItemChangedEventHandler<INotifyPropertyChanged> ItemDeleted;
    event ItemChangedEventHandler<INotifyPropertyChanged> ItemInserted;
}
