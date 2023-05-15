using Prism.Events;

namespace GbXmlDesignSuite.Core.Events
{
    public class Events
    {
        public class OpenFileEvent : PubSubEvent<string> { }
        public class SaveFileEvent : PubSubEvent<string> { }
        public class SaveAsFileEvent : PubSubEvent<string> { }
        public class CloseFileEvent : PubSubEvent<string> { }
        public class NewFileEvent : PubSubEvent<string> { }
        public class OpenFileInNewWindowEvent : PubSubEvent<string> { }
        public class OpenFileInNewTabEvent : PubSubEvent<string> { }
        public class OpenFileInNewWindowOrTabEvent : PubSubEvent<string> { }
    }
}
