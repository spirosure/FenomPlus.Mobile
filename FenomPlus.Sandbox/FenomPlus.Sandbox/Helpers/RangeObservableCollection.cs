using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace FenomPlus.Sandbox.Helpers
{
    public class RangeObservableCollection<T> : ObservableCollection<T>, IEnumerable<T>
    {
        /// --------------------------------------------------------------------------------
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="list">List.</param>
        /// --------------------------------------------------------------------------------
        public void AddRange(IEnumerable<T> list)
        {
            if (list == null)
                return;

            foreach (T item in list)
            {
                AddNoNotify(item);
            }

            SendNotifications();
        }

        /// --------------------------------------------------------------------------------
        /// <summary>
        /// Adds the no notify.
        /// </summary>
        /// <param name="item">Item.</param>
        /// --------------------------------------------------------------------------------
        public void AddNoNotify(T item)
        {
            Items.Add(item);
        }

        /// --------------------------------------------------------------------------------
        /// <summary>
        /// Clears the add range.
        /// </summary>
        /// <param name="list">List.</param>
        /// --------------------------------------------------------------------------------
        public void ClearAddRange(IEnumerable<T> list)
        {
            if (list == null)
                return;

            Items.Clear();

            foreach (T item in list)
            {
                Items.Add(item);
            }

            SendNotifications();
        }

        /// --------------------------------------------------------------------------------
        /// <summary>
        /// Sends the notifications.
        /// </summary>
        /// --------------------------------------------------------------------------------
        public void SendNotifications()
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
        }
    }
}