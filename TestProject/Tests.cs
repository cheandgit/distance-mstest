using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DistanceTest;

[TestClass]
public class Tests
{
    // Общий метод
    static void EquationTest(double expected, params double[] points)
    {
        var px = points[0]; var py = points[1];
        var ax = points[2]; var ay = points[3];
        var bx = points[4]; var by = points[5];

        var result = Distance.GetDistance(px, py, ax, ay, bx, by);
        Assert.AreEqual(expected, result, 0.0001); // Добавляем delta для сравнения double
    }

    [TestMethod]
    public void OnePoint()
    {
        EquationTest(0.0, 10, 10, 10, 10, 10, 10);
    }

    [TestMethod]
    public void TwoPoints()
    {
        EquationTest(28.284271247461902, 0, 0, 20, 20, 20, 20);
    }

    [TestMethod]
    public void TestSet1()
    {
        var expected1 = new List<double>{ 20.0, 20.0, 28.284271247461902,
        28.284271247461902, 26.832815729997474, 25.298221281347036,
        21.466252583997980, 27.294688127912362};

        double[][] testSet1 = {
        new double[]{ 0, 20, -20, 0, 20, 0 },
        new double[]{ 20, 20, -20, 0, 20, 0 },
        new double[]{ 40, 20, -20, 0, 20, 0 },
        new double[]{ 40, -20, -20, 0, 20, 0 },
        new double[]{ 4, 44, 8, 16, 32, 28 },
        new double[]{ -16, 24, 8, 16, 32, 28 },
        new double[]{ 16, 20, -8, 8, 16, -4 },
        new double[]{ 35, 4, -16, 8, 8, 0 }};

        for (int i = 0; i < expected1.Count; i++)
            EquationTest(expected1[i], testSet1[i]);
    }

    [TestMethod]
    public void TestSet2()
    {
        var expected2 = new List<double>{ 14.142135623730951, 10.0, 10.0,
        10.0, 14.142135623730951, 10.0, 14.142135623730951, 10.0, 10.0,
        10.0, 14.142135623730951, 10.0, 0.0, 0.0, 0.0};

        double[][] testSet2 = {
        new double[]{ -40, 10, -30, 20, -10, 20 },
        new double[]{ -30, 10, -30, 20, -10, 20 },
        new double[]{ -20, 10, -30, 20, -10, 20 },
        new double[]{ -10, 10, -30, 20, -10, 20 },
        new double[]{ 0, 10, -30, 20, -10, 20 },
        new double[]{ 0, 20, -30, 20, -10, 20 },
        new double[]{ 0, 30, -30, 20, -10, 20 },
        new double[]{ -10, 30, -30, 20, -10, 20 },
        new double[]{ -20, 30, -30, 20, -10, 20 },
        new double[]{ -30, 30, -30, 20, -10, 20 },
        new double[]{ -40, 30, -30, 20, -10, 20 },
        new double[]{ -40, 20, -30, 20, -10, 20 },
        new double[]{ -30, 20, -30, 20, -10, 20 },
        new double[]{ -20, 20, -30, 20, -10, 20 },
        new double[]{ -10, 20, -30, 20, -10, 20 }};

        for (int i = 0; i < expected2.Count; i++)
            EquationTest(expected2[i], testSet2[i]);
    }

    [TestMethod]
    public void TestSet3()
    {
        var expected3 = new List<double>{ 14.142135623730951, 10.0, 10.0,
        10.0, 14.142135623730951, 10.0, 14.142135623730951, 10.0, 10.0,
        10.0, 14.142135623730951, 10.0, 0.0, 0.0, 0.0};

        double[][] testSet3 = {
        new double[]{ -20, 0, -10, -10, -10, -30 },
        new double[]{ -20, -10, -10, -10, -10, -30 },
        new double[]{ -20, -20, -10, -10, -10, -30 },
        new double[]{ -20, -30, -10, -10, -10, -30 },
        new double[]{ -20, -40, -10, -10, -10, -30 },
        new double[]{ -10, -40, -10, -10, -10, -30 },
        new double[]{ 0, -40, -10, -10, -10, -30 },
        new double[]{ 0, -30, -10, -10, -10, -30 },
        new double[]{ 0, -20, -10, -10, -10, -30 },
        new double[]{ 0, -10, -10, -10, -10, -30 },
        new double[]{ 0, 0, -10, -10, -10, -30 },
        new double[]{ -10, 0, -10, -10, -10, -30 },
        new double[]{ -10, -10, -10, -10, -10, -30 },
        new double[]{ -10, -20, -10, -10, -10, -30 },
        new double[]{ -10, -30, -10, -10, -10, -30 }};

        for (int i = 0; i < expected3.Count; i++)
            EquationTest(expected3[i], testSet3[i]);
    }
}

