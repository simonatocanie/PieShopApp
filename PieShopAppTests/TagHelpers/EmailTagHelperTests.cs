
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using PieShopApp.TagHelpers;

namespace PieShopAppTests.TagHelpers
{
    public class EmailTagHelperTests
    {
        [Fact]
        public void Generates_EmailLink()
        {
            EmailTagHelper emailTag = new EmailTagHelper()
            {
                Address = "test@yahoo.com",
                Content = "Some test content"
            };

            var content = new Mock<TagHelperContent>();
            TagHelperContext context = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), "");
            TagHelperOutput output = new TagHelperOutput("a", new TagHelperAttributeList(),
                (code, test) => Task.FromResult(content.Object));

            emailTag.Process(context, output);
            Assert.Equal("Some test content", output.Content.GetContent());
            Assert.Equal("a", output.TagName);
            Assert.Equal("mailto:test@yahoo.com", output.Attributes[0].Value);
        }
    }
}
