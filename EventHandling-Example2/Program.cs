

using System;

class Button
{
    public event EventHandler Click;

    public void Press()
    {
        Console.WriteLine("Button Pressed");
        Click?.Invoke(this, EventArgs.Empty);   
    }
}

class Programm
{
    static void Main()
    {
        Button btn = new Button();
        btn.Click += OnButtonClick;
        btn.Press();

    }
    static void OnButtonClick(object sender, EventArgs e)
    {
        Console.WriteLine("Button Click event has been hadled");
    
    }

}
