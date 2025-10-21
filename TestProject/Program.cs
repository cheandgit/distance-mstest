namespace DistanceTest;
internal class Program
{
    static void Main(string[] args)
    {
        //new AutoRun().Execute(args);
        Console.WriteLine("Расстояние от точки P(px, py) до отрезка AB с координатами A(ax, ay), B(bx, by).");
        Console.WriteLine("Введите координаты трех точек (P, A, B) через пробел:");
        var line = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(line))
            return;
        string[] coord = line.Split();
        if (coord.Length != 6)
        {
            Console.WriteLine("Ошибка ввода! Введите шесть чисел через пробел, начиная с числа.");
            Console.WriteLine("-----");
            Console.ReadKey();
            return;
        }
        try
        {
            double px = Convert.ToDouble(coord[0]);
            double py = Convert.ToDouble(coord[1]);
            double ax = Convert.ToDouble(coord[2]);
            double ay = Convert.ToDouble(coord[3]);
            double bx = Convert.ToDouble(coord[4]);
            double by = Convert.ToDouble(coord[5]);
            var distance = Distance.GetDistance(px, py, ax, ay, bx, by);
            Console.WriteLine("Distance = {0:F4}", distance);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка ввода!\n{0}", e);
        }
        Console.WriteLine("-----");
        Console.ReadKey();
    }
}
