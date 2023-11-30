namespace Task_2
{
    public class Repository<T>
    {
        private List<T> items;

        public Repository(List<T> initialItems)
        {
            items = initialItems ?? throw new ArgumentNullException(nameof(initialItems));
        }

        public delegate bool Criteria(T item);

        public List<T> Find(Criteria criteria)
        {
            if (criteria is null)
            {
                throw new ArgumentNullException(nameof(criteria));
            }

            return items.Where(item => criteria(item)).ToList();
        }
    }
}