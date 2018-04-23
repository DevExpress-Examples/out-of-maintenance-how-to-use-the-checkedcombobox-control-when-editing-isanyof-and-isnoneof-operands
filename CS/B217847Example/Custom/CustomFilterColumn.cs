using System;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using DevExpress.Data.Filtering.Helpers;

namespace B217847Example
{
    class CustomFilterColumn : UnboundFilterColumn
    {
        public CustomFilterColumn(string columnCaption, string fieldName, Type columnType, 
            RepositoryItem columnEdit, FilterColumnClauseClass clauseClass, FilterAdapter owner)
            : base(columnCaption, fieldName, columnType, columnEdit, clauseClass) { 
            this.Owner = owner; 
        }
        
        protected readonly FilterAdapter Owner;

        Object DataSource {
            get { return Owner.DataSource; } 
        }

        private void GetAllUniqueValues(IList List, List<Object> op)
        {
            foreach (object Lob in List)
            {
                foreach (PropertyDescriptor pd in Owner.GetProperties())
                {
                    if (pd.Name == FieldName)
                        op.Add(pd.GetValue(Lob));

                }

            }
        }
        public override RepositoryItem CreateItemCollectionEditor()
        {
            FilterRepositoryItemCheckedComboBoxEdit re = new FilterRepositoryItemCheckedComboBoxEdit();
           
            if (DataSource == null)
                return re;

            IList List;

            if (DataSource is IList)
                List = DataSource as IList;
            else
            {
                IListSource Ilist = DataSource as IListSource;
                List = Ilist.GetList();
            }

            List<Object> op = new List<object>();
            GetAllUniqueValues(List, op);

            foreach (Object Value in op)
            {
                if (Value.ToString() != "" && re.Items[Value] == null)
                    re.Items.Add(Value, Value.ToString());
            }

            return re;
        }


        public override bool AllowItemCollectionEditor
        {
            get
            {
                return true;
            }
        }

    }
}

