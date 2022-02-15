using System;

namespace ElasticSearchService.Helpers {
    public class StaticHelpers {
        public static bool NonNullsEqual<T>(T obj1, T obj2) {
            foreach (var prop in typeof(T).GetProperties()) {
                if (prop.PropertyType == typeof(Guid)) continue;

                var obj1Value = prop.GetValue(obj1);
                var obj2Value = prop.GetValue(obj2);

                if (obj2Value != null && !obj2Value.Equals(obj1Value)) return false;
            }
            return true;
        }
    }
}
