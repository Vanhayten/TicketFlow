using System.Globalization;
using TicketFlow.Application.Common.Interfaces;
using TicketFlow.Application.TodoLists.Queries.ExportTodos;
using TicketFlow.Infrastructure.Files.Maps;
using CsvHelper;

namespace TicketFlow.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
