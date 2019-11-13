using System;

namespace Spring2.Core.Message {
 
    public interface IMessageFormatter {
	String Format(Message message);
    }
}
