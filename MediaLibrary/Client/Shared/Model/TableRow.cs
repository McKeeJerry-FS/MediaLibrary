namespace MediaLibrary.Client.Shared.Model
{
    public class TableRow<TItem>
    {
        public TableRow(TItem originalValue)
        {
            OriginalValue = originalValue;
        }

        public List<TableCell> Values { get; set; } = new();
        public TItem OriginalValue { get; set; }
    }
}
