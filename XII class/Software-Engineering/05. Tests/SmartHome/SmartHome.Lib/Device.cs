namespace SmartHome.Lib;

public abstract class Device : IConnectable
{
    public string Id { get; }
    public bool Connected { get; private set; }

    protected Device(string id) => Id = id;

    public void Connect() => Connected = true;
    public void Disconnect() => Connected = false;
}
