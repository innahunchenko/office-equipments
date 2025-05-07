using OfficeEquipment.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace OfficeEquipment.Service.ObservableCollections
{
    public class EntityChangedEventArgs<TEntity> : EventArgs
    {
        public TEntity Item { get; set; }
    }

    public class BaseCollection<TEntity> : ObservableCollection<TEntity> where TEntity : BaseViewModel
    {
        public event EntityChangedEventHandler ItemChanged;
        public delegate void EntityChangedEventHandler(object sender, EntityChangedEventArgs<TEntity> args);

        public BaseCollection()
            : base()
        {
            this.CollectionChanged += observable_CollectionChanged;
        }

        public BaseCollection(List<TEntity> entities)
            : this()
        {
            foreach (TEntity entity in entities)
            {
                this.Add(entity);
            }
        }

        void observable_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (TEntity item in e.NewItems)
                    item.PropertyChanged += observable_ItemChanged;
            }
        }

        void observable_ItemChanged(object sender, PropertyChangedEventArgs e)
        {
            EntityChangedEventArgs<TEntity> args = new EntityChangedEventArgs<TEntity>();
            args.Item = (TEntity)sender;
            ItemChanged(this, args);
        }
    }
}
