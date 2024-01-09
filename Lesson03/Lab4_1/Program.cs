namespace Lab4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Window win = new Window(1,2);
            ListBox lb = new ListBox(3,4, "stand alone list box");
            Button b = new Button(5,6);
            win.DrawWindow();
            lb.DrawWindow();
            b.DrawWindow();
            Window[] winArr = new Window[3];
            winArr[0] = win;
            winArr[1] = lb;
            winArr[2] = b;
            for (int i = 0; i < 3; i++)
            {
                winArr[i].DrawWindow();
            }
        }
    }
}