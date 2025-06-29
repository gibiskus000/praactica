namespace laba5
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new SimulationWindow());
        }
    }

    public class SimulationWindow : Form
    {
        // Реализация графического интерфейса и логики симуляции
    }
}