using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Dynamodb_webapi.Repository;

namespace Dynamodb_webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IEmpMethods, EmpMethods>();

            builder.Services.AddDefaultAWSOptions(new AWSOptions
            {
                Credentials = new BasicAWSCredentials(builder.Configuration.GetValue<string>("AWS:secretkey"), builder.Configuration.GetValue<string>("AWS:accesskey")),
                Region = RegionEndpoint.USEast1
               
                
            });
            builder.Services.AddAWSService<IAmazonDynamoDB>();
            builder.Services.AddTransient<IDynamoDBContext, DynamoDBContext>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}