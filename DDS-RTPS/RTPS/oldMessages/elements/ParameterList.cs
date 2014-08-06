#if TODO
using rtps.messages.MalformedSubmessageElementException;
using rtps.portable.InputPacket;
 
namespace rtps.messages.elements
{
 
public class ParameterList : SubmessageElement {
	
	public readonly static short PID_SENTINEL = 1;
	public readonly static short PID_PAD = 0;

	protected Parameter[] value;
	
	public ParameterList(Parameter[] values) {
		super(0);
		this.value = values;
		// set the size of the encoded element
		for (int i=0; i<values.length; i++) {
			super.size += (4 + values.length);
		}
		// PID_SENTINEL (2 bytes) + 2 ignored bytes
		super.size += 4;
	}
	
	// TODO checks
	public ParameterList(InputPacket packet)   {
		super(0);
		// array lists in which store parameters
		ArrayList parameters = new ArrayList();
		
		bool stop = false;
		do {
			// at least 4 bytes for length and type
			if (packet.getCursorPosition() + 4 <= packet.getLength()) {
				short parameterId = packet.read_short();
				short length = packet.read_short();
				byte[] p = new byte[length];
				if (parameterId != PID_SENTINEL) {
					for (int i=0; i<length; i++) {
						p[i] = packet.read_octet();
					}
					parameters.add(new Parameter(parameterId,length,p));
				}
				else {
					stop = true;
				}
			}
			else {
				throw  new MalformedSubmessageElementException("ParameterList too short");
			}
		} while (!stop);
		
		value = new Parameter[parameters.size()];
		parameters.toArray(value);
	}	
}
}
#endif