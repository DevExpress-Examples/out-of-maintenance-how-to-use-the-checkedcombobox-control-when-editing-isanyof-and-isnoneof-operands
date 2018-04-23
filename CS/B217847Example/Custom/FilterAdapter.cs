using System;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;

namespace B217847Example
{
    [ToolboxItem(true)]
    public class FilterAdapter :Component, IFilteredComponent, ISupportInitialize
    {
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get { return fDataSource; }
            set
            {
                IBindingList oldBindingList = fDataSource as IBindingList;
                if (oldBindingList != null)
                    oldBindingList.ListChanged -= OnListChanged;
                fDataSource = value;
                IBindingList newBindingList = fDataSource as IBindingList;
                if (newBindingList != null)
                    newBindingList.ListChanged += OnListChanged;
            }
        }

        CriteriaOperator fRowCriteria;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual CriteriaOperator RowCriteria
        {
            get { return fRowCriteria; }
            set {
                if (ReferenceEquals(fRowCriteria, value)) return;
                fRowCriteria = value;
                RaiseRowFilterChanged();
            }
        }

        private object fDataSource;
        static RepositoryItemTextEdit DefaultEditor = new RepositoryItemTextEdit();
        static RepositoryItemDateEdit DefaultDateEditor = new RepositoryItemDateEdit();

        protected virtual FilterColumnCollection GetFilterColumns()
        {
            PropertyDescriptorCollection PDC = GetProperties();
            List<PropertyDescriptor> td = FilterPropertyDescriptionCollection(PDC);
            return GetFilterColumnsCollection(td);

        }

        public PropertyDescriptorCollection GetProperties()
        {
            IList list = DataSource as IList;
            if (list == null)
                if (DataSource is IListSource)
                    list = ((IListSource)DataSource).GetList();
            
            if (list == null)
                return new PropertyDescriptorCollection(new PropertyDescriptor[0], true);

            ITypedList typedList = list as ITypedList;
            if (typedList == null)
            {
                if (list.Count > 0)
                    return TypeDescriptor.GetProperties(list[0]);
            }
            else return typedList.GetItemProperties(new PropertyDescriptor[0]);
            return new PropertyDescriptorCollection(new PropertyDescriptor[0], true);
        }

        private static List<PropertyDescriptor> FilterPropertyDescriptionCollection(PropertyDescriptorCollection PDC)
        {
            List<PropertyDescriptor> td = new List<PropertyDescriptor>();
            foreach (PropertyDescriptor pd in PDC)
            {
                object op = pd.PropertyType;
                if (!pd.PropertyType.IsClass || (pd.PropertyType == typeof(string)))
                    td.Add(pd);

            }
            return td;
        }

        private FilterColumnCollection GetFilterColumnsCollection(List<PropertyDescriptor> td)
        {
            FilterColumnCollection filterCollection = new FilterColumnCollection();
            foreach (PropertyDescriptor pd in td)
            {

                CustomFilterColumn UFC = new CustomFilterColumn(pd.DisplayName, pd.Name,
                    pd.PropertyType, GetDefaultEditor(pd.PropertyType), GetClauseClass(pd.PropertyType), this);
                filterCollection.Add(UFC);
            }
            return filterCollection;
        }

        static FilterColumnClauseClass GetClauseClass(Type type)
        {
            if (type == typeof(string))
                return FilterColumnClauseClass.String;
            if (type == typeof(DateTime))
                return FilterColumnClauseClass.DateTime;
            return FilterColumnClauseClass.Generic;
        }

        static RepositoryItem GetDefaultEditor(Type type)
        {
            if (type == typeof(DateTime))
                return DefaultDateEditor;
            return DefaultEditor;
        }

        private void OnListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.PropertyDescriptorAdded || 
                e.ListChangedType == ListChangedType.PropertyDescriptorDeleted ||
                e.ListChangedType == ListChangedType.PropertyDescriptorChanged)
                RaisePropertiesChanged();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                IBindingList oldBindingList = fDataSource as IBindingList;
                if (oldBindingList != null)
                    oldBindingList.ListChanged -= OnListChanged;
            }
            base.Dispose(disposing);
        }

        public event EventHandler RowFilterChanged
        {
            add { Events.AddHandler(fRowFilterChanged, value); }
            remove { Events.RemoveHandler(fRowFilterChanged, value); }
        }

        #region IFilteredComponent
        IBoundPropertyCollection IFilteredComponent.CreateFilterColumnCollection()
        {
            if (Initializing) return new FilterColumnCollection();
            return GetFilterColumns();
        }

        static readonly object fPropertiesChanged = new object();
        event EventHandler IFilteredComponentBase.PropertiesChanged
        {
            add { Events.AddHandler(fPropertiesChanged, value); }
            remove { Events.RemoveHandler(fPropertiesChanged, value); }
        }

        void RaisePropertiesChanged()
        {
            EventHandler handler = Events[fPropertiesChanged] as EventHandler;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        CriteriaOperator IFilteredComponentBase.RowCriteria
        {
            get { return RowCriteria; }
            set { RowCriteria = value; }
        }

        static readonly object fRowFilterChanged = new object();
        event EventHandler IFilteredComponentBase.RowFilterChanged
        {
            add { RowFilterChanged += value; }
            remove { RowFilterChanged -= value; }
        }

        void RaiseRowFilterChanged()
        {
            EventHandler handler = Events[fRowFilterChanged] as EventHandler;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion

        #region ISupportInitialize
        bool Initializing;
        void ISupportInitialize.BeginInit()
        {
            Initializing = true;
        }

        void ISupportInitialize.EndInit()
        {
            Initializing = false;
            RaisePropertiesChanged();
        }
        #endregion
    }
}
