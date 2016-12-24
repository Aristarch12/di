using System.Drawing;

namespace TagsCloudApp.Layouters
{
    public interface IRectangleLayouter
    {
        Rectangle PutNextRectangle(Size rectangleSize);
        void Clear();
        Point Center { get; set; }
    }
}
