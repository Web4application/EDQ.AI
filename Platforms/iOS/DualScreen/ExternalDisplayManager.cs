public class DualScreenState
{
    public int CurrentTabIndex { get; private set; }

    public event Action<int> TabChanged;

    public void SetTab(int index)
    {
        if (CurrentTabIndex == index) return;

        CurrentTabIndex = index;
        TabChanged?.Invoke(index);
    }
}

public static class DualScreenService
{
    public static DualScreenState State { get; } = new();
}
