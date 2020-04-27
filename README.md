# SOLID Principles

In object-oriented computer programming, SOLID is a mnemonic acronym for five design principles intended to make software designs more understandable, flexible and maintainable.

| Initial | Acronyms | Concept                                                                                                                                                                                                                    |
|---------|----------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| S       | SRP      | <b>Single-responsibility principle</b><br><br>A class should only have a single responsibility, that is, only changes to one part of the software's specification should be able to affect the specification of the class. |
| O       | OCP      | <b>Open–closed principle</b><br>"Software entities ... should be open for extension, but closed for modification."                                                                                                         |
| L       | LSP      | <b>Liskov substitution principle</b><br>"Objects in a program should be replaceable with instances of their subtypes without altering the correctness of that program."                                                    |
| I       | ISP      | <b>Interface segregation principle</b><br>"Many client-specific interfaces are better than one general-purpose interface."                                                                                                 |
| D       | DIP      | <b>Dependency inversion principle</b><br>One should "depend upon abstractions, [not] concretions."                                                                                                                         |

Well, once we have seen the definition and its concepts, let's develop a practical example to better understand

## Practice

Think of a fairly ... fairly simple application that calculates the sum of the areas and perimeters of a set of rectangles. For this, you have a class called `Rectangle` which looks something like this:
```csharp
public class Rectangle
{
    public double Sides { get; } = 4;
    public double Height { get; set; }
    public double Width { get; set; }

    public static double SumAreas(IEnumerable<Rectangle> rectangles)
    {
        //   
    }

    public static double SumPerimeters(IEnumerable<Rectangle> rectangles)
    {
        //
    }
}
```

While the main program is in charge of creating the `rectangles` and calling the respective methods to obtain the sums:
```csharp
var rectangles = new[]
{
    new Rectangle {Width = 10, Height = 5},
    new Rectangle {Width = 4, Height = 6},
    new Rectangle {Width = 5, Height = 1},
    new Rectangle {Width = 8, Height = 9}
};

var sumAreas = Rectangle.SumAreas(rectangles);
var sumPerimeters = Rectangle.SumPerimeters(rectangles);
```  

Everything seems perfect, your program works like a charm, but it is violating the principle of single responsibility.
## SRP violation
The violation occurs when declaring the `SumAreas` and` SumPerimeters` methods within the same class as `Rectangle` and is that although they are related to the rectangle as such, the summation is part of our application logic , not the logic that a rectangle could have in real life.
## Complying with the SRP
To comply with the principle, we remove the summation functionality of the `Rectangle` class and introduce a couple of classes in charge of performing the operations on the sets of rectangles, their code is more or less this:
```csharp
public class AreaOperation
{
    public static double Sum(IEnumerable<Rectangle> rectangles)
    {
        //
    }       
}

public class PerimeterOperation
{
    public static double Sum(IEnumerable<Rectangle> rectangles)
    {
        //
    }
}
```  
So each class has a single responsibility: one represents a rectangle and the others are responsible for doing operations related to them.
Now, suppose that after a certain time, people liked your program so much that they ask you to also take into account equilateral triangles and that your program allows adding the areas of triangles with rectangles.

So you create a new class to represent the triangles, and you modify the methods to add areas so that they accept both rectangles and triangles and inside them you check what type each object is and perform the appropriate calculation:

```csharp
public class AreaOperation
{
    public static double Sum(IEnumerable<object> shapes)
    {
        double area = 0;
        foreach (var shape in shapes)
        {
            switch (shape)
            {
                case Rectangle rectangle:
                    area += rectangle.Height * rectangle.Width;
                    break;
                case EquilateralTriangle triangle:
                    area += Math.Sqrt(3) * Math.Pow(triangle.SideLength, 2) / 4;
                    break;
            }
        }
        return area;
    }
}

public class PerimeterOperation
{
    public static double Sum(IEnumerable<object> shapes)
    {
        double perimeter = 0;
        foreach (var shape in shapes)
        {
            switch (shape)
            {
                case Rectangle rectangle:
                    perimeter += 2 * rectangle.Height + 2 * rectangle.Width;
                    break;
                case EquilateralTriangle triangle:
                    perimeter += triangle.SideLength * 3;
                    break;
            }
        }   
        return perimeter;
    }
 }
```  

Everything seems perfect again, your program works like a charm, but it is violating the open/closed principle.

## OCP violation
You probably already have an idea of ​​where in the code this principle is being violated ... but if not: in the classes of operations, and that is that your program is open to the extension ... but not to the modification. Think about what will happen tomorrow that circles become fashionable. You would have to modify the code of the operations so that it works with another figure and thus for each figure that occurs to the users of your program.

## Complying with the OCP 
The solution to this violation will be given through the use of abstractions (in this case the `IGeometricShape` interface) through which we will indicate that our figures share properties and methods (in this case the area and the perimeter):

```csharp
public interface IGeometricShape
{
    double Area();
    double Perimeter();
}
```

Y también tenemos que modificar las clases de operaciones para que acepten ahora objetos que cumplan con ese comportamiento, para así poder llamar a esos métodos, sin tener que preocuparse de qué tipo son "realmente" los objetos con los que está trabajando:  

```csharp
public double Sum(IEnumerable<IGeometricShape> shapes)
{
    double area = 0;
    foreach (var shape in shapes)
        area += shape.Area();
    return area;
}

public double Sum(IEnumerable<IGeometricShape> shapes)
{
    double perimeter = 0;
    foreach (var shape in shapes)
        perimeter += shape.Perimeter();
    return perimeter;
}
```

In this way, when we add new figures in the future, we will only have to implement this behavior in common and we will not have to modify the existing code.

Now people start asking your program to calculate the information of square shapes, so you create a class called `Square` which inherits from the` Rectangle` class you created a few steps ago, after all, a square is no more than a rectangle with a small constraint. And to meet that constraint, you changed the behavior of its `Height` and` Width` properties:

```csharp
public class Square : Rectangle
{
    private double _height;
    private double _width;

    public override double Height
    {
        get { return _height; }
        set
        {
            _height = value;
            _width = value;
        }
    }

    public override double Width
    {
        get { return _width; }
        set
        {
            _width = value;
            _height = value;
        }
    }
}
```

Now, there are even those who are developing applications with your code. Everything seems perfect, your program works like a charm, but it is violating the Liskov substitution principle.

## LSP violation 
Suppose as part of your program growth, you decided to start writing unit tests, and wrote one like the following:

```csharp
Rectangle rectangle = new Square();
rectangle.Width = 3;
rectangle.Height = 6;

const double expected = 18;
var actual = rectangle.Area();

Assert.AreEqual(expected, actual);  
```  

There are some weird things ... however the code compiles and runs, however the test fails. And this is what the whole Liskov substitution principle is all about: the subtypes of a class should always behave like this. In other words: it derives from a class just to add capabilities, not to modify what it already has.

## Complying with the LSP
The solution is quite simple: we must make `Square` not derived from` Rectangle`, and instead implement `IGeometrcShape`:

```csharp
public class Square : IGeometricShape
```  

In this way, no one, not even yourself, can think that in this area, squares and rectangles are related.

Now, everything seems perfect, your program works wonders, but it is violating the principle of segregation of the interface.

## ISP violation  
Without having the slightest intention, we introduced this violation when we comply with the OCP, and that is that the ISP tells us that we must separate the interfaces so that the software components that work with them have only the information they need from them and no more. Let's take a look at the `IGeometricShape` interface:

```csharp
public interface IGeometricShape
{
    double Area();
    double Perimeter();
}
```  

And it is used both in the calculation of sum of areas and in the calculation of perimeters. But why should the class in charge of adding the perimeters have to know that the elements it works with also have an area?

## Complying with the ISP  
Compliance with this principle leads us to separate the `IGeometricShape` interface into two:` IHasPerimeter` and `IHasArea`, in order to pass only the necessary information to each of the methods within our program:

```csharp
public interface IHasArea
{
    double Area();
}

public interface IHasPerimeter
{
    double Perimeter();
}

public interface IGeometricShape : IHasArea, IHasPerimeter
{
}
```

Your code starts to grow, fantastic, so you think it's better to keep organizing it and move all the logic of the calculation of sums to another class:

```csharp
public class GreatCalculator
{
    public double TotalAreas { get; private set; }
    public double TotalPerimeters { get; private set; }
  
    public void Calculate()
    {
        var figures = new IGeometricShape[]
        {
            new Rectangle {Width = 10, Height = 5},
            new EquilateralTriangle {SideLength = 5},
            new Rectangle {Width = 4, Height = 6},
            new Square {SideLength = 10},
            new Rectangle {Width = 8, Height = 9},
            new Square {SideLength = 8},
            new EquilateralTriangle {SideLength = 5}
        };
  
        var areaOperations = new AreaOperation();
        var perimeterOperations = new PerimeterOperation();
  
        TotalAreas = areaOperations.Sum(figures);
        TotalPerimeters = perimeterOperations.Sum(figures);
    }
}
```

And you made the necessary modifications to the main method of the program:

```csharp
private static void Main(string[] args)
{
    var calculator = new GreatCalculator();
    calculator.Calculate();
    
    Console.WriteLine($"Total Area: {calculator.TotalAreas}");
    Console.WriteLine($"Total Perimeter:{calculator.TotalPerimeters}");
    Console.ReadKey();
}
```

Your code is ready to be expanded further. Everything seems perfect, your program works like a charm, but it is violating the dependency inversion principle.

## DIP violation 
This violation occurs in the new class you just added, right in the `Calculate` method, and this is itself creating the figures it operates with (in the` figures` array). What will happen in the future when you want to add another figure? Or when you want to change the size of some of the existing figures?

## Complying with the DIP  
To comply with this principle we have to remove the dependency that the `GreatCalculator` class has with the` figures` arrangement, making the object that calls it the one in charge of providing it with the figures with which it has to operate:

```csharp
public void Calculate(IEnumerable<IGeometricShape> figures)
{
}
```

This reduces your dependency, and you are ready to trade any number of `IGeometricShape`s you want.

And ready, we have fulfilled the SOLID principles.
