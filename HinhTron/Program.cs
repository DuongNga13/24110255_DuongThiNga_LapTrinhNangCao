using ShapeCalculator.Entities;

List<Shape> shapes = new List<Shape>
{
    new Circle(5),
    new Rectangle(4, 6),
    new Triangle(3, 4, 5)
};

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}:");
    Console.WriteLine($"  Area = {shape.CalculateArea():F2}");
    Console.WriteLine($"  Perimeter = {shape.CalculatePerimeter():F2}");
    Console.WriteLine();
}