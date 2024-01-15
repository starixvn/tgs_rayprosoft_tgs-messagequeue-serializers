using System.Buffers;
using System.Text.Json;
using NATS.Client.Core;

namespace Tgs.MessageQueue.Nats.Serializers;

public class JsonSerializer<T>(JsonSerializerOptions jsonSerializerOptions) : INatsSerializer<T>
{
	public void Serialize(IBufferWriter<byte> bufferWriter, T value)
	{
		using var jsonWriter = new Utf8JsonWriter(bufferWriter);
		JsonSerializer.Serialize(jsonWriter, value, jsonSerializerOptions);
	}

	public T? Deserialize(in ReadOnlySequence<byte> buffer)
		=> buffer.IsSingleSegment
			? JsonSerializer.Deserialize<T>(buffer.FirstSpan, jsonSerializerOptions)
			: JsonSerializer.Deserialize<T>(buffer.ToArray(), jsonSerializerOptions);
}
