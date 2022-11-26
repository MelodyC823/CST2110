using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Azure;
using Azure.Data.Tables;

namespace _2110.RestaurantDataAccess
{
    public class Restaurant : ITableEntity
    {
        [Required(AllowEmptyStrings = false), StringLength(20, MinimumLength = 3)]
        public string PartitionKey { get; set; }

        [Required(AllowEmptyStrings = false), StringLength(20, MinimumLength = 3)]
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; } = default;
        public ETag ETag { get; set; } = default;

        [Required(AllowEmptyStrings =false)]
        [StringLength(100)]
        public string RestaurantName { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        [Range(0, 10)]
        public int Rating { get; set; }
        public string WebURL { get; set; }
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Required]
        [StringLength(100)]
        public string Cuisine { get; set; }
        public bool IsVegan { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsAlcohol { get; set; }
        public double Price { get; set; }
        public string BusinessHours { get; set; }

        public override string ToString()
        {
            var strFormat = new StringBuilder();
            strFormat.AppendLine($"Restaurant Name: {RestaurantName}");
            strFormat.AppendLine($"Address: {Address}");
            strFormat.AppendLine($"City: {City}");
            strFormat.AppendLine($"Postal Code: {PostalCode}");
            strFormat.AppendLine($"Rating: {Rating}");
            strFormat.AppendLine($"Website: {WebURL}");
            strFormat.AppendLine($"Email: {Email}");
            strFormat.AppendLine($"Phone: {Phone}");
            strFormat.AppendLine($"Cuisine: {Cuisine}");
            strFormat.AppendLine($"Is Vegan: {IsVegan}");
            strFormat.AppendLine($"Is Vegetarian: {IsVegetarian}");
            strFormat.AppendLine($"Is Alcohol: {IsAlcohol}");
            strFormat.AppendLine($"Price: {Price}");
            strFormat.AppendLine($"Business Hour: {BusinessHours}");
            return strFormat.ToString();
        }
    }
}