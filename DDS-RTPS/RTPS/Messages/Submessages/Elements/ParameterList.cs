
using System.Collections.Generic;
namespace Rtps.Messages.Submessages.Elements
{

    public class ParameterList : SubmessageElement
    {

        public readonly static short PID_SENTINEL = 1;
        public readonly static short PID_PAD = 0;

        public List<Parameter> Value = new List<Parameter>();
        private int size = 0;

        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        
        public ParameterList()
        { }

        public ParameterList(List<Parameter> values)
        {
            this.Value = values;
            // set the size of the encoded element
            for (int i = 0; i < values.Count; i++)
            {
                size += (4 + values.Count);
            }
            // PID_SENTINEL (2 bytes) + 2 ignored bytes
            size += 4;
        }
    }
}