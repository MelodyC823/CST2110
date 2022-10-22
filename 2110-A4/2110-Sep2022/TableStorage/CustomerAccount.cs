using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2110_Sep2022.TableStorage
{
    public class CustomerAccount : ITableEntity
    {
        public string PartitionKey { get; set; } = default;
        public string RowKey { get; set; } = default;
        public DateTimeOffset? Timestamp { get; set; } = default;
        public ETag ETag { get; set; } = default;

        public bool IsAccountActive { get; set; }
        public Double InterestRate { get; set; }
    }
}
