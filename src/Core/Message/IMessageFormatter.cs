using System;

namespace Cortside.Core.Message {

    public interface IMessageFormatter {
        String Format(Message message);
    }
}
