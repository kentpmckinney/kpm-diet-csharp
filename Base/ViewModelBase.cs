using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace DietApplication
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            this.CheckPropertyName(propertyName);

            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion // INotifyPropertyChanged Members

        #region Check property name

        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void CheckPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                throw new Exception(String.Format("Could not find property \"{0}\"", propertyName));
        }

        #endregion // Check property name
    }
}
