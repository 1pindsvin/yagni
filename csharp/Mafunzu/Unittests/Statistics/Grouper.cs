using System;
using System.Collections.Generic;
using System.Linq;

namespace Unittests.Statistics
{
    public class Grouper<T>
    {
        private readonly IDictionary<int, string> _groupableEnumeration;
        private readonly Func<T, int> _groupableKeySelector;
        private readonly IEnumerable<T> _items;

        public Grouper
            (
            IEnumerable<T> items,
            IDictionary<int, string> groupableEnumeration,
            Func<T, int> groupableKeySelector
            )
        {
            _items = items;
            _groupableEnumeration = groupableEnumeration;
            _groupableKeySelector = groupableKeySelector;
        }

        public IEnumerable<Group<T>> GetGroups()
        {
            return DoGetGroups(_items, _groupableEnumeration, _groupableKeySelector);
        }

        public IEnumerable<GroupData> ResolveGroupedData(IEnumerable<T> allItems)
        {
            return DoResolveGroupedData(allItems, _items, _groupableEnumeration, _groupableKeySelector);
        }


        private static IEnumerable<Group<T>> DoGetGroups(
            IEnumerable<T> items,
            IDictionary<int, string> groupableEnumeration,
            Func<T, int> groupableKeySelector)
        {
            var groupBy = items.GroupBy(groupableKeySelector);
            var count = items.Count();
            foreach (var grouping in groupBy)
            {
                var description = groupableEnumeration[grouping.Key];
                var percentage = ToPercentageOf(count, grouping.Count());
                var group =
                    new Group<T>
                        {
                            Description = description,
                            PercentageOf = percentage,
                            ID = grouping.Key,
                            Items = grouping
                        };
                yield return group;
            }
        }

        private static IEnumerable<GroupData> DoResolveGroupedData(
            IEnumerable<T> allItems,
    IEnumerable<T> items,
    IDictionary<int, string> groupableEnumeration,
    Func<T, int> groupableKeySelector)
        {
            var count = items.Count();
            var countAll = allItems.Count();
            foreach (var group in DoGetGroups(items, groupableEnumeration, groupableKeySelector).OrderBy(x => x.ID))
            {
                var groupData = 
                    new GroupData { Description = group.Description, GroupCount = group.Items.Count(), AllGroupsCount = count, GlobalCount = countAll};
                yield return groupData;
            }
        }


        private static double ToPercentageOf(int all, int segmentOfAll)
        {
            return Convert.ToDouble(segmentOfAll*100)/all;
        }
    }
}