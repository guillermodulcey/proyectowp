using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizate.Models
{
    public class DataModelActividad
    {
        private ObservableCollection<Actividad> data;

        public ObservableCollection<Actividad> Data {
            get {
                if (data == null) {
                    data = new ObservableCollection<Actividad>();
                }
                return data;
            }
            set {
                data = value;
            }
        }
    }
}
