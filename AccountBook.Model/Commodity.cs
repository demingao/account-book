//*************************************
// All rights reserved
// filename:Commodity
// description:this is a class file
// created by kikao
// created at 2014/8/24 20:16:05
// version 1.0
//*************************************

using AccountBook.Events.Commodity;
using AccountBook.Model.Snapshots;

namespace AccountBook.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Apworks;

    public class Commodity : SourcedAggregateRoot
    { 
        /// <summary>
        /// 帐目编号
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// 帐目名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 帐目费用
        /// </summary>
        public virtual float Price { get; set; }

        /// <summary>
        /// 帐目描述
        /// </summary>
        public virtual string Describe { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        public virtual DateTime RecordTime { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public virtual Guid Creater { get; set; }
        public void CreateCommodity(Guid creater)
        {
            this.RaiseEvent(new CommodityCreatedEvent
            {
                Id = this.Id,
                Name = this.Name,
                Price = this.Price,
                Describe = this.Describe,
                RecordTime = this.RecordTime,
                Creater = creater
            });
        }
        public void ModifiyCommodity(Guid creater)
        {
            this.RaiseEvent(new CommodityModifiedEvent
            {
                Id = this.Id,
                Name = this.Name,
                Price = this.Price,
                Describe = this.Describe,
                RecordTime = this.RecordTime,
                Creater = creater
            });
        }
        public void DeleteCommodity()
        {
            this.RaiseEvent(new CommodityDeletedEvent
            {
                Id = this.Id
            });
        }

        [Handles(typeof(CommodityCreatedEvent))]
        private void CommodityCreatedEventHandler(CommodityCreatedEvent @event)
        {
            this.Id = @event.Id;
            this.Name = @event.Name;
            this.Describe = @event.Describe;
            this.Price = @event.Price;
            this.RecordTime = @event.RecordTime;
        }

        [Handles(typeof(CommodityModifiedEvent))]
        private void CommodityModifiedEventHandler(CommodityModifiedEvent @event)
        {
            this.Id = @event.Id;
            this.Name = @event.Name;
            this.Describe = @event.Describe;
            this.Price = @event.Price;
            this.RecordTime = @event.RecordTime;
        }

        //[Handles(typeof(CommodityDeletedEvent))]
        //private void CommodityModifiedEventHandler(CommodityDeletedEvent @event)
        //{
        //    this.Id = @event.Id;
        //}
        protected override void DoBuildFromSnapshot(Apworks.Snapshots.ISnapshot snapshot)
        {
            var commodity = (CommoditySnapshot) snapshot;
            this.Id = commodity.Id;
            this.Name = commodity.Name;
            this.Price = commodity.Price;
            this.RecordTime = commodity.RecordTime;
            this.Creater = commodity.Creater;
        }

        protected override Apworks.Snapshots.ISnapshot DoCreateSnapshot()
        {
            return new CommoditySnapshot
            {
                Id=this.Id,
                Name = this.Name,
                Price=this.Price,
                RecordTime = this.RecordTime,
                Creater = this.Creater
            };
        }
    }
}
