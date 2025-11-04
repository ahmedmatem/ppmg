namespace SmartHome.Lib;

public class DoorLock : Device
{
    public bool IsLocked { get; private set; } = true;
    public DoorLock(string id) : base(id) { }

    public void Lock() => IsLocked = true;
    public void Unlock() => IsLocked = false;
}
