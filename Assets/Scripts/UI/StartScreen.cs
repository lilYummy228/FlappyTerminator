using System;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;

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
        PlayButtonClicked?.Invoke();
    }
}
