using System.Collections;

namespace Cortside.Core.Util {

    /// <summary>
    /// Summary description for ApplicationErrorCollection.
    /// </summary>
    public class ApplicationErrorCollection : CollectionBase {

        public ApplicationErrorCollection() {
        }

        // Indexer implementation.
        public ApplicationError this[int index] {
            get { return (ApplicationError)List[index]; }
        }

        public void Add(ApplicationError error) {
            List.Add(error);
        }

        public void Remove(int index) {
            List.RemoveAt(index);
        }

        public void AddRange(ApplicationErrorCollection c) {
            InnerList.AddRange(c);
        }
    }
}
