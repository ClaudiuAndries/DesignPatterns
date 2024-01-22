using static BridgeDesignPattern.MainApp;

namespace BridgeDesignPattern;

class MainApp
{
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of radius {radius}");
        }
    }

    public abstract class Shape
    {
        protected IRenderer renderer;
        protected Shape( IRenderer renderer )
        {
            this.renderer = renderer;
        }

        public abstract void Drow();
        public abstract void Resize(float factor);
    }

    public class Circle : Shape
    {
        private float _radius;
        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            _radius = radius;
        }

        public override void Drow()
        {
            renderer.RenderCircle( _radius );
        }

        public override void Resize(float factor)
        {
            _radius *= factor;
        }
    }

    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing pixels for circle with radius {radius}");
        }
    }
    static void Main()
    {
        IRenderer renderer = new RasterRenderer();
        var circle = new Circle(renderer, 5);

        circle.Drow();
        circle.Resize(5);
        circle.Drow();
    }
}