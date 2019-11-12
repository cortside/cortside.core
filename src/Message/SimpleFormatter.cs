using System;

namespace Spring2.Core.Message {

    public class SimpleFormatter : IMessageFormatter {
	public String Format(Message message) {
	    return String.Format(message.Key, message.Properties);
	}
    }
}
