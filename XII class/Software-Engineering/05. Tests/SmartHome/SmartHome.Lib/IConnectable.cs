namespace SmartHome.Lib;

public interface IConnectable
{
    bool Connected { get; }
    void Connect();
    void Disconnect();
}
