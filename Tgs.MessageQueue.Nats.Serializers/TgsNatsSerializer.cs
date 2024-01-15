using NATS.Client.Core;

namespace Tgs.MessageQueue.Nats.Serializers;
public class TgsNatsSerializer<T>
{
	public static readonly INatsSerializer<T> Default = ProtobufSerializer<T>.Default;
}
