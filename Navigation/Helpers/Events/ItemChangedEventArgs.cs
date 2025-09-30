namespace Navigation.Helpers.Events
{
    public class ItemChangedEventArgs<T> : EventArgs
    {
        public T Item { get; }
        public int Index { get; }

        public ItemChangedEventArgs(T item, int index)
        {
            Item = item;
            Index = index;
        }
    }
}
