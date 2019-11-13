using System;

namespace Spring2.Core.Message {

    /// <summary>
    /// Simple message for testing and to show how messages are created.
    /// </summary>
    public class TestMessage : Message {

        private readonly String param1 = String.Empty;
        private readonly String param2 = String.Empty;

        public TestMessage(String param1, String param2) : base("First parameter is {0}. Second parameter is {1}.", param1, param2) {
        }
    }
}
