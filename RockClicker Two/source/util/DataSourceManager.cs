using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockClicker_Two.source.util
{
    internal class DataSourceManager
    {
        private Dictionary<Control, BindingSource> controlsBindingSources = new Dictionary<Control, BindingSource>();

        internal Dictionary<Control, BindingSource> ControlsBindingSources { get => controlsBindingSources; set => controlsBindingSources = value; }

        public DataSourceManager() 
        { 
        
        
        
        }

        public void BindControl<T>(IList<T> ListOfObjectsToBeAdded, ListControl controlToBeBinded)
        {

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = ListOfObjectsToBeAdded;
            controlToBeBinded.DataSource = bindingSource;
            controlToBeBinded.DisplayMember = "Name";

            this.ControlsBindingSources.Add(controlToBeBinded, bindingSource);




        }

        public void addDataToBindingSource(Control controlToBeBinded, object data)
        {
            if (ControlsBindingSources.ContainsKey(controlToBeBinded))
            {
                ControlsBindingSources[controlToBeBinded].Add(data);
            }
            else
            {
                throw new Exception("Control not found in binding sources.");
            }
        }

        public void removeDataFromBindingSource(Control controlToBeBinded, object data)
        {
            if (ControlsBindingSources.ContainsKey(controlToBeBinded))
            {
                ControlsBindingSources[controlToBeBinded].Remove(data);
            }
            else
            {
                throw new Exception("Control not found in binding sources.");
            }
        }

        public void ClearBinding(Control controlToBeBinded)
        {
            if (ControlsBindingSources.ContainsKey(controlToBeBinded))
            {
                controlToBeBinded.DataBindings.Clear();
                ControlsBindingSources.Remove(controlToBeBinded);
            }
            else
            {
                throw new Exception("Control not found in binding sources.");
            }
        }

        public void ClearAllBindings()
        {
            foreach (var control in ControlsBindingSources.Keys)
            {
                control.DataBindings.Clear();
            }
            ControlsBindingSources.Clear();
        }

        public void UpdateBindingSource(Control controlToBeBinded, IBindingList newList)
        {
            if (ControlsBindingSources.ContainsKey(controlToBeBinded))
            {
                ControlsBindingSources[controlToBeBinded].DataSource = newList;
            }
            else
            {
                throw new Exception("Control not found in binding sources.");
            }
        }



        


    }
}
