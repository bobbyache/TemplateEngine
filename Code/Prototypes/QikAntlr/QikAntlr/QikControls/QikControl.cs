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
        public string Value { get; protected set; }

        public QikControl(string controlId, string value, string title)
        {
            this.ControlId = controlId;
            this.Value = value;
            this.Title = title;
        }
    }
}
