using TickerText.Templates;

namespace TickerTextTests;

[TestClass]
    public class TextTemplateBuilderTests
    {
        [TestMethod]
        public void Build_ShouldCreateTextTemplateWithGivenValues()
        {
            // Arrange
            string name = "Template";
            string font = "Big";
            ConsoleColor color = ConsoleColor.White;
            int speedInMillis = 100;
            bool blinking = false;

            // Act
            TextTemplateBuilder builder = new TextTemplateBuilder()
                .SetName(name)
                .SetFont(font)
                .SetColor(color)
                .SetSpeed(speedInMillis)
                .SetBlinking(blinking);

            TextTemplate template = builder.Build();

            // Assert
            Assert.AreEqual(name, template.Name);
            Assert.AreEqual(font, template.FontName);
            Assert.AreEqual(color, template.Color);
            Assert.AreEqual(speedInMillis, template.SpeedInMillis);
            Assert.AreEqual(blinking, template.Blinking);
        }

        [TestMethod]
        public void Build_WithEmptyName_ShouldThrowArgumentException()
        {
            // Arrange
            string font = "Big";
            ConsoleColor color = ConsoleColor.White;
            int speedInMillis = 100;
            bool blinking = false;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                TextTemplateBuilder builder = new TextTemplateBuilder()
                    .SetFont(font)
                    .SetColor(color)
                    .SetSpeed(speedInMillis)
                    .SetBlinking(blinking);

                builder.Build();
            });
        }

        [TestMethod]
        public void Build_WithNullFont_ShouldThrowArgumentException()
        {
            // Arrange
            string name = "Template";
            ConsoleColor color = ConsoleColor.White;
            int speedInMillis = 100;
            bool blinking = false;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                TextTemplateBuilder builder = new TextTemplateBuilder()
                    .SetName(name)
                    .SetColor(color)
                    .SetSpeed(speedInMillis)
                    .SetBlinking(blinking);

                builder.Build();
            });
        }

        [TestMethod]
        public void SetName_ShouldSetTemplateName()
        {
            // Arrange
            string name = "Template";

            // Act
            TextTemplateBuilder builder = new TextTemplateBuilder();
            builder.SetName(name);
            builder.SetFont("Big");

            // Assert
            Assert.AreEqual(name, builder.Build().Name);
        }

        [TestMethod]
        public void SetFont_ShouldSetFontName()
        {
            // Arrange
            string font = "Big";

            // Act
            TextTemplateBuilder builder = new TextTemplateBuilder();
            builder.SetName("Template");
            builder.SetFont(font);

            // Assert
            Assert.AreEqual(font, builder.Build().FontName);
        }

        [TestMethod]
        public void SetColor_ShouldSetColor()
        {
            // Arrange
            ConsoleColor color = ConsoleColor.Red;

            // Act
            TextTemplateBuilder builder = new TextTemplateBuilder();
            builder.SetName("Template");
            builder.SetFont("Big");
            builder.SetColor(color);

            // Assert
            Assert.AreEqual(color, builder.Build().Color);
        }

        [TestMethod]
        public void SetSpeed_ShouldSetSpeedInMillis()
        {
            // Arrange
            int speedInMillis = 200;

            // Act
            TextTemplateBuilder builder = new TextTemplateBuilder();
            builder.SetName("Template");
            builder.SetFont("Big");
            builder.SetSpeed(speedInMillis);

            // Assert
            Assert.AreEqual(speedInMillis, builder.Build().SpeedInMillis);
        }

        [TestMethod]
        public void SetBlinking_ShouldSetBlinking()
        {
            // Arrange
            bool blinking = true;

            // Act
            TextTemplateBuilder builder = new TextTemplateBuilder();
            builder.SetName("Template");
            builder.SetFont("Big");
            builder.SetBlinking(blinking);

            // Assert
            Assert.AreEqual(blinking, builder.Build().Blinking);
        }
    }