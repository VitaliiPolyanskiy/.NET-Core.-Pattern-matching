using System;

namespace Pattern_matching
{
    interface IFigure
    {
        void FigureType();
        void Area();
    }

    interface IFigureAngle : IFigure
    {
        void Diagonal();
    }

    interface IFigureRound : IFigure
    {
        void Length();
    }

    class Rectangle : IFigureAngle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double n1, double n2)
        {
            Width = n1;
            Height = n2;
        }

        public void FigureType()
        {
            Console.WriteLine("\nПрямоугольник");
        }

        public void Area()
        {
            Console.WriteLine("Площадь прямоугольника равна: {0:F2}", Width * Height);
        }

        public void Diagonal()
        {
            Console.WriteLine("Длина диагонали равна: {0:F2}", Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2)));
        }

        public void Perimetr()
        {
            Console.WriteLine("Периметр прямоугольника равна: {0:F2}", 2 * (Width + Height));
        }
    }

    class Circle : IFigureRound
    {
        public double  Radius { get; set; }

        public Circle(double n1)
        {
            Radius = n1;
        }

        public void FigureType()
        {
            Console.WriteLine("\nОкружность");
        }

        public void Area()
        {
            Console.WriteLine("Площадь окружности равна: {0:F2}", Math.PI * Math.Pow(Radius, 2));
        }

        public void Length()
        {
            Console.WriteLine("Длина окружности равна: {0:F2}", 2 * Math.PI * Radius);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new(8, 10);       
            Circle crl = new(12);  
            Client1(rect);
            Client1(crl);
            Client2(rect);
            Client2(crl);
            Client3(rect);
            Client3(crl);
            Client4(rect);
            Client4(crl);
        }

        static void Client1(IFigure ifigure)
        {
            ifigure.FigureType();
            ifigure.Area();

            IFigureAngle iFigureAngle = ifigure as IFigureAngle;
            if (iFigureAngle != null)
            {
                iFigureAngle.Diagonal();
            }
            Rectangle rectangle = ifigure as Rectangle;
            if(rectangle != null)
            {
                rectangle.Perimetr();
            }
            IFigureRound iFigureRound = ifigure as IFigureRound;
            if (iFigureRound != null)
            {
                iFigureRound.Length();
            }
        }

        static void Client2(IFigure ifigure)
        {
            ifigure.FigureType();
            ifigure.Area();  
            
            if (ifigure is IFigureAngle)
            {
                IFigureAngle iFigureAngle = (IFigureAngle) ifigure;
                iFigureAngle.Diagonal();
            }
            
            if (ifigure is Rectangle)
            {
                Rectangle rectangle = (Rectangle) ifigure;
                rectangle.Perimetr();
            }
            
            if (ifigure is IFigureRound)
            {
                IFigureRound iFigureRound = (IFigureRound) ifigure;
                iFigureRound.Length();
            }
        }

        static void Client3(IFigure ifigure)
        {
            ifigure.FigureType();
            ifigure.Area();

            /*
             Pattern matching выполняет сопоставление с некоторым шаблоном (образцом). 
             Выполняется сопоставление с типом IFigureAngle, который выступает в качестве шаблона. 
             Если сопоставление прошло успешно, то в переменной iFigureAngle будет ссылка на объект.
            */
            if (ifigure is IFigureAngle iFigureAngle)
            {
                iFigureAngle.Diagonal();
            }

            /*
            Pattern matching выполняет сопоставление с некоторым шаблоном (образцом). 
            Выполняется сопоставление с типом Rectangle, который выступает в качестве шаблона. 
            Если сопоставление прошло успешно, то в переменной rectangle будет ссылка на объект.
            */
            if (ifigure is Rectangle rectangle)
            {
                rectangle.Perimetr();
            }

            /*
             Pattern matching выполняет сопоставление с некоторым шаблоном (образцом). 
             Выполняется сопоставление с типом IFigureRound, который выступает в качестве шаблона. 
             Если сопоставление прошло успешно, то в переменной iFigureRound будет ссылка на объект.
            */
            if (ifigure is IFigureRound iFigureRound)
            {
                iFigureRound.Length();
            }
        }

        static void Client4(IFigure ifigure)
        {
            ifigure.FigureType();
            ifigure.Area();

            switch (ifigure)
            {
                case IFigureAngle iFigureAngle:
                    iFigureAngle.Diagonal();
                    break;
                case IFigureRound iFigureRound:
                    iFigureRound.Length();
                    break;
            }

            switch (ifigure)
            {
                case Rectangle rectangle:
                    rectangle.Perimetr();
                    break;
                default:
                    Console.WriteLine("Фигура не является прямоугольником!");
                    break;
            }
        }
    }
}

