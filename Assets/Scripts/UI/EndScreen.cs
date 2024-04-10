using System;

public class EndScreen : Window
{
    public event Action RestartButtonClicked;

    public override void Close()
    {
        base.Close();
    }

    public override void Open()
    {
        base.Open();
    }

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}