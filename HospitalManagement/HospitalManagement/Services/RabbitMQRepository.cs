using HospitalManagement.Models;
using HospitalManagement.Repositories;
using MongoDB.Bson.IO;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;


namespace HospitalManagement.Services
{
    public class RabbitMQRepository : IRabbitMQRepository
    {
        public void Producer(Reception reception)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                var json = JsonConvert.SerializeObject(reception);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
            }


        }
    }
}
