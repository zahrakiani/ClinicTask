using Appointment.Application.Configuration.Commands;
using Appointment.Application.Contracts;
using Appointment.Infrastructure.Serialization;
using Dapper;
using KarizmaClinicManagementSystem.Framework.Abstracts;
using Newtonsoft.Json;

namespace Appointment.Infrastructure.Processing.InternalCommands;

public class CommandsScheduler : ICommandsScheduler
{
    private readonly ISqlConnectionFactory sqlConnectionFactory;

    public CommandsScheduler(ISqlConnectionFactory sqlConnectionFactory)
    {
        sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task EnqueueAsync(ICommand command)
    {
        var connection = this.sqlConnectionFactory.GetOpenConnection();

        const string sqlInsert = "INSERT INTO [Appointment].[InternalCommands] ([Id], [EnqueueDate] , [Type], [Data]) VALUES " +
                                 "(@Id, @EnqueueDate, @Type, @Data)";

        await connection.ExecuteAsync(sqlInsert, new
        {
            command.Id,
            EnqueueDate = DateTime.Now,
            Type = command.GetType().FullName,
            Data = JsonConvert.SerializeObject(command, new JsonSerializerSettings
            {
                ContractResolver = new AllPropertiesContractResolver()
            })
        });
    }
}