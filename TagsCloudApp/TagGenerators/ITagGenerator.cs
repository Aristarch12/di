using System.Collections.Generic;
using System.Drawing;
using TagsCloudApp.Layouters;

namespace TagsCloudApp.TagGenerators
{
    public interface ITagGenerator
    {
        List<Tag> GetTags(IEnumerable<string> keywords, Point center);
    }
}
