using NATS.Client.Core;

namespace Tgs.MessageQueue.Nats.Serializers;

public class TgsNatsSerializerRegistration : INatsSerializerRegistry
{
	public static readonly TgsNatsSerializerRegistration Default = new();

	public INatsSerialize<T> GetSerializer<T>() => TgsNatsSerializer<T>.Default;

	public INatsDeserialize<T> GetDeserializer<T>() => TgsNatsSerializer<T>.Default;
}
