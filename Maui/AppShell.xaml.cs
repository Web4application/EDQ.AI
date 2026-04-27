protected override void OnNavigated(ShellNavigatedEventArgs args)
{
    base.OnNavigated(args);

    var index = CurrentItem != null
        ? Items.IndexOf(CurrentItem)
        : 0;

    DualScreenService.State.SetTab(index);
}
