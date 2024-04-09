namespace NACH.API.Utility
{
    public static class CustomerExtensions
    {
        public static List<T> Filter<T>(this List<T> source, string filter)
        {
            try
            {
                List<T> result = new List<T>();
                if (string.IsNullOrEmpty(filter))
                {
                    return source;
                }
                foreach (T item in source)
                {
                    var arrayPropNames = item.GetType().GetProperties().Select(p => p.Name);
                    foreach (var PropName in arrayPropNames)
                    {
                        string colValue = Convert.ToString(item.GetType().GetProperty(PropName).GetValue(item, null));
                        if (!string.IsNullOrEmpty(colValue))
                        {
                            if (colValue.ToLower().Contains(filter.ToLower()))
                            {
                                result.Add(item);
                                break;
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return source;
            }
        }
    }
}
