using Amazon.DynamoDBv2.DataModel;

namespace Dynamodb_webapi.Models
{
    [DynamoDBTable("Employees")]
    public class Employee
    {
        [DynamoDBHashKey]
        public int id { get; set; }
        [DynamoDBProperty]
        public string? Name { get; set; }
        [DynamoDBProperty]
        public string? AccountNumber { get; set; }
        [DynamoDBProperty]
        public string? ErrorMessage { get; set; }
        [DynamoDBProperty]
        public DateTime InsertDate { get; set; }
        [DynamoDBProperty]
        public string? Request { get; set; }

    }
}
