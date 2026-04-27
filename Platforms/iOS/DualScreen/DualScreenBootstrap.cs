#if IOS
using UIKit;
using Foundation;

public static class DualScreenBootstrap
{
    static ExternalDisplayManager manager = new();

    public static void Init()
    {
        UIScreen.Notifications.ObserveDidConnect((s, e) =>
        {
            manager.Connect(e.Screen);
        });

        UIScreen.Notifications.ObserveDidDisconnect((s, e) =>
        {
            manager.Disconnect();
        });

        ConfigurePages();
    }

    static void ConfigurePages()
    {
        manager.RegisterPages(new List<Func<UIViewController>>
        {
            () => CreatePage("Dashboard"),
            () => CreatePage("Analytics"),
            () => CreatePage("Settings")
        });
    }

    static UIViewController CreatePage(string title)
    {
        var label = new UILabel
        {
            Text = title,
            TextAlignment = UITextAlignment.Center,
            TextColor = UIColor.White
        };

        var view = new UIView { BackgroundColor = UIColor.Black };

        label.Frame = view.Bounds;
        label.AutoresizingMask =
            UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

        view.AddSubview(label);

        return new UIViewController { View = view };
    }
}
#endif



