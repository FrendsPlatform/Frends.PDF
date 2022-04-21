using System.Collections.Generic;

namespace Frends.PDF.Create.Definitions
{
    /// <summary>
    /// Definitions for whole table.
    /// </summary>
    public class TableDefinition
    {
        /// <summary>
        /// Does the table have header rows?
        /// </summary>
        public bool HasHeaderRow { get; set; }

        /// <summary>
        /// Type of the table.
        /// </summary>
        public TableTypeEnum TableType { get; set; }

        /// <summary>
        /// Styles for the table.
        /// </summary>
        public TableStyle StyleSettings { get; set; }

        /// <summary>
        /// Definitions for table columns.
        /// </summary>
        public List<TableColumnDefinition> Columns { get; set; }

        /// <summary>
        /// Table data.
        /// </summary>
        public List<Dictionary<string, string>> RowData { get; set; }
    }
}
