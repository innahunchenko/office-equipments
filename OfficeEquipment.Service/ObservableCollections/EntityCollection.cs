using Newtonsoft.Json;
using OfficeEquipment.Data.Models;
using System;
using System.Collections.Specialized;

namespace OfficeEquipment.Service.ObservableCollections
{
    public class EntityCollection<T, R> where T : BaseViewModel where R : BaseModel
    {
        IService<R> service;
        
        public EntityCollection(IService<R> service)
        {
            this.service = service;
            Values = new BaseCollection<T>();
            this.service.Entities.ForEach(x => Values.Add(Activator.CreateInstance(typeof(T), new object[] { x }) as T));
            Values.CollectionChanged += employees_CollectionChanged;
            Values.ItemChanged += employees_ItemChanged;
        }

        public BaseCollection<T> Values { get; set; }

        void employees_ItemChanged(object sender, EntityChangedEventArgs<T> args)
        {
            service.Update(args.Item.InnerModel.Id);
        }

        void employees_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (T item in e.NewItems)
                    {
                        var id = service.Create(JsonConvert.SerializeObject(item.InnerModel));
                        item.InnerModel.Id = id;
                    }
                    break;

                case NotifyCollectionChangedAction.Reset:
                    service.Reset();
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (T item in e.OldItems)
                    {
                        service.Delete(item.InnerModel.Id);
                    }
                    break;

                default:
                    foreach (T item in e.NewItems)
                    {
                        service.Update(item.InnerModel.Id);
                    }
                    break;
            }
        }
    }
}