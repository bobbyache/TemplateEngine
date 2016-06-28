using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikControls
{
    public abstract class QikControl
    {
        public string ControlId { get; private set; }
        public string Title { get; protected set; }
        public string DefaultValue { get; set; }

        public QikControl(string controlId, string defaultValue, string title)
        {
            this.ControlId = controlId;
            this.DefaultValue = defaultValue;
            this.Title = title;
        }
    }
}
