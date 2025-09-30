using Navigation.Base;
using Navigation.Helpers.Events;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Navigation.Services;

public class NavigationCollection : NavigationCollection<INotifyPropertyChanged>;

/// <summary>
///     This modified collection contains <see cref="TViewModel"/> instances and provides events that notify about changes in the collection.  
/// </summary>
public partial class NavigationCollection<TViewModel> : ObservableCollection<TViewModel>, INavigationCollection, IDisposable
    where TViewModel : INotifyPropertyChanged
{

    public event ItemChangedEventHandler<INotifyPropertyChanged> ItemAdded;
    public event ItemChangedEventHandler<INotifyPropertyChanged> ItemDeleted;
    public event ItemChangedEventHandler<INotifyPropertyChanged> ItemInserted;

    public new void Add(TViewModel item)
    {
        base.Add(item);
        ItemAdded?.Invoke(this, new ItemChangedEventArgs<INotifyPropertyChanged>(item, Count - 1));
    }

    public new void Insert(int index, TViewModel item)
    {
        base.Insert(index, item);
        ItemInserted?.Invoke(this, new ItemChangedEventArgs<INotifyPropertyChanged>(item, index));
    }

    public void Remove(TViewModel item)
    {
        int index = IndexOf(item);
        base.Remove(item);
        ItemDeleted?.Invoke(this, new ItemChangedEventArgs<INotifyPropertyChanged>(item, index));
    }

    public new void RemoveAt(int index)
    {
        INotifyPropertyChanged item = Items[index];
        base.RemoveAt(index);
        ItemDeleted?.Invoke(this, new ItemChangedEventArgs<INotifyPropertyChanged>(item, index));
    }

    public void Dispose()
    {
        ItemAdded = null;
        ItemDeleted = null;
        ItemInserted = null;
    }
}



