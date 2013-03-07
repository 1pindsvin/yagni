using System.Collections.Generic;

namespace Unittests.Statistics
{
    public class SubReport
    {
        public string Header { get; set; }
        public IEnumerable<GroupData> GroupedData { get; set; }
    }
}