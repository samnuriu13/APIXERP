﻿using System;

namespace API.DATA
{
    public class ObjectStorage : ItemStorage
    {
        public ObjectStorage(ItemBase item, String columnName, FieldCategory fieldType)
        {
            Name = columnName;
            this.item = item;
            this.item.Fields.Add(this);
            FieldType = fieldType;
        }
        private readonly ItemBase item;
        private Boolean original;

        private Object value;
        public Object Value
        {
            get { return value; }
            set
            {
                this.value = value;
                if (!original)
                {
                    originalValue = value;
                    original = true;
                }
                else
                    PropertyChanged(value);
            }
        }

       
        private Object originalValue;
        public Object OriginalValue
        {
            get { return originalValue; }
        }

        protected internal void PropertyChanged(Object newValue)
        {
            if (!originalValue.Equals(newValue))
            {
                if (item.State.Equals(ItemState.Unchanged))
                {
                    item.State = ItemState.Modified;
                }
                Modified = true;
            }
            else
            {
                if (Modified)
                {
                    if (item.Fields.FindAll(column => column.Modified && column.FieldType.Equals(FieldCategory.NormalField)).Count.Equals(1))
                    {
                        item.State = ItemState.Unchanged;
                    }
                    Modified = false;
                }
            }
        }

        protected internal override void AcceptChanges()
        {
            originalValue = value;
        }
        protected internal override void RejectChanges()
        {
            value = originalValue;
        }
        public override Object ObjectTypeValue
        {
            get { return value; }
            set { this.value = value; }
        }
        public override String GetValue()
        {
            if (value == null || value == DBNull.Value)
                return "Null";
            return String.Format("{0}", value);
        }
    }
}
